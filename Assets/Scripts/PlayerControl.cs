
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

    private enum State { idle, running, jumping, falling }
    private State state = State.idle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        compCol = GetComponent<TilemapCollider2D>();
        charCol = GetComponent<BoxCollider2D>();

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
            if(isJumping) state = State.jumping;
            else state = State.running;
            

        }
        else if (hDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
            if (isJumping) state = State.jumping;
            else state = State.running;
        }
        else
        {
            state = State.idle;
        }
        anim.SetInteger("state", (int)state);

    }



    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            state = State.jumping;
            isJumping = true;
        }

    }
}

