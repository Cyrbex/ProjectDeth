using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D Controller;
    public Animator animator;
    [SerializeField] private float m_JumpForce = 400f;
    public float runSpeed = 40f;
    public bool DoubleJump = true;
    float HorizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Rigidbody2D rb;

    void Update()
    {
        
        if (Input.GetButton("Shift") && Controller.m_Grounded) { runSpeed = 80f; }
        else { runSpeed = 40f; }

        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            if (Controller.m_Grounded == true)
            {
                
                jump = true;
                animator.Play("player_jump", 0, 0f);
            }
            else
            {
                if (DoubleJump)
                {
                    DoubleJump = false;
                    rb.velocity = new Vector2 (rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * m_JumpForce);
                }
            }
           
             
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        DoubleJump = true;
        if (HorizontalMove > 0.1f)
        {
            animator.Play("player_walk", 0, 0f);
        }
        else if (HorizontalMove < 0.1f)
        {
            animator.Play("player_idle", 0, 0f);
        }

    }

    public void OnCrouching (bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching); 
    }

    void FixedUpdate()
    { 
        // Move Character
        Controller.Move(HorizontalMove * Time.fixedDeltaTime, crouch, jump);
        
        jump = false; 
    }
}
