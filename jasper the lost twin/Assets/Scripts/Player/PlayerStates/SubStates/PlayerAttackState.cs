using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
	private Weapon weapon;
	
	public PlayerAttackState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
		
	}	
	
	public override void Enter()
	{
		base.Enter();
		
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
	
	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		
		isAbilityDone = true;
	}
}
