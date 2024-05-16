using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    public float startTime { get; protected set; }

    protected string animBoolName;

    public State(Entity etity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = etity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
	    entity.Anim.SetBool(animBoolName, true);
	    //Debug.Log($"ENEMY STATE: {animBoolName}");
        DoChecks();
    }

    public virtual void Exit()
    {
	    entity.Anim.SetBool(animBoolName, false);
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
