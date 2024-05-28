public class PlayerGroundedState : PlayerState
{
	protected int xInput;
	protected int yInput;
	private bool jumpInput;
	private bool dashInput;
	
	public PlayerGroundedState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}
	
	public override void Enter()
	{
		base.Enter();
		player.JumpState.ResetAmmountOfJumpsLeft();
		player.DashState.ResetCanDash();
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();

		xInput = player.InputHandler.InputX;
		yInput = player.InputHandler.InputY;		
		jumpInput = player.InputHandler.JumpInput;
		dashInput = player.InputHandler.DashInput;
		
		if (player.InputHandler.PrimaryAttackInput)
		{
			stateMachine.ChangeState(player.PrimaryAttackState);
		}
		else if (jumpInput && player.JumpState.CanJump())
		{
			player.InputHandler.UseJumpInput();
			stateMachine.ChangeState(player.JumpState);
		}
		else if(!player.CheckIfTouchingGround() && !player.CheckIfTouchingLadder())
		{
			player.InAirState.StartCoyote();
			stateMachine.ChangeState(player.InAirState);
		}
		else if(dashInput && player.DashState.CheckIfCanDash())
		{
			stateMachine.ChangeState(player.DashState);
		}
		else if(yInput != 0 && player.CheckIfTouchingLadder())
		{
			stateMachine.ChangeState(player.ClimbState);
		}
		
	}
}
