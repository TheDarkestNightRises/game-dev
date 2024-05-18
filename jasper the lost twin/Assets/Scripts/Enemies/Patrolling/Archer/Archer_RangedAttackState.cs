using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_RangedAttackState : RangedAttackState
{
	private Archer enemy;

    public Archer_RangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Archer enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMinRange)
            {
	            stateMachine.ChangeState(enemy.PlayerDetectedState);
            }
            else
            {
	            stateMachine.ChangeState(enemy.InvestigateState);
            }
        }
    }
}
    
