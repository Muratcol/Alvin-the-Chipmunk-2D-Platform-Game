using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    private Collider2D coll;

    [SerializeField] private float jumpLength;
    [SerializeField] private float leftWaypoint;
    [SerializeField] private float rightWaypoint;
    public Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;

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
        }
        else if (transform.position.x >= rightWaypoint)
        {
            transform.localScale = new Vector2(1, 1);
            facingLeft = true;          
        }
        movement();

    }

    void movement()
    {
        if (facingLeft)
        {
            rb.velocity = new Vector2(-jumpLength, 0);
        }
        else if (!facingLeft)
        {
            rb.velocity = new Vector2(jumpLength, 0);
        }

    }
}
