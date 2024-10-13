using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public List<PlayerInput> playerList = new List<PlayerInput>(); 


    public static GameManager instance = null;

    [SerializeField] InputAction joinAction;
    [SerializeField] InputAction leaveAction;


    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    public int playerIndex;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    private void Start()
    {
        Gamepad[] gamepads = Gamepad.all.ToArray();
        InputDevice device = gamepads[playerIndex];
        PlayerInput playerInput = PlayerInputManager.instance.JoinPlayer(0, -1, null, device);
        device = gamepads[1];

        playerInput = PlayerInputManager.instance.JoinPlayer(1, -1, null, device);



        //PlayerInputManager.instance.playerPrefab.transform.position = spawnPoints[0].transform.position;
        //PlayerInputManager.instance.JoinPlayer(0, -1, null);
        //PlayerInputManager.instance.playerPrefab.transform.position = spawnPoints[1].transform.position;
        //PlayerInputManager.instance.JoinPlayer(1, -1, null);
    }
    void OnPlayerJoin(PlayerInput playerInput)
    {
        playerList.Add(playerInput);

        if (PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
        }
    }
    void OnPlayerLeft(PlayerInput playerInput)
    {

    }
}
