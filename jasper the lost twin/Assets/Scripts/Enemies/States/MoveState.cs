﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
	protected D_MoveState stateData;

	protected bool isDetectingWall;
	protected bool isDetectingLedge;

	public MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
	}

	public override void DoChecks()
	{
		base.DoChecks();

		isDetectingLedge = entity.CheckLedge();
		isDetectingWall = entity.CheckWall();
	}

	public override void Enter()
	{
		base.Enter();
		entity.SetVelocityX(stateData.movementSpeed);        
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		entity.SetVelocityX(stateData.movementSpeed);        
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}