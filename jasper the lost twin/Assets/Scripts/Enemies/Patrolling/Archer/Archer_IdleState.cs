using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_IdleState : IdleState
{
	private Archer enemy;

    public Archer_IdleState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

	public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinRange)
        {
            stateMachine.ChangeState(enemy.PlayerDetectedState);
        }
        else if (isIdleTimeOver)
        {
	        stateMachine.ChangeState(enemy.MoveState);
        }
    }
}
