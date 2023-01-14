using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    public GameObject shotOffSetRight, shotOffSetLeft;

    public GameObject punchLeft, punchRight;

    GameObject player1, player2;

    public GameObject bombLeft, bombRight;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;

    public Animator animator, lifeAnim;

    private Vector2 respawnPoint = new Vector2(0, 2);
    //private Vector2 moveDirection;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public GameObject projectileLeftPrefab, projectileRightPrefab;

    public Vector2 horizontalInput;
    public bool isFacingRight;
    bool canAttack = true;
    bool specialAllowed = false;

    public int lives = 3;

    public int health = 100;
    [SerializeField] Text healthDisplay;
    
    private void Start()
    {
        //lifeAnim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(SpecialTimer());
        healthDisplay.text = "Health: " + health;
        lifeAnim.SetInteger("Lives", lives);
    }

    public IEnumerator SpecialTimer()
    {
        yield return new WaitForSeconds(200);
        specialAllowed = true;
        StartCoroutine(SpecialTimer());
    }

    public void OnMove(InputAction.CallbackContext inputValue)
    {
        horizontalInput = inputValue.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput.x));
        playerRigidbody.velocity = new Vector2(horizontalInput.x * playerSpeed, playerRigidbody.velocity.y);

        if (horizontalInput.x > 0)
        {
            isFacingRight = true;
            spriteRenderer.flipX = false;
        }

        else if (horizontalInput.x < 0)
        {
            isFacingRight = false;
            spriteRenderer.flipX = true;
        }

        else
        {
            return;
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
            StartCoroutine(DelayPress());
        }

        else if (!isFacingRight && canAttack == true)
        {
            Instantiate(projectileLeftPrefab, shotOffSetLeft.transform.position, Quaternion.identity);
            StartCoroutine(DelayPress());
        }

        canAttack = false;
    }

    public void OnPunch()
    {
        Debug.Log("Punch!");

        if (isFacingRight && canAttack == true)
        {
            Instantiate(punchRight, shotOffSetRight.transform.position, Quaternion.identity);
            StartCoroutine(DelayPress());
        }

        else if (!isFacingRight && canAttack == true)
        {
            Instantiate(punchLeft, shotOffSetLeft.transform.position, Quaternion.identity);
            StartCoroutine(DelayPress());
        }

        canAttack = false;
        
    }

    public void OnSpecial()
    {
        if (specialAllowed)
        {
            Debug.Log("Special!!");

            if (isFacingRight && canAttack == true)
            {
                Instantiate(bombRight, shotOffSetRight.transform.position, Quaternion.identity);
                StartCoroutine(DelayPress());
            }

            else if (!isFacingRight && canAttack == true)
            {
                Instantiate(bombLeft, shotOffSetLeft.transform.position, Quaternion.identity);
                StartCoroutine(DelayPress());
            }

            canAttack = false;
        }
    }

    
    public IEnumerator DelayPress()
    {
        //canShoot should be true 
        yield return new WaitForSeconds(3);
        canAttack = true;
    }

    private void Update()
    {
        lifeAnim.SetInteger("Lives", lives);
        healthDisplay.text = "Health: " + health;
        player1 = GameObject.FindGameObjectWithTag("PlayerOne");
        player2 = GameObject.FindGameObjectWithTag("PlayerTwo");
        // isTouchingGround = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);

        // MovePlayer();

        if (health <= 0)
        {
            lives = lives - 1;
            lifeAnim.SetInteger("Lives", lives);
            health = 100;

            if (lives >= 1)
            {
                transform.position = respawnPoint;
                
            }
        }

        //determines game over using lives

        if (lives == 0)
        {
            animator.SetBool("Dead", true);
            lifeAnim.SetInteger("Lives", 0);

            Debug.Log(lifeAnim.GetInteger("Lives"));

            lives = lives - 1;

            //gameObject.transform.position = new Vector2(0,0);
            StartCoroutine(Delay());

            if (gameObject.tag == "PlayerOne")
            {
                //player2.transform.position = new Vector2(0,0);
                gameObject.transform.position = GameManager.gameManagerInstance.spawnPoints[0].transform.position;
            }

            else if (gameObject.tag == "PlayerTwo")
            {
                //player1.transform.position = new Vector2(0,0);
                gameObject.transform.position = GameManager.gameManagerInstance.spawnPoints[1].transform.position;
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
        if (other.tag == "Projectile")
        {
            health = health - 5;
            Debug.Log(health);
            healthDisplay.text = "Health: " + health;
        }

        else if (other.tag == "Punch")
        {
            health = health - 10;
            Debug.Log(health);
            healthDisplay.text = "Health: " + health;
        }

        else if (other.tag == "Bomb")
        {
            health = health - 40;
            Debug.Log(health);
            healthDisplay.text = "Health: " + health;
        }

        else if (other.tag == "DeathBox")
        {
            health = 0;
            Debug.Log("life lost");
            healthDisplay.text = "Health: " + health;
            transform.position = respawnPoint;
        }
    }

    public IEnumerator Delay() 
    {
        Debug.Log("Paused");
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
