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
	}
	
	public bool CanJump()
	{
		if (ammountOfJumpsLeft > 0) 
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public void ResetAmmountOfJumpsLeft() => ammountOfJumpsLeft = playerData.amountOfJumps;
	
	public void DecreaseAmmountOfJumpsLeft()
	{
		ammountOfJumpsLeft--;
		Debug.Log($"Ammounts of jumps left : {ammountOfJumpsLeft}");
	}
}
