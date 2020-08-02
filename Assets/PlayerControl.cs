
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector3;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private enum State {idle, running, jumping}
    private State state = State.idle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private float jumpHeight = 5f;
    private static bool isJumping = false; 


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
            state = State.running;
        }
        else if(hDirection > 0)
        {
            transform.localScale = new Vector2(1, 1);
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
        anim.SetInteger("state", (int)state);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        
    }


}
