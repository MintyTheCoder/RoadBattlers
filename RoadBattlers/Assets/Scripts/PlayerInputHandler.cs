using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    //public GameObject player1Skin;
    //public GameObject player2Skin;

    public GameObject[] characters = new GameObject[6];

    PlayerMovement playerMovementScript; //on each player
    public Vector2 spawnPoint;

    
    public int playerOneSelectedSkin, playerTwoSelectedSkin;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip spawnNoise;
    //SerializeField] AudioClip damageNoise;

    public static PlayerInputHandler handlerInstance;

    private void Awake()
    {
        playerOneSelectedSkin = PlayerPrefs.GetInt("player1SkinNumber");
        Debug.Log(playerOneSelectedSkin);
        playerTwoSelectedSkin = PlayerPrefs.GetInt("player2SkinNumber");
        Debug.Log(playerTwoSelectedSkin);
        //get a spawn point from the game manager object

        if (handlerInstance == null)
        {
            spawnPoint = GameManager.gameManagerInstance.spawnPoints[0].transform.position;
            //make a player prefab in the game
            //and get access to the script on the player prefab
            playerMovementScript = GameObject.Instantiate(characters[playerOneSelectedSkin], spawnPoint, transform.rotation).GetComponent<PlayerMovement>();
            playerMovementScript.isFacingRight = true;
            audioSource.PlayOneShot(spawnNoise);

            transform.parent = playerMovementScript.transform;
            transform.position = playerMovementScript.transform.position;
            Debug.Log("Loop1");
            handlerInstance = this;

        }

        else if (handlerInstance != null)
        {
            spawnPoint = GameManager.gameManagerInstance.spawnPoints[1].transform.position;
            //make a player prefab in the game
            //and get access to the script on the player prefab
            playerMovementScript = GameObject.Instantiate(characters[playerTwoSelectedSkin], spawnPoint, transform.rotation).GetComponent<PlayerMovement>();
            playerMovementScript.isFacingRight = false;

            audioSource.PlayOneShot(spawnNoise);

            transform.parent = playerMovementScript.transform;
            transform.position = playerMovementScript.transform.position;
            Debug.Log("Loop 2");
        }

    }

    private void Update()
    {
        
    }

    //get the event from the gamepad
    public void OnMove(InputAction.CallbackContext context)
    {
        //send the command to the player movement script
        playerMovementScript.OnMove(context);
    }

    //get the event from the gamepad
    public void OnJump()
    {
        //send the command to the player movement script
        playerMovementScript.OnJump();
    }

    //get the event from the gamepad
    public void OnAttack()
    {
        //send the command to the player movement script
        playerMovementScript.OnAttack();
    }

}
