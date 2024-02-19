using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
 protected int xInput;
 
 public PlayerGroundState(PlayerScript player, PlayerStateMachine playerStateMachine, PlayerData playerData, string animBoolName): base(player, playerStateMachine, playerData, animBoolName)
 {
 	
 }
 
 public override void LogicUpdate()
 {
 	base.LogicUpdate();
 	xInput = player.InputHandler.InputX;
 }
}
