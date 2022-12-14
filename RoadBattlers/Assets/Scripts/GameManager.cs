using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints = new GameObject[2];

    //list to store all players in the game
    public List<PlayerInput> playerList = new List<PlayerInput>();

    [SerializeField] InputAction joinAction;
    [SerializeField] InputAction leaveAction;



    // Instances of the Game Manager
    public static GameManager gameManagerInstance = null;

    //events
    public event System.Action<PlayerInput> PlayerJoinedGame;

    //public event System.Action<PlayerInput> PlayerLeftGame;

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            //if there is no game manager in the world
            //then this will be the game manager
            gameManagerInstance = this;
        }
        else if (gameManagerInstance != null)
        {
            //if there is already a game manager in the world
            // Destroy it so there will not be more than one
            Destroy(gameObject);
        }

        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);

        /*leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);*/

        //look for player spawn points in the world and add them to the array
        //spawnPoints[0] = GameObject.FindGameObjectWithTag("SpawnPointOne");
        //spawnPoints[1] = GameObject.FindGameObjectWithTag("SpawnPointTwo");
    }

    private void Start()
    {
        //look for player spawn points in the world and add them to the array
        spawnPoints[0] = GameObject.FindGameObjectWithTag("SpawnPointOne");
        spawnPoints[1] = GameObject.FindGameObjectWithTag("SpawnPointTwo");

        //add the first player to the world, no split screen, default input controls

        //PlayerInputManager.instance.JoinPlayer(0, -1, null);
        //PlayerInputManager.instance.JoinPlayer(1, -1, null);
    }

    //Input Manager Default method names
    void OnPlayerJoined(PlayerInput playerInput)
    {
        //add the player to the list after they join the game
        playerList.Add(playerInput);

        //send the information to any other scripts that want the information
        if (PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
        }
    }

    /*void OnPlayerLeft(PlayerInput playerInput)
    {

    }*/

    void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);
    }

    /*void LeaveAction(InputAction.CallbackContext context)
    {

    }*/

}
