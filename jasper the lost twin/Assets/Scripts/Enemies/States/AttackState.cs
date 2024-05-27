using UnityEngine;

public class AttackState : State
{
    protected Transform attackPosition;
    protected bool isAnimationFinished;
    protected bool isPlayerInMinRange;

    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinRange = entity.CheckPlayerInMinRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        entity.SetVelocityX(0f);
    }

    public virtual void TriggerAttack()
    {
    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}