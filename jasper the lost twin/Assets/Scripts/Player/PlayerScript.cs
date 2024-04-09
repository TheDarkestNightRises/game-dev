using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerScript : MonoBehaviour
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
	#endregion

	#region Player Components
	public Animator Anim { get; private set; }	
	public PlayerInputHandler InputHandler { get; set; }
	
	[SerializeField]
	private PlayerData playerData;
	public Rigidbody2D RB { get; set; }
	private BoxCollider2D myFeetCollider;
	private CapsuleCollider2D myBodyCollider;
	
	[SerializeField]
	Vector2 deathKick = new Vector2(10f, 10f);
	
	#endregion
	
	#region Particles
	public ParticleSystem dust;
	#endregion
	
	public Vector2 CurrentVelocity { get; set; }
	public int FacingDirection { get; set; }
	private Vector2 workspace;
	private CinemachineImpulseSource myImpulseSource;

	

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
	}
	
	bool isAlive = true;
	
	private void Start()
	{
		myFeetCollider = GetComponent<BoxCollider2D>();
		myBodyCollider = GetComponent<CapsuleCollider2D>();
		Anim = GetComponent<Animator>();
		InputHandler = GetComponent<PlayerInputHandler>();
		RB = GetComponent<Rigidbody2D>();
		myImpulseSource = GetComponent<CinemachineImpulseSource>();
		FacingDirection = 1;
		StateMachine.Initialize(IdleState);
	}
	
	private void Update()
	{
		if (!isAlive) return;
		CurrentVelocity = RB.velocity;
		StateMachine.CurrentState.LogicUpdate();
	
	}
	
	private void FixedUpdate()
	{
		if (!isAlive) return;
		StateMachine.CurrentState.PhysicsUpdate();
		Die();
		
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
	
	// Player dies method
	void Die()
	{
		if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
		{
			isAlive = false;
			Anim.SetTrigger("die");
			RB.AddForce(Vector2.up * playerData.deathKick, ForceMode2D.Impulse);
			myImpulseSource.GenerateImpulse(playerData.deathImpulse);
			ApplyFriction();
			Invoke(nameof(RemovePhysics), 1f);
		}
	}
	
	private void RemovePhysics()
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
		return myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")); 
	}
	
	private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
	
	private void AnimationFinishedTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}













