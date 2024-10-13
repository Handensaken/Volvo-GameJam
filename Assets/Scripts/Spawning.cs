using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Spawning : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public int playerIndex;
    public GameObject player1;
    public GameObject player2;

    private void Start()
    {
        Gamepad[] gamepads = Gamepad.all.ToArray();
        InputDevice device = gamepads[playerIndex];
        PlayerInput playerInput = playerInputManager.JoinPlayer(playerIndex,-1, null, device);
    }
    void Update()
    {

    }
}
