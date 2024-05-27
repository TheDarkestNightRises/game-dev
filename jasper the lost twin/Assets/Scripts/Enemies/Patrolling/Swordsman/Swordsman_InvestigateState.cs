public class Swordsman_InvestigateState : InvestigateState
{
	private Swordsman _swordsman;
	
	public Swordsman_InvestigateState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_InvestigateState stateData, Swordsman swordsman) : base(entity, stateMachine, animBoolName, stateData)
	{
		_swordsman = swordsman;
	}
	
	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (isPlayerInMinRange)
		{
			stateMachine.ChangeState(_swordsman.PlayerDetectedState);
		}
		
		else if (areAllFlipsDone)
		{
			stateMachine.ChangeState(_swordsman.MoveState);
		}
	}
}
