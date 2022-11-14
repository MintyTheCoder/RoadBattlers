using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Vector2 horizontalMove;
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

    
    

   
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontalMove = context.ReadValue<Vector2>();
        
        rb1.velocity = new Vector2(horizontalMove.x * speed, rb1.velocity.y);
    }

    public void OnJump()
    {
        if(IsGrounded())
        {
            rb1.velocity = new Vector2(rb1.velocity.x, jumpingPower);
        }
    }
}
