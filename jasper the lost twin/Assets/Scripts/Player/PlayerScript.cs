using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour, IDamageable
{
	#region States
	public PlayerStateMachine StateMachine { get; private set; }
	public PlayerIdleState IdleState { get; set; }
	public PlayerMoveState MoveState { get; set; }
	public PlayerJumpState JumpState { get; set; }
	public PlayerInAirState InAirState { get; set; }	
	public PlayerLandState LandState { get; set; }
	public PlayerAttackState PrimaryAttackState { get; set; }
	public PlayerAttackState SecondaryAttackState { get; set; }
	public PlayerDashState DashState { get; set; }
	public PlayerHitState HitState { get; set; }
	public PlayerDeathState DeathState { get; set; }
	public PlayerClimbState ClimbState { get; set; }
	

	#endregion

	#region Player Components
	public Animator Anim { get; private set; }	
	public PlayerInputHandler InputHandler { get; set; }
	public Transform DashDirectionIndicator {get; set;}
	[SerializeField]
	public PlayerData playerData;
	[SerializeField]
	public GameObject groundCheck;
	public Rigidbody2D RB { get; set; }
	private CapsuleCollider2D myBodyCollider;	
	#endregion
	
	#region Particles
	public ParticleSystem dust;
	#endregion
	
	public Vector2 CurrentVelocity { get; set; }
	public int FacingDirection { get; set; }
	private Vector2 workspace;
	private CinemachineImpulseSource impulseCamera;
	public PlayerInventory Inventory { get; set; }
	public bool IsInvincibile { get; set; }
	[SerializeField]
	private float currentHealth;

	public Transform keyFollowPoint;

	public Key followingKey;

	public float CurrentHealth
	
	{
		get { return currentHealth; }
		set { currentHealth = value; 
		CharacterEvents.OnHealthChanged?.Invoke(currentHealth, playerData.maxHealth);}
	}

	private float climbSpeed = 10f;
	private float gravityAtStart;

	public void Awake()
	{
		StateMachine = new PlayerStateMachine();
		IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
		MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
		JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
		InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
		LandState = new PlayerLandState(this, StateMachine, playerData, "land");
		PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
		SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
		DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
		HitState = new PlayerHitState(this, StateMachine, playerData, "hit");
		DeathState = new PlayerDeathState(this, StateMachine, playerData, "death");
		ClimbState = new PlayerClimbState(this, StateMachine, playerData, "climb");
	}
	

	private void Start()
	{
		myBodyCollider = GetComponent<CapsuleCollider2D>();
		Anim = GetComponent<Animator>();
		InputHandler = GetComponent<PlayerInputHandler>();
		RB = GetComponent<Rigidbody2D>();
		impulseCamera = GetComponent<CinemachineImpulseSource>();
		Inventory = GetComponent<PlayerInventory>();
		DashDirectionIndicator = transform.Find("DashDirectionIndicator");
		FacingDirection = 1;
		CurrentHealth = playerData.maxHealth;
		PrimaryAttackState.SetWeapon(Inventory.Weapons[0]);
		StateMachine.Initialize(IdleState);
		gravityAtStart = RB.gravityScale;
	}
	
	private void Update()
	{
		if (!isAlive) return;
		CheckIfTouchingHazard();
		CurrentVelocity = RB.velocity;
		StateMachine.CurrentState.LogicUpdate();
	}
	
	public bool CheckIfTouchingLadder()
	{
		if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) return true;
		return false;
	}
	
	private void FixedUpdate()
	{
		if (!isAlive) return;
		StateMachine.CurrentState.PhysicsUpdate();
	}
	
	public void SetVelocity(float velocity, Vector2 direction)
	{
		workspace = direction * velocity;
		RB.velocity = workspace;
		CurrentVelocity = workspace;
	}
	
	public void SetVelocityX(float velocity)
	{
		workspace.Set(velocity, CurrentVelocity.y);
		RB.velocity = workspace;
		CurrentVelocity = workspace;
	}
	
	public void SetVelocityY(float velocity)
	{
		workspace.Set(CurrentVelocity.x, velocity);
		RB.velocity = workspace;
		CurrentVelocity = workspace;
	}
	
	public void Die()
	{
		isAlive = false;
		StateMachine.ChangeState(DeathState);
	}
	
	void CheckIfTouchingHazard()
	{
		if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
		{
			var damageData = new DamageData(30f, this.gameObject);
			Damage(damageData);
		}
	}
	
	public bool IsMaxHealth()
	{
		return currentHealth == playerData.maxHealth;
	}
	
	public void RemovePhysics()
	{
		RB.simulated = false;
	}
	
	public void ApplyFriction()
	{
		// Calculate friction force based on the current velocity
		var velocityX = RB.velocity.x;
		float frictionForce = Mathf.Min(Mathf.Abs(velocityX), playerData.friction);
		frictionForce *= Mathf.Sign(velocityX);

		// Apply the friction force to the player's velocity
		RB.AddForce(-frictionForce * Vector2.right, ForceMode2D.Impulse);
	}
	
	public void Flip()
	{
		FacingDirection *= -1;
		transform.Rotate(0.0f, 180.0f, 0.0f);
	}
	
	public void CheckIfShouldFlip(int xInput)
	{
		if (xInput != 0 && xInput != FacingDirection)
		{
			Flip();
		}
		
		if (CheckIfTouchingGround())
		{
			dust.Play();
		}
	}
	
	public bool CheckIfTouchingGround()
	{
		return Physics2D.Raycast(groundCheck.transform.position, Vector2.down, playerData.rangeFromGround, playerData.whatIsGround);
	}
	
	private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
	
	private void AnimationFinishedTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
	
	public void GenerateImpulse(float impulse)
	{
		impulseCamera.GenerateImpulse(impulse);
	}
	
	bool isAlive = true;
	
	public void Damage(DamageData damageData)
	{
		if (!isAlive) return;
		if (IsInvincibile) 	return;
		if (CurrentHealth <= 0)
		{
			isAlive = false;
			StateMachine.ChangeState(DeathState);
			return;
		}
		if (StateMachine.CurrentState == HitState) return;	
		CurrentHealth -= damageData.Amount;
		CurrentHealth = Mathf.Max(0, CurrentHealth);
		CharacterEvents.CharacterDamaged.Invoke(gameObject, damageData.Amount);
		StateMachine.ChangeState(HitState);
	}
	
	public void Heal(int healthRestore)
	{
		if(isAlive)
		{
			CurrentHealth += healthRestore;
			CurrentHealth = Mathf.Min(CurrentHealth, playerData.maxHealth);
	
			CharacterEvents.CharacterHealed(gameObject, healthRestore);
		}
	}
}













