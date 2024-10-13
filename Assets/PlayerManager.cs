using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<GameObject> Players;
    public GameObject s1;
    public GameObject s2;
    public Charge p1Charge;
    public Charge p2Charge;

    public float MagnetSize;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        foreach (var player in Players){
                player.GetComponent<Magnet>().range = MagnetSize;
            }
        if (Players.Count != 0)
        {
            if (p1Charge == Charge.Positive)
            {
                Players[0].GetComponent<AssignSelfToManager>().grePos.SetActive(true);
                Players[0].GetComponent<AssignSelfToManager>().greNeg.SetActive(false);
            }
            else if (p1Charge == Charge.Negative)
            {
                Players[0].GetComponent<AssignSelfToManager>().greNeg.SetActive(true);
                Players[0].GetComponent<AssignSelfToManager>().grePos.SetActive(false);
            }
            else { }
            if (p2Charge == Charge.Positive)
            {
                Players[1].GetComponent<AssignSelfToManager>().purpNeg.SetActive(true);
                Players[1].GetComponent<AssignSelfToManager>().purpPos.SetActive(false);
            }
            else if (p2Charge == Charge.Negative)
            {
                Players[1].GetComponent<AssignSelfToManager>().purpPos.SetActive(true);
                Players[1].GetComponent<AssignSelfToManager>().purpNeg.SetActive(false);

            }
            
        }
        else
        {
            if (wasGreater)
            {

                FindObjectOfType<SceneBehaviour>().ReloadSceneDelayed(3);
            }
        }
    }

    bool wasGreater = false;

    public void AddPlayer(GameObject player)
    {
        wasGreater = true;
        if (Players.Count <= 2)
        {
            Players.Add(player);
            if (Players.Count == 1)
            {
                Players[0].transform.position = s1.transform.position;
                Players[0].GetComponent<Magnet>().charge = p1Charge;
                //move to pos 1
                s1.SetActive(false);
            }
            else
            {
                Players[1].transform.position = s2.transform.position;
                Players[1].GetComponent<Magnet>().charge = p2Charge;
                s2.SetActive(false);
                //pos2
            }
        }
    }
}
