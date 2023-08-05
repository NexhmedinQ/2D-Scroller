using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : BattleState
{
    public RangedAttackState(Entity entity, StateMachine stateMachine, string animParam, Transform attackPosition) : base(entity, stateMachine, animParam, attackPosition)
    {
    }


}
