using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    
 public PlayerIdleState(PlayerScript player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName): base(player, playerStateMachine, playerData, animBoolName)
 {
 	
 }
 
 public override void Enter()
 {
 	base.Enter();
 	player.SetVelocityX(0f);
 }
 
 public override void LogicUpdate()
 {
 	base.LogicUpdate();
 	if(xInput != 0) 
 	{
 		stateMachine.ChangeState(player.MoveState);
 	}
 }
 
 
}
