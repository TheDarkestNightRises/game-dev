public class MoveState : State
{
    protected D_MoveState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinRange;

    public MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.CheckWall();
        isPlayerInMinRange = entity.CheckPlayerInMinRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocityX(stateData.movementSpeed);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.SetVelocityX(stateData.movementSpeed);
    }
}