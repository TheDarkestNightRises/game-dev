public class PlayerAttackState : PlayerAbilityState
{
	private Weapon weapon;
	
	public PlayerAttackState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}	
	
	public override void Enter()
	{
		base.Enter();
		UpdatePlayerDirectionAndVelocity();
		weapon.EnterWeapon();
	}
	
	public override void Exit()
	{
		base.Exit();
		weapon.ExitWeapon();
	}
	
	public void SetWeapon(Weapon weapon)
	{
		this.weapon = weapon;
		weapon.InitWeapon(this);
	}
	
	private void UpdatePlayerDirectionAndVelocity()
	{
		var xInput = player.InputHandler.InputX;

		if (xInput != 0)
		{
			// Update facing direction based on input
			player.CheckIfShouldFlip(xInput);

			// Set velocity based on facing direction
			player.SetVelocityX(playerData.speedWhileAttacking * player.FacingDirection);
		}
		else
		{
			player.SetVelocityX(0f);
		}
	}

	
	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		
		isAbilityDone = true;
	}
}
