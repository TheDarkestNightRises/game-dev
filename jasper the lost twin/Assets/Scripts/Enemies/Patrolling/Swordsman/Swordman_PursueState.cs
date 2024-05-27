public class Swordman_PursueState : PursueState
{
	private Swordsman _swordsman;
	
	public Swordman_PursueState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PursueState stateData, Swordsman swordsman) : base(entity, stateMachine, animBoolName, stateData)
	{
		this._swordsman = swordsman;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isInMeleeRange) 
		{
			stateMachine.ChangeState(_swordsman.MeleeAttackState);
		}
		else if (!isDetectingLedge || isDetectingWall)
		{
			stateMachine.ChangeState(_swordsman.InvestigateState);
		}
		else if (isPursueOver)
		{
			if (isPlayerInMinAgroRange) stateMachine.ChangeState(_swordsman.PlayerDetectedState);
			stateMachine.ChangeState(_swordsman.MoveState);
		}
	}
}
