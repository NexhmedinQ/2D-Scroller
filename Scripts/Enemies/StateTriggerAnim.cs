using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTriggerAnim : MonoBehaviour
{
    public BattleState battle;

    public void TriggerAttack() {
        battle.TriggerAttack();
    }

    public void FinishAttack() {
        battle.FinishAttack();
    }
}
