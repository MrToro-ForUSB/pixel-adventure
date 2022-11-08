using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CollisionStates : MonoBehaviour
{
    // ———————— fields ————————

    public enum Sides
    {
        None,
        Right,
        Left
    }

    [TitleGroup("Layers")]
    [SerializeField] LayerMask groundLayer;


    [TitleGroup("States")]
    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public Sides wallSide;


    [TitleGroup("Collision")]
    [SerializeField] float collisionRadius = 0.25f;
    [SerializeField] Vector2 bottomOffset, rightOffset, leftOffset;
    [SerializeField] Color debugNonCollisionColor = Color.red;
    [SerializeField] Color debugCollisionColor = Color.green;


    // ———————— unity methods ————————

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, groundLayer);
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, groundLayer);

        onWall = onRightWall || onLeftWall;
        wallSide = onWall ? (onRightWall ? Sides.Right : Sides.Left) : Sides.None;
    }

    void OnDrawGizmos()
    {

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.color = onGround ? debugCollisionColor : debugNonCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);

        Gizmos.color = onRightWall ? debugCollisionColor : debugNonCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);

        Gizmos.color = onLeftWall ? debugCollisionColor : debugNonCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
