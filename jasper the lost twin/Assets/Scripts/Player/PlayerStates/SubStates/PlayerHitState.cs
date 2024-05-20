using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{	
	protected SpriteRenderer spriteRender;
	public PlayerHitState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter() {
		base.Enter();
		player.SetVelocityX(0f);
		spriteRender = player.GetComponent<SpriteRenderer>();
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
		player.StartCoroutine(Invincibility());
	}
	
	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
		player.ApplyFriction();
	}
	
	private IEnumerator Invincibility()
	{
		player.IsInvincibile = true; 
		for (int i = 0; i < playerData.numberOfFlashes; i++) {
			spriteRender.color = new Color(1, 0, 0, 0.55f); 
			yield return new WaitForSeconds(playerData.invincibilityTime / (playerData.numberOfFlashes * 2));
			spriteRender.color = Color.white; 
			yield return new WaitForSeconds(playerData.invincibilityTime / (playerData.numberOfFlashes * 2));
		}

		player.IsInvincibile = false;
		spriteRender.color = Color.white; 
	}
}
