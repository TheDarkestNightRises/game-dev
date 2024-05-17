using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_HitState : HitState
{
	private Hound enemy;
	
	public Hound_HitState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_HitState stateData, Hound enemy) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (isStunTimeOver)
		{
			if (performCloseRangeAction)
			{
				stateMachine.ChangeState(enemy.MeleeAttackState);
			}
			else if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.PursueState);
			}
			else
			{
				stateMachine.ChangeState(enemy.InvestigateState);
			}
		}
	}
}
