public class PlayerIdleState : PlayerGroundedState
{
	public PlayerIdleState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		if (xInput != 0)
		{
			stateMachine.ChangeState(player.MoveState);
		}
	}
	
	public override void PhysicsUpdate()
	{
		player.ApplyFriction();
	}
}
