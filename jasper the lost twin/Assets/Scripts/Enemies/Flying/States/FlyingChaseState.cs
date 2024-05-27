using UnityEngine;

public class FlyingChaseState : FlyingState
{
    protected D_FlyingEnemy stateData;

    public FlyingChaseState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName,
        D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        var playerTransform = enemy.Player.transform.position;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, playerTransform,
            stateData.flightSpeed * Time.deltaTime);
        enemy.Flip(playerTransform);
        if (enemy.isPlayerInMinRange())
        {
            stateMachine.ChangeState(enemy.AttackState);
        }

        if (!enemy.Chase)
        {
            stateMachine.ChangeState(enemy.ReturnState);
        }
    }
}