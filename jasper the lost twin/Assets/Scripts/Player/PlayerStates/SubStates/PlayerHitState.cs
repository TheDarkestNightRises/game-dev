using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
	protected bool isStunTimeOver;
	protected float stunTime = 0.25f;
	
	public PlayerHitState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter() {
		base.Enter();

		isStunTimeOver = false;
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (Time.time >= startTime + stunTime) {
			isStunTimeOver = true;
		}
		
		if (isStunTimeOver)
		{
			stateMachine.ChangeState(player.IdleState);
		}
	}
}
