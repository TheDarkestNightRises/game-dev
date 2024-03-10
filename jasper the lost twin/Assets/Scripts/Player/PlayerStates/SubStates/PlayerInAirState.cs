// PlayerInAirState.cs

using System.Collections;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
	private bool isGrounded;
	private int xInput;
	private bool jumpInput;
	private bool coyoteTime;
	private bool isJumping;
	private bool jumpInputStop;

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
		CheckCoyote();
		xInput = player.InputHandler.InputX;
		jumpInput = player.InputHandler.JumpInput;
		jumpInputStop = player.InputHandler.JumpInputStop;

		CheckJumpHold();
        
		if (isGrounded && player.CurrentVelocity.y < 0.01f)
		{
			HandleLanding();
		}
		else if (jumpInput && player.JumpState.CanJump())
		{
			stateMachine.ChangeState(player.JumpState);
		}
		else
		{
			HandleInAirMovement();
		}
	}

	private void HandleLanding()
	{
		isJumping = false;
		SetGravityScale(playerData.gravityScale); // Set gravity back to normal
		stateMachine.ChangeState(player.LandState);
	}

	private void HandleInAirMovement()
	{
		player.CheckIfShouldFlip(xInput);
		player.SetVelocityX(playerData.movementVelocity * xInput);

		// Falling should increase gravity (feather fall)
		SetGravityScale(playerData.gravityScale * playerData.fallGravityMultiplier);
		// Fall speed has a maximum threshold 
		player.RB.velocity = new Vector2(player.RB.velocity.x, Mathf.Max(player.RB.velocity.y, -playerData.maximumFallingSpeed));

		player.Anim.SetFloat("yVelocity", player.CurrentVelocity.y);
		player.Anim.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
	}

	private void SetGravityScale(float newGravityScale)
	{
		player.RB.gravityScale = newGravityScale;
	}

	private void CheckCoyote()
	{
		if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
		{
			coyoteTime = false;
			player.JumpState.DecreaseAmmountOfJumpsLeft();
		}
	}

	private void CheckJumpHold()
	{
		if (isJumping)
		{
			if (jumpInputStop)
			{
				player.SetVelocityY(player.CurrentVelocity.y * playerData.jumpHoldMultiplier);
				isJumping = false;
			}
			else if (player.CurrentVelocity.y <= 0f)
			{
				isJumping = false;
			}
		}
	}

	public void StartCoyote() => coyoteTime = true;
	public void SetIsJumping() => isJumping = true;
}
