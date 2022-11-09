using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    public float speed = 0f;
    private float jumpingPower = 8f;
    public Rigidbody2D rb1;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         
        horizontalMove = Input.GetAxis("Joystick1Horizontal");
        

    
        

        if(Input.GetButtonDown("Joystick1Jump") && IsGrounded())
        {
            rb1.velocity = new Vector2(rb1.velocity.x, jumpingPower);
        }
        if(Input.GetButtonDown("Joystick1Jump") && rb1.velocity.y > 0f)
        {
            rb1.velocity = new Vector2(rb1.velocity.x, rb1.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb1.velocity = new Vector2(horizontalMove * speed, rb1.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
