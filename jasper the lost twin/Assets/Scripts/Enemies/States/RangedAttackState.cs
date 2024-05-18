using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : AttackState
{
	protected D_RangedAttackState stateData;
	protected GameObject projectile;
	protected Projectile projectileScript; 
	
	public RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData) : base(entity, stateMachine, animBoolName, attackPosition)
	{
		this.stateData = stateData;
	}
	
	public override void TriggerAttack()
	{
		base.TriggerAttack();
		
		projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
		projectileScript = projectile.GetComponent<Projectile>();
		projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravel, stateData.projectileDamage);
	}
}
