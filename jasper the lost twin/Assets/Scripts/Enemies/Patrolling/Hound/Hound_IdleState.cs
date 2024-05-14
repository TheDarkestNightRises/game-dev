using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound_IdleState : IdleState
{
	private Hound enemy;
	public Hound_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Hound enemy) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (isIdleTimeOver)
		{
			stateMachine.ChangeState(enemy.MoveState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
