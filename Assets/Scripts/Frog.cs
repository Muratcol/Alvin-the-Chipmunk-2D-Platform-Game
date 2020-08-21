using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Collider2D coll;

    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float leftWaypoint;
    [SerializeField] private float rightWaypoint;
    public Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;
    [SerializeField] private float idleDuration = 2.0f;
    private bool keepMoving = true;
    private enum State { idle, jumping, falling }
    private State state = State.idle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
