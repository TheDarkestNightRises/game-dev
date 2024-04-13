using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
	public bool CanDash {get; set;}
	public float lastDashTime;
	
 public PlayerDashState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public bool CheckIfCanDash()
	{
		return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
	}
	
	public void ResetCanDash() => CanDash = true;
}
