using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Frog : Enemy
{
    private Collider2D coll;

    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float leftWaypoint;
    [SerializeField] private float rightWaypoint;
    public Rigidbody2D rb;
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;
    private enum State { idle, jumping, falling }
    private State state = State.idle;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftWaypoint)
        {
            transform.localScale = new Vector2(-1, 1);
            facingLeft = false;
            state = State.jumping;
        }
        else if(transform.position.x >= rightWaypoint)
        {
            transform.localScale = new Vector2(1, 1);
            facingLeft = true;
            state = State.jumping;
        }
        if (coll.IsTouchingLayers(ground)) state = State.idle;
        else if (rb.velocity.y > .1f && !coll.IsTouchingLayers(ground)) state = State.jumping;
        else if (rb.velocity.y < .1f && !coll.IsTouchingLayers(ground)) state = State.falling;

        anim.SetInteger("state", (int)state);

    }

    void movement()
    {
        if(coll.IsTouchingLayers(ground) && facingLeft)
        {       
            rb.velocity = new Vector2(-jumpLength, jumpHeight);
        }
        else if(coll.IsTouchingLayers(ground) && !facingLeft)
        {
            rb.velocity = new Vector2(jumpLength, jumpHeight);          
        }

    }
}
