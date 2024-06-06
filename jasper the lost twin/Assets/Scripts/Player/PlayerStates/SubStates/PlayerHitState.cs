using System.Collections;
using UnityEngine;

public class PlayerHitState : PlayerState
{	
	public PlayerHitState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter() {
		base.Enter();
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
			player.SpriteRenderer.color = new Color(1, 0, 0, 0.55f); 
			yield return new WaitForSeconds(playerData.invincibilityTime / (playerData.numberOfFlashes * 2));
			player.SpriteRenderer.color = Color.white; 
			yield return new WaitForSeconds(playerData.invincibilityTime / (playerData.numberOfFlashes * 2));
		}

		player.IsInvincibile = false;
		player.SpriteRenderer.color = Color.white; 
	}
}
