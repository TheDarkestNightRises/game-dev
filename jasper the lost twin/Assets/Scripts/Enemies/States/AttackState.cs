using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
	protected Transform attackPosition;
	protected bool isAnimationFinished;
	
	public AttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(etity, stateMachine, animBoolName)
	{
		this.attackPosition = attackPosition;
	}
	
	public override void Enter()
	{
		base.Enter();
		isAnimationFinished = false;
	}
	public virtual void TriggerAttack() {}
	
	public virtual void FinishAttack() 
	{
		isAnimationFinished = true;	
	}
}
