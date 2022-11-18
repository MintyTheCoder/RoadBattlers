using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler1 : MonoBehaviour{

    public GameObject playerPrefab;

    PlayerMovement playerMovementScript; //on each player
    private Vector2 spawnPoint;
    //int spawnNumber = 0;

    private void Awake()
    {
        //get a spawn point from the game manager object
        spawnPoint = GameManager.gameManagerInstance.spawnPoints[1].transform.position;
        //playerMovementScript = GameObject.Instantiate(playerPrefab, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();
        if (playerPrefab != null)
        {
            //make a player prefab in the game
            //and get access to the script on the player prefab
            playerMovementScript = GameObject.Instantiate(playerPrefab, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();

            transform.parent = playerMovementScript.transform;
            transform.position = playerMovementScript.transform.position;
        } 

        //spawnPoint = GameManager.gameManagerInstance.spawnPoints[1].transform.position;

        /*if (playerPrefab != null)
        {
            //make a player prefab in the game
            //and get access to the script on the player prefab
            playerMovementScript = GameObject.Instantiate(playerPrefab2, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();

            transform.parent = playerMovementScript.transform;
            transform.position = playerMovementScript.transform.position;
        }*/
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
