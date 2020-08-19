using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Collider2D coll;

    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float leftWaypoint;
    [SerializeField] private float rightWaypoint;

    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;
    

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
        
    }

    void movement()
    {
        if(coll.IsTouchingLayers(ground))
        {
            Vector3 movement = new Vector3(1, 1f, 0f);
            transform.position += movement * Time.deltaTime * jumpLength;
        }
    }
}
