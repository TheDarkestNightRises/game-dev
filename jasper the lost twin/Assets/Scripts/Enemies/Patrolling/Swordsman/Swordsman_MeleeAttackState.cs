using UnityEngine;

public class Swordsman_MeleeAttackState : MeleeAttackState
{
	private Swordsman enemy;
	public Swordsman_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Swordsman enemy) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
	{
		this.enemy = enemy;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isAnimationFinished)
		{
			if (isPlayerInMinRange) stateMachine.ChangeState(enemy.PlayerDetectedState);
			else stateMachine.ChangeState(enemy.InvestigateState);
		}
	}
}
