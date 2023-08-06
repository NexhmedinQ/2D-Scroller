using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour, IDamage
{

    [SerializeField]
    private bool combatEnabled;
    private bool gotInput, isAttacking, isFirstAttack;
    private float lastInputTime = Mathf.NegativeInfinity;
    [SerializeField]
    private float inputTimer, attack1Radius, attack1Damage;
    private Animator anim;
    [SerializeField]
    private Transform attack1HitBox;
    [SerializeField]
    private LayerMask damageable;
    [SerializeField]
    private float maxHealth;
    private float currHealth;
    
    private void Start() 
    {
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        CombatHandler.Instance.TakeDamage += HandleAttack;
        currHealth = maxHealth;
    }
    private void Update() 
    {
        checkCombatInput();
        checkAttacks();
    }

    private void OnDestroy() {
        CombatHandler.Instance.TakeDamage -= HandleAttack;
    }
    
    private void checkCombatInput()
    {
        if (Input.GetMouseButtonDown(0) && combatEnabled)
        {
            gotInput = true;
            lastInputTime = Time.time;
        }
    }

    private void checkAttacks()
    {
        if (gotInput && !isAttacking)
        {
            gotInput = false;
            isAttacking = true;
            isFirstAttack = !isFirstAttack;
            anim.SetBool("attack1", true);
            anim.SetBool("firstAttack", isFirstAttack);
            anim.SetBool("isAttacking", isAttacking);
        }
        if (Time.time >= lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

    private void checkAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBox.position, attack1Radius, damageable);
        for (int i = 0; i < detectedObjects.Length; i++)
        {
            IDamage enemy = detectedObjects[i].GetComponent<IDamage>();
            if (enemy != null) 
            {
                CombatHandler.Instance.PerformAttack(enemy, attack1Damage);
                // instantiate hit particle
            }
        }
    }

    private void finishAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(attack1HitBox.position, attack1Radius);
    }

    private void HandleAttack(IDamage target, float damage) {
        if (this == target) 
        {
            Damage(damage);
        }
    }

    public void Damage(float damage)
    {
        currHealth = currHealth - damage;
        if (currHealth < 0) 
        {
            // dead
        }
    }
}
