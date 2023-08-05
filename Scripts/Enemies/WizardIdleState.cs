using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIdleState : IdleState
{
    private EnemyWizard wizard;
    public WizardIdleState(Entity entity, StateMachine stateMachine, string animParam, EnemyWizard wizard) : base(entity, stateMachine, animParam)
    {
        this.wizard = wizard;
    }

    public override void Enter()
    {
        base.Enter();
        entity.zeroVelocity();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInAgro) {
            machine.ChangeState(wizard.playerDetectedState);
        } else if (isIdleTimeOver) {
            machine.ChangeState(wizard.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        entity.Flip();
    }


}
