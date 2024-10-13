using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> Players;
    public GameObject s1;
    public GameObject s2;
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void AddPlayer(GameObject player)
    {
        if (Players.Count <= 2)
        {
            Players.Add(player);
            if(Players.Count ==1){
                Players[0].transform.position = s1.transform.position;
                //move to pos 1
            }
            else{
                Players[1].transform.position=s2.transform.position;
                //pos2
            }
        }
    }
}
