public class PlayerClimbState : PlayerState
{
	public PlayerClimbState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{

	}
	
	public override void Enter()
	{
		base.Enter();
		player.RB.gravityScale = 0;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		var inputY = player.InputHandler.InputY;
		var inputX = player.InputHandler.InputX;


		var jumpInput = player.InputHandler.JumpInput;
		
		if(inputY == 0)
		{
			stateMachine.ChangeState(player.IdleState);
		}
			
		else if (jumpInput && player.JumpState.CanJump())
		{
			// Transition to Jumping State if jump input is detected
			stateMachine.ChangeState(player.JumpState);
		}
		
		else if (!player.CheckIfTouchingLadder())
		{
			stateMachine.ChangeState(player.IdleState);
		}
		
		else if (inputX != 0)
		{
			stateMachine.ChangeState(player.MoveState);
		}

		player.SetVelocityY(inputY * playerData.climbSpeed);
	}

}
