using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : States
{
    public MoveState(Entity entity, StateMachine stateMachine, string animParam) : base(entity, stateMachine, animParam)
    {
    }

    public override void Enter()
    {
        base.Enter();
        entity.setVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.setVelocity();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
