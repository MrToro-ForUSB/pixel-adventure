using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // ———————— fields ————————
    Animator animator;
    Player player;
    CollisionStates collisionStates;

    void Start()
    {
        animator = GetComponent<Animator>();
        collisionStates = GetComponent<CollisionStates>();

        player = GetComponent<Player>();
        player.OnDoubleJump.AddListener(OnDoubleJump);
        player.OnHit.AddListener(OnHit);
    }

    // ———————— unity methods ————————
    void Update()
    {
        animator.SetBool("IsRunning", Mathf.Abs(player.velocity.x) >= 0.05f);
        animator.SetBool("IsFalling", player.velocity.y < 0);
        animator.SetBool("OnGround", collisionStates.onGround);
    }

    void OnDoubleJump()
    {
        animator.SetTrigger("DoubleJump");
    }

    void OnHit()
    {
        animator.SetTrigger("Hit");
        Destroy(this);
    }
}
