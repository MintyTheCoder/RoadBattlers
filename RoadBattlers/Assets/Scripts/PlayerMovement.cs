using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;


    private Rigidbody2D playerRigidbody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public GameObject projectilePrefab;

    Vector2 horizontalInput;


    private void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody2D>();
        /*
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
        */
    }

    public void OnMove(InputAction.CallbackContext inputValue)
    {
        horizontalInput = inputValue.ReadValue<Vector2>();
        playerRigidbody.velocity = new Vector2(horizontalInput.x * playerSpeed, playerRigidbody.velocity.y);
    }

    public void OnJump()
    {
        if ( IsGrounded())
        {
            playerRigidbody.velocity = new Vector2(0, jumpPower);
        }
    }

    private bool IsGrounded()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        return isTouchingGround;
    }


   public void OnAttack()
   {
        Debug.Log("Attack!");
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
   }


    private void Update()
    {
       // isTouchingGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);

       // MovePlayer();

    }
    private void MovePlayer()
    {
        //var horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(horizontalInput.x * playerSpeed, playerRigidbody.velocity.y);
    }
    // private void Jump() => _playerRigidbody.velocity = new Vector2(0, jumpPower);

    
}
