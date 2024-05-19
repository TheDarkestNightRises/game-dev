using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Entity
{   
	public Archer_MoveState MoveState { get;  set; }
	public Archer_IdleState IdleState { get;  set; }
	public Archer_PlayerDetectedState PlayerDetectedState { get; set; }
	public Archer_InvestigateState InvestigateState { get; private set; }
	public Archer_HitState HitState { get; private set; }
	public Archer_DeathState DeathState { get; private set; }
	public Archer_RangedAttackState RangedAttackState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
	private D_InvestigateState investigateData;
    [SerializeField]
	private D_HitState hitStateData;
    [SerializeField]
	public D_DeadState deathStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;

    [SerializeField]
    private Transform rangedAttackPosition;

    protected override void Awake()
    {
        base.Awake();

	    MoveState = new Archer_MoveState(this, stateMachine, "move", moveStateData, this);
	    IdleState = new Archer_IdleState(this, stateMachine, "idle", idleStateData, this);
	    PlayerDetectedState = new Archer_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
	    InvestigateState = new Archer_InvestigateState(this, stateMachine, "investigate", investigateData, this);
	    HitState = new Archer_HitState(this, stateMachine, "hit", hitStateData, this);
	    DeathState = new Archer_DeathState(this, stateMachine, "death", deathStateData, this);
	    RangedAttackState = new Archer_RangedAttackState(this, stateMachine, "attack", rangedAttackPosition, rangedAttackStateData, this);
    }
    
    private void Start()
    {
	    stateMachine.Initialize(MoveState);        
    }
    
	public void SendTriggerAttack()
	{
		RangedAttackState.TriggerAttack();
	}
	
	public void SendFinishAttack()
	{
		RangedAttackState.FinishAttack();
	}

	
	public override void Damage(DamageData damageData)
	{
		if (stateMachine.CurrentState == HitState)
		{
			return;
		}
		
		if (!isAlive)
		{
			stateMachine.ChangeState(DeathState);
			return;
		}
		
		base.Damage(damageData);
		stateMachine.ChangeState(HitState);

	}

}
