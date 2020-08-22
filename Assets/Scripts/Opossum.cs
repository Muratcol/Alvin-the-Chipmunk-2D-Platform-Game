using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Opossum : Enemy
{
    private Collider2D coll;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftWaypoint;
    [SerializeField] private float rightWaypoint;
    public Rigidbody2D rb;
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;

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
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        else if (!facingLeft)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }

    }

}
