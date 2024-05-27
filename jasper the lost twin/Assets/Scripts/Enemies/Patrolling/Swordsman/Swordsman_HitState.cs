using UnityEngine;

public class Swordsman_HitState : HitState
{
	private Swordsman enemy;
	
	public Swordsman_HitState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_HitState stateData, Swordsman enemy) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}
	
	public override void Enter()
	{
		base.Enter();
		GameObject.Instantiate(stateData.bloodVFX, enemy.transform.position, stateData.bloodVFX.transform.rotation);
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (isStunTimeOver)
		{
			if (performCloseRangeAction)
			{
				stateMachine.ChangeState(enemy.MeleeAttackState);
			}
			else if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.PursueState);
			}
			else
			{
				enemy.InvestigateState.SetFlipNow(true);
				stateMachine.ChangeState(enemy.InvestigateState);
			}
		}
	}
}
