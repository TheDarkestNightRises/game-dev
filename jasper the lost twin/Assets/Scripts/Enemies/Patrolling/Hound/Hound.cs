using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound : Entity
{
	public Hound_IdleState IdleState { get; set; }
	public Hound_Move_State MoveState { get; set; }
	public Hound_PlayerDetectedState PlayerDetectedState { get; set; }
	
	[SerializeField]
	private D_IdleState idleStateData;
	[SerializeField]
	private D_MoveState moveStateData;
	[SerializeField]
	private D_PlayerDetected playerDetectedData;
	
	protected override void Awake()
	{
		base.Awake();
		MoveState = new Hound_Move_State(this, stateMachine, "move", moveStateData, this);
		IdleState = new Hound_IdleState(this, stateMachine, "idle", idleStateData, this);
		PlayerDetectedState = new Hound_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
	}
	
	public override void Start()
	{		
		stateMachine.Initialize(MoveState);
	}
}
