using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_InvestigateState : InvestigateState
{
	private Hound hound;
	
	public Hound_InvestigateState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_InvestigateState stateData, Hound hound) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.hound = hound;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isPlayerInMinRange)
		{
			stateMachine.ChangeState(hound.PlayerDetectedState);
		}
		
		else if (areAllFlipsDone)
		{
			stateMachine.ChangeState(hound.MoveState);
		}
	}
}
