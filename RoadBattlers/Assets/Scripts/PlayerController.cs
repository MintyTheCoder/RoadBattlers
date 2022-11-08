using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    public float speed = 0f;
    private float jumpingPower = 8f;
    float movementX;
    float movementY;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementX = 0;
        movementY = 0;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.A))
        {
            horizontalMove = Input.GetAxis("Horizontal");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            horizontalMove = Input.GetAxis("Horizontal");
        }
        

        if(Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(Input.GetKeyDown(KeyCode.W) && rb.velocity.y > 0f)
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
