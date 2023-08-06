using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamage
{
    public StateMachine machine;
    public Animator anim { get; private set; }   
    [SerializeField]
    private float wallCheck;
    [SerializeField]
    private float ledgeCheck;
    // [SerializeField]
    // private Transform playerCheck;
    [SerializeField]
    public LayerMask playerLayer;
    protected BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask groundLayer;
    private Rigidbody2D body;
    [SerializeField]
    private float movementSpeed;
    private float currentHealth;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    protected float minAgroRange;
    [SerializeField]
    protected float maxAgroRange;
    [SerializeField]
    protected float meleeRange;
    [SerializeField]
    protected float longRange;
    [SerializeField]
    public float meleeDamage;
    [SerializeField]
    public float meleeRadius;
    [SerializeField]
    protected Transform attackPosition;
    public StateTriggerAnim stateToAnim;
    [SerializeField]
    public float meleeCd;
    [SerializeField]
    public float rangedCd;

    public virtual void Awake() 
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        machine = new StateMachine();
        stateToAnim = GetComponent<StateTriggerAnim>();
    }
    public virtual void Start() {
        CombatHandler.Instance.TakeDamage += HandleAttack;
    }

    public virtual void Update()
    {
        machine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        machine.currentState.PhysicsUpdate();
    }

    public bool isPlayerInBattleRange()
    {
        return false;
    } 

    public virtual bool isPlayerInAgro()
    {
        return Physics2D.Raycast(new Vector2(boxCollider.bounds.max.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x, 0), wallCheck, playerLayer);
    }

    public bool wallCollision()
    {
        if (facingDirection() == 1)
        {
            return Physics2D.Raycast(new Vector2(boxCollider.bounds.max.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x, 0), wallCheck, groundLayer);
        }
        else
        {
            return Physics2D.Raycast(new Vector2(boxCollider.bounds.min.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x, 0), wallCheck, groundLayer);
        }
    }
    

    public bool noGround()
    {
        if (facingDirection() > 0)
        {
            return !Physics2D.Raycast(new Vector2(boxCollider.bounds.max.x, boxCollider.bounds.min.y), Vector2.down, ledgeCheck, groundLayer);
        }
        else
        {
            return !Physics2D.Raycast(new Vector2(boxCollider.bounds.min.x, boxCollider.bounds.min.y), Vector2.down, ledgeCheck, groundLayer);
        }
    }
    // positive is facing right
    public float facingDirection()
    {
        return transform.localScale.x;
    }

    public bool InMeleeRange() {
        return Physics2D.Raycast(new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x, 0), meleeRange, playerLayer);
    }

    public bool InRangedAttackRange() {
        return Physics2D.Raycast(new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.center.y), new Vector2(transform.localScale.x, 0), longRange, playerLayer);
    }

    public bool PlayerOnRight() {
        return Physics2D.Raycast(new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.center.y), new Vector2(1, 0), maxAgroRange, playerLayer);
    }

    public void setVelocity()
    {
        body.velocity = new Vector2(movementSpeed * transform.localScale.x, 0);
    }

    public void zeroVelocity()
    {
        body.velocity = Vector2.zero;
    }

    public void Flip()
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 0.5f, 0.5f);
        } else
        {
            transform.localScale = Vector3.one * transform.localScale.x * -1;
        }
        
    }

    public virtual void Damage(float damage)
    {
        currentHealth -= damage;
    }

    protected virtual void HandleAttack(IDamage target, float damage)
    {
        if (this == target) {
            Damage(damage);
        }
    }

   
}
