using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    public static CombatHandler Instance { get; private set; }
    private void Awake()
    {
        Debug.Log("is being instantiated");
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public event Action<IDamage, float> TakeDamage;

    public void PerformAttack(IDamage target, float damage) {
        TakeDamage?.Invoke(target, damage);
    }
}
