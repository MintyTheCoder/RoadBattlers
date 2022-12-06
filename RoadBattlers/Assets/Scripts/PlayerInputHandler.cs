using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    private GameObject player1Skin;
    private GameObject player2Skin;


    public GameObject[] characters = new GameObject[6];

    public int player1array;

    public int player2array;

    PlayerMovement playerMovementScript; //on each player
    private Vector2 spawnPoint;

    public static PlayerInputHandler handlerInstance;
    private void Awake()
    {
        //get a spawn point from the game manager object

        if (handlerInstance == null)
        {
            spawnPoint = GameManager.gameManagerInstance.spawnPoints[0].transform.position;
            //make a player prefab in the game
            //and get access to the script on the player prefab
            playerMovementScript = GameObject.Instantiate(player1Skin, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();

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
            playerMovementScript = GameObject.Instantiate(player2Skin, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();

            transform.parent = playerMovementScript.transform;
            transform.position = playerMovementScript.transform.position;
            Debug.Log("Loop 2");
        }

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
