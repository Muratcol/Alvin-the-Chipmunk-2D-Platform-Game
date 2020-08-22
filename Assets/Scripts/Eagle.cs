using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Eagle : Enemy
{
    private Collider2D coll;

    private float flightSpeed = 5;
    [SerializeField] private float flightRangeTop;
    [SerializeField] private float flightRangeBottom;
    public Rigidbody2D rb;

    private bool atTop = true;
    private bool atBottom = false;

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
        if (transform.position.y >= flightRangeTop && !atTop)
        {
            atTop = true;
            atBottom = false;
        }
        else if (transform.position.y <= flightRangeBottom && !atBottom)
        {
            atTop = false;
            atBottom = true;
        }
        movement();

    }

    void movement()
    {
        if (atTop)
        {
            rb.velocity = new Vector2(0, -flightSpeed);
        }
        else if (atBottom)
        {
            rb.velocity = new Vector2(0, flightSpeed);
        }

    }
}
