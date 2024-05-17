using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_MeleeAttackState : MeleeAttackState
{
	private Hound enemy;
	public Hound_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Hound enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
	{
		this.enemy = enemy;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isAnimationFinished)
		{
			if (isPlayerInMinRange) stateMachine.ChangeState(enemy.PlayerDetectedState);
			else stateMachine.ChangeState(enemy.InvestigateState);
		}
	}
}
