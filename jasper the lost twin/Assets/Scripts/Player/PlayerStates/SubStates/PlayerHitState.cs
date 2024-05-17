using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{	
	public PlayerHitState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter() {
		base.Enter();
		player.IsInvincibile = true; 
		player.SetVelocityX(0f);
	}

	public override void LogicUpdate() {
		base.LogicUpdate();
		player.SetVelocityX(0f);
		
		if (Time.time >= startTime + playerData.stunTime) {
			stateMachine.ChangeState(player.IdleState);
		}
	}
	
	public override void Exit()
	{
		base.Exit();
		player.StartCoroutine(RemoveInvincibilityAfterDelay(playerData.invincibilityTime));
	}
	
	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
		player.ApplyFriction();
	}
	
	private IEnumerator RemoveInvincibilityAfterDelay(float delay) {
		yield return new WaitForSeconds(delay);
		player.IsInvincibile = false; 
	}
}
