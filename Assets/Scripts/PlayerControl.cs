
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector3;
using UnityEngine.Tilemaps;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    private TilemapCollider2D compCol;
    public BoxCollider2D charCol;
    private bool isJumping;
    [SerializeField] private LayerMask ground; 


    private enum State { idle, running, jumping, falling }
    private State state = State.idle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();

    }

    private bool OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            rb.velocity = Vector2.zero;
            return true;
        }
        return false;
    }
    
    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 5f;
        float hDirection = Input.GetAxis("Horizontal");
        float vDirection = Input.GetAxis("Vertical");


        Jump();



        Vector3 movement = new Vector3(hDirection, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (hDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            if (isJumping) state = State.jumping;
            else if (!coll.IsTouchingLayers(ground) && isJumping == false)
            {
                state = State.falling;
            }
            else
            {
                state = State.running;
                isJumping = false;
            }
        }
        else if (hDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
            if (isJumping) state = State.jumping;
            else if (!coll.IsTouchingLayers(ground) && isJumping == false)
            {
                state = State.falling;
            }
            else
            {
                state = State.running;
                isJumping = false;
            }
        }
        else if (!coll.IsTouchingLayers(ground) && isJumping == false)
        {
            state = State.falling;
        }
        else
        {
            if (isJumping) state = State.jumping;
            else 
            {
                state = State.idle;
                isJumping = false;
            }
            
        }
        anim.SetInteger("state", (int)state);

    }



    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && coll.IsTouchingLayers(ground))
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            isJumping = true;
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
            else
            {
                state = State.jumping;
            }
        }

    }
}

