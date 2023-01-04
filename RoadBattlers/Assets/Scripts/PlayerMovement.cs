using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    public GameObject shotOffSetRight, shotOffSetLeft;

    public GameObject punchLeft, punchRight;

    private Rigidbody2D playerRigidbody;
    private SpriteRenderer renderer;

    public Animator animator;

    private Vector2 respawnPoint = new Vector2(0, 2);
    public Vector2 playerPos;
    //private Vector2 moveDirection;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public GameObject projectileLeftPrefab;
    public GameObject projectileRightPrefab;

    public Vector2 horizontalInput;
    public bool isFacingRight;
    public bool canAttack = true;

    public int lives = 3;

    public int health = 100;
    
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        
    }

    public void OnMove(InputAction.CallbackContext inputValue)
    {
        horizontalInput = inputValue.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput.x));
        playerRigidbody.velocity = new Vector2(horizontalInput.x * playerSpeed, playerRigidbody.velocity.y);
        if (horizontalInput.x > 0)
        {
            isFacingRight = true;
            renderer.flipX = false;
        }
        else if (horizontalInput.x < 0)
        {
            isFacingRight = false;
            renderer.flipX = true;
        }
    }

    public void OnJump()
    {
        if (IsGrounded())
        {
            playerRigidbody.velocity = new Vector2(0, jumpPower);
            animator.SetBool("Jump", true);
        }

        else
        {
            animator.SetBool("Jump", false);
        }
    }

    private bool IsGrounded()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        return isTouchingGround;
    }


    public void OnThrow()
    {
        Debug.Log("Throw!");

        if (isFacingRight && canAttack == true)
        {
            Instantiate(projectileRightPrefab, shotOffSetRight.transform.position, Quaternion.identity);
        }

        else if (!isFacingRight && canAttack == true)
        {
            Instantiate(projectileLeftPrefab, shotOffSetLeft.transform.position, Quaternion.identity);
        }

        canAttack = false;
        StartCoroutine(DelayPress());
    }

    public void OnPunch()
    {
        Debug.Log("Punch!");

        if (isFacingRight && canAttack == true)
        {
            Instantiate(punchRight, shotOffSetRight.transform.position, Quaternion.identity);
        }

        else if (!isFacingRight && canAttack == true)
        {
            Instantiate(punchLeft, shotOffSetLeft.transform.position, Quaternion.identity);
        }

        canAttack = false;
        StartCoroutine(DelayPress());
    }

    public void OnSpecial()
    {
        
    }
    public IEnumerator DelayPress()
    {
        //canShoot should be true 
        yield return new WaitForSeconds(3);
        canAttack = true;
    }

    private void Update()
    {
        // isTouchingGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);

        // MovePlayer();
        playerPos = transform.position;

        if (health <= 0)
        {
            lives = lives - 1;
            transform.position = respawnPoint;
            health = 100;
        }

        //determines game over using lives

        if (lives == 0)
        {
            Destroy(gameObject);
            if (gameObject.tag == "player1")
            {

            }
        }
    }
    //private void MovePlayer()
    //{
        //var horizontalInput = Input.GetAxisRaw("Horizontal");
        //playerRigidbody.velocity = new Vector2(horizontalInput.x * playerSpeed, playerRigidbody.velocity.y);
    //}
    // private void Jump() => _playerRigidbody.velocity = new Vector2(0, jumpPower);  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            health = health - 5;
        }

        else if (other.tag == "DeathBox")
        {
            lives = lives - 1;
            Debug.Log("life lost");
            transform.position = respawnPoint;
        }
    }
}
