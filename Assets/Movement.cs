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
    public Transform grCheck;
    public float grCheckRadius;
    public LayerMask collisionLayers;
    
    private Vector3 velocity = Vector3.zero;
    private float hMove;
    private bool isPlayerLeft = false;

    public float speed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(grCheck.position, grCheckRadius, collisionLayers);
        hMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("TakeOff");   
            isJumping = true;
        }
        
    }

    void FixedUpdate()
    {
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

        rend.flipX = isFlipX();
        
        if (isJumping == true)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            
            isJumping = false;
        }
    }

    public bool isFlipX()
    {
        
        if (hMove > 0f)
        {
            isPlayerLeft = false;
            return false;
        }
        else if (hMove < 0f)
        {
            isPlayerLeft = true;
            return true;
        }
        else
        {
            return isPlayerLeft;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(grCheck.position, grCheckRadius);
    }
}
