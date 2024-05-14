using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_PlayerDetectedState : PlayerDetectedState
{
	private Hound hound;
	
	public Hound_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Hound hound) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.hound = hound;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (performLongRangeAction)
		{
			hound.IdleState.SetFlipAfterIdle(false);
			stateMachine.ChangeState(hound.PursueState);
		}
		else if (!isPlayerInMaxRange)
		{
			stateMachine.ChangeState(hound.InvestigateState);
		}
	}
}
