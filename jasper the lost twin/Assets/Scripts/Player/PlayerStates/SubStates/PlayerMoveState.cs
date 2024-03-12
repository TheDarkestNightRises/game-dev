using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
	public PlayerMoveState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		player.CheckIfShouldFlip(xInput);

		if (xInput == 0)
		{
			stateMachine.ChangeState(player.IdleState);
		}
	}
	
	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
		
		//var currentVelocity = Mathf.MoveTowards(player.CurrentVelocity.x, playerData.movementVelocity * xInput, playerData.accelaration * Time.deltaTime);
		//player.SetVelocityX(currentVelocity);
		
		// Calculate acceleration based on player input
		float targetSpeed = playerData.movementVelocity * xInput;

		// Calculate acceleration rate (similar to your Run method)
		float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? playerData.runAccell : playerData.decAccell;

		// Calculate the difference between current velocity and desired velocity
		float speedDif = targetSpeed - player.RB.velocity.x;

		// Calculate force along the x-axis to apply to the player
		float movement = speedDif * accelRate;

		// Apply the acceleration force to the player's velocity
		player.RB.AddForce(movement * Vector2.right, ForceMode2D.Force);

	}
}
