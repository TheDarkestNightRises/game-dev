using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
	protected D_PlayerDetected stateData;
	protected bool isPlayerInMinRange;
	protected bool isPlayerInMaxRange;

	
	public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
	}
	
	public override void Enter()
	{
		base.Enter();
		
		entity.SetVelocityX(0f);
	}
	
	public override void DoChecks()
	{
		base.DoChecks();
		isPlayerInMinRange = entity.CheckPlayerInMinRange();
		isPlayerInMaxRange = entity.CheckPlayerInMaxRange();
	}
}
