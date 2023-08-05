using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardPlayerDetectedState : PlayerDetectedState
{
    private EnemyWizard wizard;
    private float detectTime;
    public WizardPlayerDetectedState(Entity entity, StateMachine stateMachine, string animParam, EnemyWizard wizard) : base(entity, stateMachine, animParam)
    {
        this.wizard = wizard;
    }

    public override void Enter()
    {
        base.Enter();
        detectTime = Random.Range(0.2f, 0.5f);
        entity.zeroVelocity();
        if (facingRight && !playerOnRight || !facingRight & playerOnRight) {
            entity.Flip();
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + detectTime)
        {
            if (isPlayerInAgro) {
                machine.ChangeState(wizard.moveState);
            } else {
                machine.ChangeState(wizard.idleState);
            }
        }
        Debug.Log(facingRight);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void DoChecks() {
        base.DoChecks();
        if (facingRight && !playerOnRight || !facingRight && playerOnRight) {
            entity.Flip();
        }
    }


}
