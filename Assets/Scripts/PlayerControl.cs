
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
    
    [SerializeField] private LayerMask ground;
    [SerializeField] private int cherries = 0;
    [SerializeField] private float moveSpeed = 5f;


    private bool isJumping;
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
    private void Update()
    {
        Movement();
        Jump();
        anim.SetInteger("state", (int)state);
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        float vDirection = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hDirection, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (hDirection < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            if (isJumping && rb.velocity.y < .1f && !coll.IsTouchingLayers(ground)) state = State.falling;
            else if (isJumping) state = State.jumping;
            else if (!coll.IsTouchingLayers(ground) && !isJumping)
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
            if (isJumping && rb.velocity.y < .1f && !coll.IsTouchingLayers(ground)) state = State.falling;
            else if (isJumping) state = State.jumping;
            else if (!coll.IsTouchingLayers(ground) && !isJumping)
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
            if (isJumping && rb.velocity.y < .1f && !coll.IsTouchingLayers(ground)) state = State.falling;
            else if (isJumping) state = State.jumping;
            else
            {
                state = State.idle;
                isJumping = false;
            }

        }
    }

    private void Jump()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            cherries += 1;
        }
    }
}

