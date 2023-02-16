using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
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
    
    private void Start() 
    {
        anim = GetComponent<Animator>();    
        anim.SetBool("canAttack", combatEnabled);
    }
    private void Update() 
    {
        checkCombatInput();
        checkAttacks();
    }
    
    private void checkCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
        }
    }

    private void checkAttacks()
    {
        if (gotInput)
        {
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
            }
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
            detectedObjects[i].transform.parent.SendMessage("Damage", attack1Damage);
            // instantiate hit particle
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
}
