
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

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

    public bool isFlipX = false;
    

    
    
    private void Update()
    {
        
        

        isGrounded = Physics2D.OverlapCircle(grCheck.position, grCheckRadius, collisionLayers);
        hMove = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        
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

    public void flipButtonR()
    {
        isFlipX = false;
    }

    public void flipButtonL()
    {
        isFlipX = true; 
    }
    
   
    void MovePlayer(float pHMove, bool pIsGrounded, bool pIsJumping)
    {
        animator.SetBool("Jump", pIsJumping);
        rend.flipX = isPlayerLeftSide();
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

        if (isGrounded && CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            animator.SetTrigger("TakeOff");
            isJumping = true;
            rb2d.AddForce(Vector2.up * jumpForce);
            isJumping = false;
        }
        
    }


    public bool isPlayerLeftSide()
    {
        if (!isFlipX)
        {
            isPlayerLeft = false;
            return false;
        }
        else
        {
            isPlayerLeft = true;
            return true;
        }
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(grCheck.position, grCheckRadius);
    }
}
