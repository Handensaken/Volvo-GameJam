using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldAffectorBehaviour : MonoBehaviour
{
    public GameObject whoreson;
    float rng;
    private Magnet MAGA;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        MAGA = GetComponent<Magnet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MAGA.IsActive)
        {
            whoreson.SetActive(true);
            whoreson.transform.localScale = new Vector3(MAGA.range, MAGA.range, 1) * 0.37f;
            if (MAGA.charge == Charge.Negative)
            {
                particleSystem.startColor = Color.blue;
                whoreson.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (MAGA.charge == Charge.Positive)
            {
                particleSystem.startColor = Color.red;
                whoreson.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        else
        {
            whoreson.SetActive(false);
        }
    }
}
