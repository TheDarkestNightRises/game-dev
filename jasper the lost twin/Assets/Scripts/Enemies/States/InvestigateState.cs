using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateState : State
{
	protected bool flipNow;
	protected D_InvestigateState stateData;
	protected bool isPlayerInMinRange;
	protected bool isInvestigateTimeDone;
	protected bool areAllFlipsDone;
	
	protected float lastFlipTime;
	protected float ammountOfFlipsDone;
	
	public InvestigateState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_InvestigateState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
	}
	
	public override void DoChecks()
	{
		base.DoChecks();
		isPlayerInMinRange = entity.CheckPlayerInMinRange();
	}
	
	public override void Enter()
	{
		base.Enter();
		isInvestigateTimeDone = false;
		areAllFlipsDone = false;
		lastFlipTime = startTime;
		ammountOfFlipsDone = 0;
		entity.SetVelocityX(0f);
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (flipNow)
		{
			entity.Flip();
			lastFlipTime = Time.time;
			ammountOfFlipsDone++;
			flipNow = false;
		}	
		else if (Time.time >= lastFlipTime + stateData.timeBetweenFlip && !areAllFlipsDone)
		{
			entity.Flip();
			lastFlipTime = Time.time;
			ammountOfFlipsDone++;
		}
		
		if (ammountOfFlipsDone >= stateData.numberOfFlips)
		{
			areAllFlipsDone = true;
		}
		
		if (Time.time >= lastFlipTime + stateData.timeBetweenFlip && areAllFlipsDone)
		{
			isInvestigateTimeDone = true;
		}
	}
	
	public void SetFlipNow(bool flip)
	{
		flipNow = flip;
	}
}
