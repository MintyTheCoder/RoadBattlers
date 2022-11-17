using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour{

    public GameObject playerPrefab;
    PlayerMovement playerMovementScript; //on each player
    public Vector3 spawnPoint;

    private void Awake()
    {
        //get a spawn point from the game manager object
        spawnPoint = GameManager.gameManagerInstance.spawnPoints[0].transform.position;

        if (playerPrefab != null)
        {
            //make a player prefab in the game
            //and get access to the script on the player prefab
            playerMovementScript = GameObject.Instantiate(playerPrefab, spawnPoint, transform.rotation).GetComponent<PlayerMovement>();

            transform.parent = playerMovementScript.transform;
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
