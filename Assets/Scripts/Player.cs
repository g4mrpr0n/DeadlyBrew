using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;

    private float dirX = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();   
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * 3f, rb.velocity.y);
        AnimationUpdate();
        
    }


    private void AnimationUpdate()
    {
        if (dirX > 0f)
        {
            anim.SetBool("walking", true);
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            anim.SetBool("walking", true);
            sp.flipX = true;
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }
}
