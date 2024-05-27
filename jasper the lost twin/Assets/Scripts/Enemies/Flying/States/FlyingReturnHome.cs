using UnityEngine;

public class FlyingReturnState : FlyingState
{
    protected D_FlyingEnemy stateData;

    public FlyingReturnState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName,
        D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        var startingPosition = enemy.startingPoint.position;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, startingPosition,
            stateData.flightSpeed * Time.deltaTime);
        enemy.Flip(startingPosition);
        if (Vector2.Distance(enemy.transform.position, startingPosition) <= 0.1f)
        {
            enemy.Returning = false;
            stateMachine.ChangeState(enemy.IdleState);
        }

        if (enemy.Chase)
        {
            stateMachine.ChangeState(enemy.ChaseState);
        }
    }
}