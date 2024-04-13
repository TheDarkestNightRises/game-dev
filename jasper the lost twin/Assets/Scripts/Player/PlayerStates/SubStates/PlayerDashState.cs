using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
	public bool CanDash {get; set;}
	public bool isHolding {get; set;}
	private Vector2 dashDirection;
	private Vector2 dashDirectionInput;
	public float lastDashTime;
	
 public PlayerDashState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter()
	{
		base.Enter();
		CanDash = false;
		player.InputHandler.UseDashInput();
		
		isHolding = true;
		dashDirection = Vector2.right * player.FacingDirection;
		
		Time.timeScale = playerData.holdTimeScale;
		startTime = Time.unscaledTime;
	}
	
	public override void Exit()
	{
		base.Exit();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if(isHolding)
		{
			dashDirectionInput = player.InputHandler.DashDirectionInput;
			if(dashDirectionInput != Vector2.zero)
			{
				dashDirection = dashDirectionInput;
				dashDirection.Normalize();
			}
			float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
			player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);
 		}
	}
	
	public bool CheckIfCanDash()
	{
		return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
	}
	
	public void ResetCanDash() => CanDash = true;
	
}
