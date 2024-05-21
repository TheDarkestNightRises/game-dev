using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHitState : FlyingState
{
	private bool isStunTimeOver;
	private D_FlyingEnemy stateData;
	
	public FlyingHitState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName, D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
	{
		this.stateData = stateData;	
	}
	
	public override void Enter()
	{
		base.Enter();
		GameObject.Instantiate(stateData.bloodVFX, enemy.transform.position, stateData.bloodVFX.transform.rotation);
		isStunTimeOver = false;
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (Time.time >= startTime + stateData.stunTime) {
			isStunTimeOver = true;
		}
		
		if (isStunTimeOver)
		{
			if (enemy.Chase)
			{
				stateMachine.ChangeState(enemy.ChaseState);
			}
			else
			{
				stateMachine.ChangeState(enemy.ReturnState);
			}
		}
	}
}
