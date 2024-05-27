using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;
    private Entity entity;

    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
        this.entity = entity;
    }

    public override void Enter()
    {
        base.Enter();
        entity.ItemDrop();
        entity.RB.simulated = false;
        GameSession.instance.AddToScore(stateData.highScoreWorth);
        GameObject.Instantiate(stateData.deathVFX, entity.transform.position, stateData.deathVFX.transform.rotation);
    }
}