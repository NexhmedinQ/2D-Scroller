using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    protected StateMachine machine;
    protected Entity entity;
    protected string animParam;
    public float startTime { get; protected set; }

    public States(Entity entity, StateMachine stateMachine, string animParam)
    {
        this.entity = entity;
        this.machine = stateMachine;
        this.animParam = animParam;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animParam, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animParam, false);
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
