using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBattleState : BattleState
{
    EnemyWizard wizard;
    public WizardBattleState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition, EnemyWizard wizard) : base(entity, stateMachine, animParam, attackPosition)
    {
        this.wizard = wizard;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (inMeleeRange)
        {
            if (Time.time >= randomCD + startTime)
            {
                float rand = Random.Range(0, 5);
                if (rand > 1.5)
                {
                    machine.ChangeState(wizard.meleeState);
                }
                else 
                {
                    // change to ranged state when finished implementation
                    machine.ChangeState(wizard.playerDetectedState);
                }
            }
        } else if (inLongRange)
        {
            // change to ranged state when finished implementation
            if (Time.time >= randomCD + startTime)
            {
                machine.ChangeState(wizard.playerDetectedState);
            }
        } else if (isPlayerInAgro) {
            machine.ChangeState(wizard.playerDetectedState);
        } else {
            machine.ChangeState(wizard.moveState);
        }
    }
}
