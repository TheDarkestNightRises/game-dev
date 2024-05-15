using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
	protected D_MeleeAttack stateData;
	protected AttackInfo attackInfo;
	
	public MeleeAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName,Transform attackPosition, D_MeleeAttack stateData) : base(etity, stateMachine, animBoolName, attackPosition)
	{
		this.stateData = stateData;
	}
	
	public override void Enter()
	{
		base.Enter();
		
		attackInfo.damage = stateData.attackDamage;
		attackInfo.attackPosition = entity.transform.position;
	}
	
	public override void TriggerAttack()
	{
		base.TriggerAttack();
		
		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);
		foreach (Collider2D colider in detectedObjects)
		{
			colider.transform.SendMessage("Damage", attackInfo);
		}
	}
}
