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
    private enum State { idle, running, jumping, falling, hurt }
    private State state = State.idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        /*        if (facingLeft)
                {
                    if(transform.position.x > leftWaypoint)
                    {

                    }
                    else
                    {
                        facingLeft = false;
                    }
                }*/
        anim.SetInteger("state", (int)state);

    }

    void movement()
    {
        if(coll.IsTouchingLayers(ground))
        {
            state = State.jumping;
            Vector3 movement = new Vector3(1, 1f, 0f);
            transform.position += movement * Time.deltaTime * jumpLength;
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
    }
}
