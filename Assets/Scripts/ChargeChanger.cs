using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public Charge charge;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.tag == "Player")
        {
            temp.GetComponent<Magnet>().charge = charge;
        }
    }
}