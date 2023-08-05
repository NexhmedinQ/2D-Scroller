using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : BattleState
{
    public MeleeState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition) : base(entity, stateMachine, animParam, attackPosition)
    {
    }

}
