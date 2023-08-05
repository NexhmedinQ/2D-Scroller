using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : States
{
    protected bool isPlayerInAgro;
    protected bool isAnimationOver;
    protected Transform attackPosition;
    protected bool inMeleeRange;
    protected bool inLongRange;
    public BattleState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition) : base(entity, stateMachine, animParam)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();
        entity.zeroVelocity();
        isAnimationOver = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks() {
        base.DoChecks();
        isPlayerInAgro = entity.isPlayerInAgro();
        inMeleeRange = entity.InMeleeRange();
        inLongRange = entity.InRangedAttackRange();
    }
    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {
        isAnimationOver = true;
    }
}
