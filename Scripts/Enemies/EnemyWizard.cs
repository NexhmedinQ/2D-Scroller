using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : Entity
{
    public WizardIdleState idleState { get; private set; }
    public WizardMoveState moveState { get; private set; }
    public override void Awake()
    {
        base.Awake();
        idleState = new WizardIdleState(this, machine, "idle", this);
        moveState = new WizardMoveState(this, machine, "move", this);
    }

    private void Start() {
        machine.Initialize(moveState);
    }
}
