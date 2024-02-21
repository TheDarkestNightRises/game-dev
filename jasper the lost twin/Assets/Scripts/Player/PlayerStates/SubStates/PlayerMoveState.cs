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
		player.SetVelocityX(playerData.movementVelocity * xInput);
		
		if (xInput == 0)
		{
			stateMachine.ChangeState(player.IdleState);
		}
	}
}
