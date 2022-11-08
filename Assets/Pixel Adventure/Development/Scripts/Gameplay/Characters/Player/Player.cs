using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    // ———————— fields ————————
    float horizontal = 0;
    bool wantsToJump = false;
    bool hited = false;


    [TitleGroup("Movement")]
    bool canMove = true;
    public bool canDoubleJump = false;
    [SerializeField] float speedMult = 5;
    [SerializeField] float jumpForce = 10;
    [ReadOnly] public Vector2 velocity = Vector2.zero;

    public CollisionStates collisionStates { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Rigidbody2D rigidbody { get; private set; }
    public UnityEvent OnDoubleJump { get; private set; } = new UnityEvent();
    public UnityEvent OnHit { get; private set; } = new UnityEvent();


    // ———————— unity methods ————————
    void Start()
    {
        collisionStates = GetComponent<CollisionStates>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hited)
        { return; }

        GetInputs();
        AvoidGrip();
        TryMove();
        TryJump();
        FlipSprite();
    }


    // ———————— movement methods ————————

    void GetInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        wantsToJump = Input.GetButtonDown("Jump");
    }

    void AvoidGrip()
    {
        canMove = true;

        if (collisionStates.onGround)
            return;

        if (!collisionStates.onWall)
            return;

        if (collisionStates.onLeftWall && horizontal > 0)
            return;

        if (collisionStates.onRightWall && horizontal < 0)
            return;

        canMove = false;
    }

    void TryMove()
    {
        if (!canMove)
            return;

        velocity = rigidbody.velocity;
        velocity.x = horizontal * speedMult;
        rigidbody.velocity = velocity;
    }

    void TryJump()
    {
        if (!wantsToJump)
        {
            return;
        }

        if (collisionStates.onGround)
        {
            velocity.y = jumpForce;
            rigidbody.velocity = velocity;
            return;
        }

        if (canDoubleJump)
        {
            velocity.y = jumpForce;
            rigidbody.velocity = velocity;

            canDoubleJump = false;
            OnDoubleJump.Invoke();
        }
    }

    void FlipSprite()
    {
        spriteRenderer.flipX = horizontal < 0;
    }

    public void Hit()
    {
        hited = true;
        OnHit.Invoke();

        rigidbody.velocity = new Vector2(-jumpForce * 0.75f, jumpForce * 1.75f);
        Destroy(GetComponent<Collider2D>());
    }
}
