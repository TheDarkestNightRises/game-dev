using UnityEngine;

public class FlyingEnemy : MonoBehaviour, IDamageable
{
	public bool Chase { get; set; }
	private bool isAlive { get; set; }
	public bool Returning { get; set; }
	[SerializeField]
	private float currentHealth;
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
		isAlive = true;
		currentHealth = stateData.maxHealth;
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
	
	public void Damage(DamageData damageData)
	{	
		if (!isAlive)
		{
			return;
		}
		
		if (stateMachine.CurrentState == HitState)
		{
			return;
		}
		
		stateMachine.ChangeState(HitState);
		
		Debug.Log("Took damage lol {damageData.Amount}");
		currentHealth -= damageData.Amount;
		CharacterEvents.CharacterDamaged.Invoke(gameObject, damageData.Amount);
		
		if (currentHealth <= 0)
		{
			isAlive = false;
			stateMachine.ChangeState(DeathState);
		}
	}
}
