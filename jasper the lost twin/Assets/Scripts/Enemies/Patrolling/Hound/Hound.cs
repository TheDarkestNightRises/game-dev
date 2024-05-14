﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound : Entity
{
	public Hound_IdleState IdleState { get; set; }
	public Hound_Move_State MoveState { get; set; }
	public Hound_PlayerDetectedState PlayerDetectedState { get; set; }
	public Hound_PursueState PursueState { get; set; }
	public Hound_InvestigateState InvestigateState { get; set; }

	
	[SerializeField]
	private D_IdleState idleStateData;
	[SerializeField]
	private D_MoveState moveStateData;
	[SerializeField]
	private D_PlayerDetected playerDetectedData;
	[SerializeField]
	private D_PursueState pursueData;
	[SerializeField]
	private D_InvestigateState investigateData;
	
	protected override void Awake()
	{
		base.Awake();
		MoveState = new Hound_Move_State(this, stateMachine, "move", moveStateData, this);
		IdleState = new Hound_IdleState(this, stateMachine, "idle", idleStateData, this);
		PlayerDetectedState = new Hound_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
		PursueState = new Hound_PursueState(this, stateMachine, "pursue", pursueData, this);
		InvestigateState = new Hound_InvestigateState(this, stateMachine, "investigate", investigateData, this);
	}
	
	public override void Start()
	{		
		stateMachine.Initialize(MoveState);
	}
}
