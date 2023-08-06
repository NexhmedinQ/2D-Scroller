using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMeleeState : MeleeAttackState
{
    private EnemyWizard wizard;
    public WizardMeleeState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition, EnemyWizard wizard) : base(entity, stateMachine, animParam, attackPosition)
    {
        this.wizard = wizard;
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationOver && isPlayerInAgro) 
        {
            machine.ChangeState(wizard.battleState);
        } else if (isAnimationOver && !isPlayerInAgro) 
        {
            machine.ChangeState(wizard.moveState);
        }
    }
}
