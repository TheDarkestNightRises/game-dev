using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
	public PlayerIdleState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter()
	{
		base.Enter();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		if (xInput != 0)
		{
			stateMachine.ChangeState(player.MoveState);
		}
	}
	
	public override void PhysicsUpdate()
	{
		ApplyFriction();
	}
	
	private void ApplyFriction()
	{
		// Calculate friction force based on the current velocity
		var velocityX = player.RB.velocity.x;
		float frictionForce = Mathf.Min(Mathf.Abs(velocityX), playerData.friction);
		frictionForce *= Mathf.Sign(velocityX);

		// Apply the friction force to the player's velocity
		player.RB.AddForce(-frictionForce * Vector2.right, ForceMode2D.Impulse);
	}

}
