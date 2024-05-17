using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
	protected float stunTime = 0.5f;
	
	public PlayerHitState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter() {
		base.Enter();
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		player.SetVelocityX(0f);
		
		if (Time.time >= startTime + stunTime) {
			stateMachine.ChangeState(player.IdleState);
		}
		
	}
	
	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
		player.ApplyFriction();
	}
}
