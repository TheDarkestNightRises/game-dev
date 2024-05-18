using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_InvestigateState : InvestigateState
{
	private Archer enemy;
    public Archer_InvestigateState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_InvestigateState stateData, Archer enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        else if (areAllFlipsDone)
        {
	        stateMachine.ChangeState(enemy.MoveState);
        }
    }
}
