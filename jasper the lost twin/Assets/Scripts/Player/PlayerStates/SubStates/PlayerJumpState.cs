using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
	private int ammountOfJumpsLeft;
	
	public PlayerJumpState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		ammountOfJumpsLeft = playerData.amountOfJumps;
	}
	
	public override void Enter()
	{
		base.Enter();
		player.SetVelocityY(playerData.jumpVelocity);
		isAbilityDone = true;
		DecreaseAmmountOfJumpsLeft();
		player.InAirState.SetIsJumping();
	}
	
	public bool CanJump() => ammountOfJumpsLeft > 0;
	
	public void ResetAmmountOfJumpsLeft() => ammountOfJumpsLeft = playerData.amountOfJumps;
	
	public void DecreaseAmmountOfJumpsLeft()
	{
		ammountOfJumpsLeft--;
		Debug.Log($"Ammounts of jumps left : {ammountOfJumpsLeft}");
	}	
}
