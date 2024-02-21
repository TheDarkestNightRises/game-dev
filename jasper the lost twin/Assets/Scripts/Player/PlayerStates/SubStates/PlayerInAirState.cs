using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
	private bool isGrounded;
	private int xInput;
	private bool jumpInput;
	
	public PlayerInAirState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void DoChecks()
	{
		base.DoChecks();
		isGrounded = player.CheckIfTouchingGround();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		xInput = player.InputHandler.InputX;
		jumpInput = player.InputHandler.JumpInput;
		
		if (isGrounded && player.CurrentVelocity.y < 0.01f)
		{
			stateMachine.ChangeState(player.LandState);
		}
		else if (jumpInput && player.JumpState.CanJump())
		{
			stateMachine.ChangeState(player.JumpState);
		}
		else
		{
			player.CheckIfShouldFlip(xInput);
			player.SetVelocityX(playerData.movementVelocity * xInput);
			
			player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
			player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
		}
	}
}
