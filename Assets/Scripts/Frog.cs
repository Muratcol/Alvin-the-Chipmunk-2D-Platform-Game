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
/*        movement();*/
        if (transform.position.x <= leftWaypoint)
        {
            facingLeft = false;        
        }
        else if(transform.position.x >= rightWaypoint)
        {
            facingLeft = true;
        }
        movement();
        anim.SetInteger("state", (int)state);

    }

    void movement()
    {
        if(coll.IsTouchingLayers(ground) && facingLeft)
        {
            state = State.jumping;
            Vector3 movement = new Vector3(-1f, 4f, 0f);
            transform.position += movement * Time.deltaTime * jumpLength;
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(coll.IsTouchingLayers(ground) && !facingLeft)
        {
            Vector3 movement = new Vector3(1f, 4f, 0f);
            transform.position += movement * Time.deltaTime * jumpLength;
        }
    }
}
