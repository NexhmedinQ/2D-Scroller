using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : BattleState
{
    public MeleeAttackState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition) : base(entity, stateMachine, animParam, attackPosition)
    {
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
    }
    public override void TriggerAttack()
    {
        base.TriggerAttack();
        Collider2D damagedObects = Physics2D.OverlapCircle(attackPosition.position, entity.meleeRadius, entity.playerLayer);
        IDamage player = damagedObects.GetComponent<IDamage>();
        if (player != null) 
        {
            CombatHandler.Instance.PerformAttack(player, entity.meleeDamage);
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
