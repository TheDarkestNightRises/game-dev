public class PlayerAbilityState : PlayerState
{
	public bool isAbilityDone;
	private bool isGrounded;
	
	public PlayerAbilityState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
	}
	
	public override void Enter()
	{
		base.Enter();
		
		isAbilityDone = false;
	}
	
	public override void DoChecks()
	{
		base.DoChecks();
		
		isGrounded = player.CheckIfTouchingGround();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isAbilityDone)
		{
			if (isGrounded && player.CurrentVelocity.y < 0.01f)
			{
				stateMachine.ChangeState(player.IdleState);
			}
			else
			{
				stateMachine.ChangeState(player.InAirState);
			}
		}
	}
}
