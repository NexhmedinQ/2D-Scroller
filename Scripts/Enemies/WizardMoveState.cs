using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMoveState : MoveState
{

    private EnemyWizard wizard;
    public WizardMoveState(Entity entity, StateMachine stateMachine, string animParam, EnemyWizard wizard) : base(entity, stateMachine, animParam)
    {
        this.wizard = wizard;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if ( entity.wallCollision() || entity.noGround())
        {
            machine.ChangeState(wizard.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
