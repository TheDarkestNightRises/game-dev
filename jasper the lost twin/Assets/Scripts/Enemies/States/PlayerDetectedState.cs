using UnityEngine;

public class PlayerDetectedState : State
{
    protected D_PlayerDetected stateData;
    protected bool isPlayerInMinRange;
    protected bool isPlayerInMaxRange;
    protected bool performLongRangeAction;
    protected bool isInMeleeRange;

    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        performLongRangeAction = false;
        entity.SetVelocityX(0f);
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinRange = entity.CheckPlayerInMinRange();
        isPlayerInMaxRange = entity.CheckPlayerInMaxRange();
        isInMeleeRange = entity.CheckPlayerInMeleeRangeAction();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + stateData.longRangeActionTime)
        {
            performLongRangeAction = true;
        }
    }
}