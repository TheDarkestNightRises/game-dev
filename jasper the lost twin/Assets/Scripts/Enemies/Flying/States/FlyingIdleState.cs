using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingIdleState : FlyingState
{
	public FlyingIdleState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName, D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
	{
		
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (enemy.Chase)
		{
			stateMachine.ChangeState(enemy.ChaseState);
		}
	}
}
