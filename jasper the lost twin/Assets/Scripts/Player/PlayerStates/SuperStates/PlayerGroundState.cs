using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
	protected int xInput;
	private bool jumpInput;
	
	public PlayerGroundState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter()
	{
		base.Enter();
		player.JumpState.ResetAmmountOfJumpsLeft();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();

		xInput = player.InputHandler.InputX;
		jumpInput = player.InputHandler.JumpInput;
		
		if (jumpInput && player.JumpState.CanJump())
		{
			player.InputHandler.UseJumpInput();
			stateMachine.ChangeState(player.JumpState);
		}
		else if(!player.CheckIfTouchingGround())
		{
			stateMachine.ChangeState(player.InAirState);
		}
	}
}
