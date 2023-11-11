using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody2D rb;
    public float horizontal;
    private bool flip = true;
    public Animator animator;
    public int jumpForce = 10;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("moveX",Mathf.Abs(horizontal));

/*        if (horizontal > 0 && !flip)
        {
            Flip();
        }
        else if(horizontal < 0 && flip)
        {
            Flip();
        }*/
        if ((horizontal > 0 && !flip) || (horizontal < 0 && flip))
        {
            transform.localScale *= new Vector2(-1,1);
            flip = !flip;
        }
        Jump();
    }
/*    void Flip()
    {
        flip = !flip;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
