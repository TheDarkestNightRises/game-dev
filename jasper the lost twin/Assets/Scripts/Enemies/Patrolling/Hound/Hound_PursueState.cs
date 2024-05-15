using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_PursueState : PursueState
{
	private Hound hound;
	
	public Hound_PursueState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PursueState stateData, Hound hound) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.hound = hound;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isInMeleeRange) 
		{
			stateMachine.ChangeState(hound.MeleeAttackState);
		}
		else if (!isDetectingLedge || isDetectingWall)
		{
			stateMachine.ChangeState(hound.InvestigateState);
		}
		else if (isPursueOver)
		{
			if (isPlayerInMinAgroRange) stateMachine.ChangeState(hound.PlayerDetectedState);
			stateMachine.ChangeState(hound.MoveState);
		}
	}
}
