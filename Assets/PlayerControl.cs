using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, -1);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, -1);
        }
        else
        {
            rb.velocity = new Vector2(0, -1);
        }


    }
}
