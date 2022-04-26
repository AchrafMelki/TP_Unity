using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public SpriteRenderer rend;
    public Animator animator;
    public Transform grCheckL;
    public Transform grCheckR;
    
    private Vector3 velocity = Vector3.zero;

    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(grCheckL.position, grCheckR.position);
        float hMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("TakeOff");   
            isJumping = true;
        }
        MovePlayer(hMove, isGrounded, isJumping);
    }

    void MovePlayer(float pHMove, bool pIsGrounded, bool pIsJumping)
    {
        animator.SetBool("Jump", pIsJumping);
        Vector3 targetVelocity = new Vector2(pHMove, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, 0.05f);
        if (pIsGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        }
        else
        {
            animator.SetBool("Jump", true);
        }
            

        if (pHMove > 0)
        {
            rend.flipX = false;
        }
        if (pHMove < 0)
        {
            rend.flipX = true;
        }

        if (isJumping == true)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            
            isJumping = false;
        }
        
        
        
    }
}
