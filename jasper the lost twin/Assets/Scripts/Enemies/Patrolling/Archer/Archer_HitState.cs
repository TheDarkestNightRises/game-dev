using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_HitState : HitState
{
	private Archer enemy;

    public Archer_HitState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_HitState stateData, Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isStunTimeOver)
        {
            if (isPlayerInMinAgroRange)
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
