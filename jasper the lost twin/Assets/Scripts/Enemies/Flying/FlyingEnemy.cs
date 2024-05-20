using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
	public bool Chase { get; set; }
	public bool Returning { get; set; }
	public GameObject Player { get; set; }
	public Transform startingPoint;
	public Animator Anim { get; set; }
	
	private FlyingStateMachine stateMachine;
	public FlyingIdleState IdleState { get; set; }
	public FlyingChaseState ChaseState { get; set; }
	public FlyingHitState HitState { get; set; }
	public FlyingReturnState ReturnState { get; set; }
	public FlyingAttackState AttackState { get; set; }
	public FlyingDeathState DeathState { get; set; }
	[SerializeField]	
	public D_FlyingEnemy stateData;

	
	public void Awake()
	{
		Anim = GetComponent<Animator>();
		stateMachine = new FlyingStateMachine();
		IdleState = new FlyingIdleState(this, stateMachine, "idle", stateData);
		ChaseState = new FlyingChaseState(this, stateMachine, "chase", stateData);
		HitState = new FlyingHitState(this, stateMachine, "hit", stateData);
		DeathState = new FlyingDeathState(this, stateMachine, "death", stateData);
		ReturnState = new FlyingReturnState(this, stateMachine, "chase", stateData);
		AttackState = new FlyingAttackState(this, stateMachine, "attack", stateData);
	}
	
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start()
	{
		stateMachine.Initialize(IdleState);
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	protected void Update()
	{
		stateMachine.CurrentState.LogicUpdate();
	}
	
	protected void FixedUpdate()
	{
		stateMachine.CurrentState.PhysicsUpdate();
	}
	
	public void Flip(Vector3 targetPosition)
	{
		if (transform.position.x > targetPosition.x)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}
	
	public bool isPlayerInMinRange()
	{
		// Assuming stateData contains the minimum attack range value
		float minRange = stateData.range;

		// Calculate the distance between the enemy and the player
		float distanceToPlayer = Vector2.Distance(transform.position, Player.transform.position);

		// Check if the player is within the minimum attack range
		return distanceToPlayer <= minRange;
	}
	
	public void TriggerAttack()
	{
		AttackState.PerformAttack();
	}
}
