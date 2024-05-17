using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
	public PlayerDeathState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter()
	{
		base.Enter();
		
		player.RB.AddForce(Vector2.up * playerData.deathKick, ForceMode2D.Impulse);
		player.GenerateImpulse(playerData.deathImpulse);
		player.ApplyFriction();
		player.StartCoroutine(RemovePhysicsAfterDelay(1f));
	}
	
	private IEnumerator RemovePhysicsAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		player.RemovePhysics();
	}
}
