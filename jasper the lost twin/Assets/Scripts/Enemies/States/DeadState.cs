using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
	protected D_DeadState stateData;
	private Entity entity;
	
	public DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
		entity = etity;
	}
	
	public override void Enter()
	{
		base.Enter();
		entity.ItemDrop();
		GameSession.instance.AddToScore(stateData.highScoreWorth);
		GameObject.Instantiate(stateData.deathVFX, entity.transform.position, stateData.deathVFX.transform.rotation);
	}
}
