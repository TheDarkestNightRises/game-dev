public class FlyingAttackState : FlyingState
{
    protected D_FlyingEnemy stateData;
    protected bool IsPlayerInMinRange;

    public FlyingAttackState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName,
        D_FlyingEnemy stateData) : base(enemy, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsPlayerInMinRange = enemy.isPlayerInMinRange();
    }

    public void PerformAttack()
    {
        if (IsPlayerInMinRange)
        {
            var damageable = enemy.Player.GetComponent<IDamageable>();
            damageable.Damage(new DamageData(stateData.damage, enemy.gameObject));
        }

        stateMachine.ChangeState(enemy.ChaseState);
    }
}