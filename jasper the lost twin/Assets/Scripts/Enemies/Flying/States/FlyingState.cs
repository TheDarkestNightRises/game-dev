using UnityEngine;

public class FlyingState
{
    protected FlyingStateMachine stateMachine;
    protected FlyingEnemy enemy;
    public float startTime { get; protected set; }

    protected string animBoolName;

    public FlyingState(FlyingEnemy enemy, FlyingStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        enemy.Anim.SetBool(animBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
    }
}