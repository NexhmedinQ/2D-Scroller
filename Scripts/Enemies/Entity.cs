using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine machine;
    public Animator anim { get; private set; }   
    [SerializeField]
    private float wallCheck;
    [SerializeField]
    private float ledgeCheck;
    [SerializeField]
    private Transform playerCheck;
    [SerializeField]
    private LayerMask playerLayer;
    private BoxCollider2D boxCollider;
    [SerializeField]
    private LayerMask groundLayer;
    private Rigidbody2D body;
    [SerializeField]
    private float movementSpeed;

    public virtual void Awake() 
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        machine = new StateMachine();
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

    public bool isPlayerInAgro()
    {
        return false;
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

    protected float facingDirection()
    {
        return transform.localScale.x;
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
}
