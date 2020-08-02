using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;





public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Animator anim;

    // Movement Function
    Vector2 Movement(float x, float y)
    {
        return new Vector2(x, y);
    }


    // Update is called once per frame
    void Update()
    {
        int moveSpeed = 5;
        int jumpVelocity = 30;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Movement(-moveSpeed, jumpVelocity);
            anim.SetBool("floating", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, 1);
            rb.velocity = Movement(-moveSpeed, rb.velocity.y);
            anim.SetBool("running", true);
            anim.SetBool("floating", false);

        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1, 1);
            rb.velocity = Movement(moveSpeed, rb.velocity.y);
            anim.SetBool("running", true);
            anim.SetBool("floating", false);
        }
        else
        {
            rb.velocity = Movement(0, rb.velocity.y);
            anim.SetBool("running", false);
            anim.SetBool("floating", false);
        }


    }
}
