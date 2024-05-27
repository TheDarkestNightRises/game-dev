public class Swordsman_IdleState : IdleState
{
	private Swordsman enemy;
	public Swordsman_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Swordsman enemy) : base(entity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (isPlayerInMinRange)
		{
			stateMachine.ChangeState(enemy.PlayerDetectedState);
		}
		else if (isIdleTimeOver)
		{
			stateMachine.ChangeState(enemy.MoveState);
		}
	}
}
