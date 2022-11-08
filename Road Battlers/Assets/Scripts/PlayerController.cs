using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    public float speed = 0f;
    private float jumpingPower = 8f;
    

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
