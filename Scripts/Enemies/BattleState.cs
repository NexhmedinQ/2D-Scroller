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
    protected float randomCD;
    public BattleState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition) : base(entity, stateMachine, animParam)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();
        entity.stateToAnim.battle = this;
        entity.zeroVelocity();
        isAnimationOver = false;
        randomCD = Random.Range(entity.meleeCd, 1);
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
        bool facingRight = entity.facingDirection() > 0;
        bool playerRight = entity.PlayerOnRight();
        if (facingRight && ! playerRight || !facingRight && playerRight) 
        {
            entity.Flip();
        }
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
