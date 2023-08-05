using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizard : Entity
{
    public WizardIdleState idleState { get; private set; }
    public WizardMoveState moveState { get; private set; }
    public WizardPlayerDetectedState playerDetectedState {get; private set; }
    public override void Awake()
    {
        base.Awake();
        idleState = new WizardIdleState(this, machine, "idle", this);
        moveState = new WizardMoveState(this, machine, "move", this);
        playerDetectedState = new WizardPlayerDetectedState(this, machine, "detected", this);
    }

    private void Start() {
        machine.Initialize(moveState);
    }
    public override bool isPlayerInAgro()
    { 
        
        bool ret = Physics2D.Raycast(new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x, 0), maxAgroRange, playerLayer) 
            || Physics2D.Raycast(new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x * -1, 0), minAgroRange, playerLayer);
            Debug.Log(ret);
        return ret;
    }
}
