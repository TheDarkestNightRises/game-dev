public class Swordsman_PlayerDetectedState : PlayerDetectedState
{
	private Swordsman _swordsman;
	
	public Swordsman_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Swordsman swordsman) : base(entity, stateMachine, animBoolName, stateData)
	{
		_swordsman = swordsman;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isInMeleeRange)
		{
			stateMachine.ChangeState(_swordsman.MeleeAttackState);
		}
		if (performLongRangeAction)
		{
			_swordsman.IdleState.SetFlipAfterIdle(false);
			stateMachine.ChangeState(_swordsman.PursueState);
		}
		else if (!isPlayerInMaxRange)
		{
			stateMachine.ChangeState(_swordsman.InvestigateState);
		}
	}
}
