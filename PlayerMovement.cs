using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public Animator animator;
    public float runSpeed = 2.7f;
    public float jumpForce = 200f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    //public float radius = 0.2f;
    SpriteRenderer sprite;
    Rigidbody2D body;
    float horizontalMove = 0f;
    bool Jump = false;
    bool isOnFloor = false;


        void Start()
    {
            body = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
            //animator.SetFloat("Speed", Mathf.Abs(horizontalMove))
            //isOnFloor = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

            isOnFloor = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);

            if (Input.GetButtonDown("Jump") && isOnFloor == false)
            {
                Jump = true;
            }
        
            PlayerAnimation();
    }
        void FixedUpdate ()
        {
            float move = Input.GetAxis("Horizontal");

            body.velocity = new Vector2(horizontalMove * runSpeed, body.velocity.y);

            if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false))
            {
                Flip();
            }

            if (Jump)
            {
                body.AddForce(new Vector2(0f, jumpForce));
                Jump = false;

            }


    }
        void Flip()
        {
            sprite.flipX = !sprite.flipX;

        }
        void PlayerAnimation ()
        {
        animator.SetFloat("velX", Mathf.Abs(body.velocity.x));
        animator.SetFloat("velY", Mathf.Abs(body.velocity.y));

        }

       

       
    
         /*void OnDrawGizmosSelected ()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, radius);

        }*/
        
 
    }
   

