using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
	public D_Entity entityData;
	public int FacingDirection { get; set; }
	private Vector2 velocityWorkspace;
	public FiniteStateMachine stateMachine;
	protected Rigidbody2D RB { get; set; }
	public Animator Anim { get; set; }
	public GameObject GO { get; set; }
	[SerializeField]
	private Transform wallcheck;
	[SerializeField]
	private Transform ledgeCheck;
	[SerializeField]
	private Transform playerCheck;
	private float currentHealth;
	private int lastDamageDirection;

	protected virtual void Awake()
	{
		currentHealth = entityData.maxHealth;
		RB = GetComponent<Rigidbody2D>();	
		Anim = GetComponent<Animator>();	
		stateMachine = new FiniteStateMachine();
		FacingDirection = -1;
	}
		
	public virtual void Start()
	{
	}
	
	protected void Update()
	{
		stateMachine.CurrentState.LogicUpdate();
	}
	
	protected void FixedUpdate()
	{
		stateMachine.CurrentState.PhysicsUpdate();
	}
	
	public void SetVelocityX(float velocity)
	{
		velocityWorkspace.Set(FacingDirection * velocity, RB.velocity.y);
		RB.velocity = velocityWorkspace;
	}		
	
	public bool CheckWall()
	{
		return Physics2D.Raycast(wallcheck.position, -transform.right, entityData.wallCheckRange, entityData.whatIsGround);
	}
	
	public bool CheckLedge()
	{
		return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckRange, entityData.whatIsGround);
	}
	
	public bool CheckPlayerInMinRange()
	{
		return Physics2D.Raycast(playerCheck.position, -transform.right, entityData.minAggroDistance, entityData.whatIsPlayer);
	}
	
	public bool CheckPlayerInMaxRange()
	{
		return Physics2D.Raycast(playerCheck.position, -transform.right, entityData.maxAggroDistance, entityData.whatIsPlayer);
	}
	
	public bool CheckPlayerInMeleeRangeAction()
	{
		return Physics2D.Raycast(playerCheck.position, -transform.right, entityData.meleeAttackRange, entityData.whatIsPlayer);
	}
	
	public virtual void Damage(DamageData damageData)
	{
		Debug.Log("Took damage lol {damageData.Amount}");
		currentHealth -= damageData.Amount;
		DamageHop(entityData.damageHopVelocity);
	}
	
	public virtual void DamageHop(float velocity)
	{
		velocityWorkspace.Set(RB.velocity.x, velocity);
		RB.velocity = velocityWorkspace;
	}
	
	public void Flip()
	{
		FacingDirection *= -1;
		transform.Rotate(0f,180f,0f);
	}
	
	protected virtual void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(wallcheck.position, wallcheck.position + (Vector3) (Vector2.right * FacingDirection * entityData.wallCheckRange));
		Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3) (Vector2.right * FacingDirection * entityData.ledgeCheckRange));
	}
}
