using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator an;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 18f;
    private float dirX = 0f;

    private enum MovementState {idle, running, jumping, falling}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && IsGrounded())
            GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, jumpSpeed);
        UpdateAnimationState();
    }
    
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f) {
            state = MovementState.running;
            sprite.flipX= false ;
        }
        else if (dirX < 0f) {
            state = MovementState.running;
            sprite.flipX= true;
        }
        else {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }

        if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        an.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
