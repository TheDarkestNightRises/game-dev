using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound : Entity
{
	public Hound_IdleState IdleState { get; set; }
	public Hound_Move_State MoveState { get; set; }
	public Hound_PlayerDetectedState PlayerDetectedState { get; set; }
	public Hound_PursueState PursueState { get; set; }
	public Hound_InvestigateState InvestigateState { get; set; }
	public Hound_MeleeAttackState MeleeAttackState { get; set; }
	public Hound_DeathState DeathState { get; set; }
	public Hound_HitState HitState { get; set; }

	[SerializeField]
	private D_IdleState idleStateData;
	[SerializeField]
	private D_MoveState moveStateData;
	[SerializeField]
	private D_PlayerDetected playerDetectedData;
	[SerializeField]
	private D_PursueState pursueData;
	[SerializeField]
	private D_InvestigateState investigateData;
	[SerializeField]
	private D_MeleeAttack meleeAttackData;
	[SerializeField]
	private D_DeadState deathStateData;
	[SerializeField]
	private D_HitState hitStateData;
	[SerializeField]
	private Transform meleeAttackPosition;

	protected override void Awake()
	{
		base.Awake();
		MoveState = new Hound_Move_State(this, stateMachine, "move", moveStateData, this);
		IdleState = new Hound_IdleState(this, stateMachine, "idle", idleStateData, this);
		PlayerDetectedState = new Hound_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
		PursueState = new Hound_PursueState(this, stateMachine, "pursue", pursueData, this);
		InvestigateState = new Hound_InvestigateState(this, stateMachine, "investigate", investigateData, this);
		MeleeAttackState = new Hound_MeleeAttackState(this, stateMachine,"meleeAttack", meleeAttackPosition, meleeAttackData, this);
		DeathState = new Hound_DeathState(this, stateMachine,"death", deathStateData, this);
		HitState = new Hound_HitState(this, stateMachine, "hit", hitStateData, this);
	}
	
	public override void Start()
	{		
		stateMachine.Initialize(MoveState);
	}
	
	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		
		Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
	}
	
	public void SendTriggerAttack()
	{
		MeleeAttackState.TriggerAttack();
	}
	
	public void SendFinishAttack()
	{
		MeleeAttackState.FinishAttack();
	}
	
	public override void Damage(DamageData damageData)
	{
		if (stateMachine.CurrentState != HitState)
		{
			stateMachine.ChangeState(HitState);
		}
		if (!isAlive)
		{
			stateMachine.ChangeState(DeathState);
		}
		base.Damage(damageData);
	}
}
