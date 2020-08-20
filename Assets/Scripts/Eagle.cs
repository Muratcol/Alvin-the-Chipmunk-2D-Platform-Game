using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    private Collider2D coll;

    [SerializeField] private float jumpLength;
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
