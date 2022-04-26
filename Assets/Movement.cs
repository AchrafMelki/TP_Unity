using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public SpriteRenderer rend;
    public Animator animator;

    public float Speed = 5;
    public float JumpSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * Speed;
        rb2d.velocity = new Vector2(h, rb2d.velocity.y);
        
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(transform.up * JumpSpeed, ForceMode2D.Impulse);
        }

        if (h > 0)
        {
            rend.flipX = false;
        }
        if (h < 0)
        {
            rend.flipX = true;
        }
    }
}
