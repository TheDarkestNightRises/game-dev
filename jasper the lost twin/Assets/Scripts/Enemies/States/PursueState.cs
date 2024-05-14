using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueState : State
{
	protected D_PursueState stateData;
	protected bool isPlayerInMinAgroRange;
	protected bool isDetectingLedge;
	protected bool isDetectingWall;
	protected bool isPursueOver;

	public PursueState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PursueState stateData) : base(entity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
	}
	
	public override void Enter()
	{
		base.Enter();
		isPursueOver = false;
		entity.SetVelocityX(stateData.pursueSpeed);
	}
	
	public override void DoChecks()
	{
		base.DoChecks();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinRange();
		isDetectingWall = entity.CheckWall();
		isDetectingLedge = entity.CheckLedge();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (Time.time >= startTime + stateData.pursueSpeed)
		{
			isPursueOver = true;
		}
	}
}
