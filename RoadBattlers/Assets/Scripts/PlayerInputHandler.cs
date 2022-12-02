using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public GameObject player1Skin;
    public GameObject player2Skin;

    private GamePadControl controls;

    PlayerMovement playerMovementScript; //on each player
    private Vector2 spawnPoint;

    public static PlayerInputHandler handlerInstance;
    private void Awake()
    {
        //controls = new GamePadControl();
        //get a spawn point from the game manager object

        //playerMovementScript = GameObject.Instantiate(playerPrefab, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();
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
