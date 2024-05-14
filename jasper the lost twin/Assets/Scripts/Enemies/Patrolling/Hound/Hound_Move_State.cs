using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_Move_State : MoveState
{
	private Hound hound;
	
	public Hound_Move_State(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Hound hound) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.hound = hound;
	}
	
	public override void Enter()
	{
		base.Enter();
	}
	
	public override void Exit()
	{
		base.Exit();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		Debug.Log($"IsPlayerInMinRange {isPlayerInMinRange}");
		if (isPlayerInMinRange)
		{
			stateMachine.ChangeState(hound.PlayerDetectedState);
		}

		else if (isDetectingWall || !isDetectingLedge)
		{
			hound.IdleState.SetFlipAfterIdle(true);
			stateMachine.ChangeState(hound.IdleState);
		}
	}
}
