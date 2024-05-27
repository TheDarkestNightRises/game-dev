using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
	protected D_MeleeAttack stateData;
	
	public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName,Transform attackPosition, D_MeleeAttack stateData) : base(entity, stateMachine, animBoolName, attackPosition)
	{
		this.stateData = stateData;
	}

	public override void TriggerAttack()
	{
		base.TriggerAttack();
		
		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);
		foreach (Collider2D collider in detectedObjects)
		{
			var damageable = collider.GetComponent<IDamageable>();

			if (damageable != null) {
				damageable.Damage(new DamageData(stateData.attackDamage, entity.gameObject));
			}
		}
	}
}
