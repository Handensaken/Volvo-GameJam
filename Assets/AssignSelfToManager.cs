using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSelfToManager : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerManager playerManager;
    Moving movement;
    public GameObject green;
    public GameObject purple;
    public Charge charge;
    public Animator gr;
    public Animator pu;
    public GameObject grePos;
    public GameObject greNeg;
    public GameObject purpNeg;
    public GameObject purpPos;
    void Start()
    {
        movement = GetComponent<Moving>();
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager.Players.Count == 0)
        {
            green.SetActive(true);
            purple.SetActive(false);
            movement.anim = gr;
            playerManager.AddPlayer(this.gameObject);
        }
        else if (playerManager.Players.Count == 1)
        {
            green.SetActive(false);
            purple.SetActive(true);
            movement.anim = pu;
            playerManager.AddPlayer(this.gameObject);
        }
        else
        {
            Debug.Log("Too many players");
        }
    }

    // Update is called once per frame
    void Update() { }
}
