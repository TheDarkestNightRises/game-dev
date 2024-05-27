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

		if (xInput == 0)
		{
			stateMachine.ChangeState(player.IdleState);
		}
	}
	
	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
		float targetSpeed = playerData.movementVelocity * xInput;
		float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? playerData.runAccell : playerData.decAccell;
		float speedDif = targetSpeed - player.RB.velocity.x;
		float movement = speedDif * accelRate;
		player.RB.AddForce(movement * Vector2.right, ForceMode2D.Force);
	}
}
