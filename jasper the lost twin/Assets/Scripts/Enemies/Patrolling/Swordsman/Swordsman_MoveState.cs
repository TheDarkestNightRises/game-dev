public class Swordsman_MoveState : MoveState
{
	private Swordsman _swordsman;
	
	public Swordsman_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Swordsman swordsman) : base(entity, stateMachine, animBoolName, stateData)
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

		else if (isDetectingWall || !isDetectingLedge)
		{
			_swordsman.IdleState.SetFlipAfterIdle(true);
			stateMachine.ChangeState(_swordsman.IdleState);
		}
	}
}
