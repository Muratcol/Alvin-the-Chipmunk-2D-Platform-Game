using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;
    protected AudioSource deathSFX;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        deathSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void JumpedOn()
    {
        deathSFX.Play();
        anim.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
