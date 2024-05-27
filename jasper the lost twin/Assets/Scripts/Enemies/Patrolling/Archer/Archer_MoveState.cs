using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_MoveState : MoveState
{
	private Archer enemy;

    public Archer_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Archer enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        else if(isDetectingWall || !isDetectingLedge)
        {
            enemy.IdleState.SetFlipAfterIdle(true);
	        stateMachine.ChangeState(enemy.IdleState);
        }
    }
}
