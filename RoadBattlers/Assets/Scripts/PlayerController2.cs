using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private float horizontalMove;
    public float speed = 0f;
    private float jumpingPower = 8f;
    

    public Rigidbody2D rb2;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Joystick2Horizontal");

        if (Input.GetButtonDown("Joystick2Jump") && IsGrounded())
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpingPower);
        }

        if (Input.GetButtonDown("Joystick2Jump") && rb2.velocity.y > 0f)
        {
            rb2.velocity = new Vector2(rb2.velocity.x, rb2.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb2.velocity = new Vector2(horizontalMove * speed, rb2.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
