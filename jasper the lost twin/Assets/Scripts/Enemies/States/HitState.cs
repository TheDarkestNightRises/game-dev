using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : State
{
	protected D_HitState stateData;
	protected bool isStunTimeOver;
	protected bool performCloseRangeAction;
	protected bool isPlayerInMinAgroRange;

	public HitState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_HitState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
	}
	
	public override void DoChecks() {
		base.DoChecks();

		performCloseRangeAction = entity.CheckPlayerInMeleeRangeAction();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinRange();
	}

	public override void Enter() {
		base.Enter();

		isStunTimeOver = false;
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (Time.time >= startTime + stateData.stunTime) {
			isStunTimeOver = true;
		}
	}
}
