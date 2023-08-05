using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : States
{
    protected float minIdle = 0.5f;
    protected float maxIdle = 1.5f;
    protected float randomIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInAgro;

    public IdleState(Entity entity, StateMachine stateMachine, string animParam) : base(entity, stateMachine, animParam)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isIdleTimeOver = false;
        randomIdle = Random.Range(minIdle, maxIdle);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + randomIdle)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public override void DoChecks() {
        isPlayerInAgro = entity.isPlayerInAgro();
    }
}
