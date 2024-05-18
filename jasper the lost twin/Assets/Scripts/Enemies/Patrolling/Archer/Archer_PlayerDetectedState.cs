using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_PlayerDetectedState : PlayerDetectedState
{
	private Archer enemy;

    public Archer_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
	    base.LogicUpdate();
        
        if (performLongRangeAction)
        {
	        stateMachine.ChangeState(enemy.RangedAttackState);
        }
        else if (!isPlayerInMaxRange)
        {
	        stateMachine.ChangeState(enemy.InvestigateState);
        }
    }
}
