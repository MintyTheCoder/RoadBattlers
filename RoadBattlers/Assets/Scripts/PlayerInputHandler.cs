using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;

    private void Awake()
    {
        if (playerController != null)
        {
            playerController = player.GetComponent<PlayerController > ();
        }
    }

    void OnMove(InputAction.CallbackContext context)
    {
        
    }
}
