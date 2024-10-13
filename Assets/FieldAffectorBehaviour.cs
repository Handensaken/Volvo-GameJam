using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldAffectorBehaviour : MonoBehaviour
{
    public GameObject whoreson;
    float rng;
    private Magnet MAGA;
    public ParticleSystem particleSystemPos;
    public ParticleSystem particleSystemNeg;

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
            //particleSystem.gameObject.SetActive(true);
            whoreson.SetActive(true);
         
            whoreson.transform.localScale = new Vector3(MAGA.range, MAGA.range, 1) * 0.11f;
            if (MAGA.charge == Charge.Negative)
            {
                   var test = particleSystemNeg.shape;
            test.radius = MAGA.range / 2 - 0.1f;
                particleSystemPos.gameObject.SetActive(false);
                particleSystemNeg.gameObject.SetActive(true);
                whoreson.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (MAGA.charge == Charge.Positive)
            {
                   var test = particleSystemPos.shape;
            test.radius = MAGA.range / 2 - 0.1f;
                particleSystemPos.gameObject.SetActive(true);
                particleSystemNeg.gameObject.SetActive(false);
                whoreson.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                particleSystemPos.gameObject.SetActive(false);
                particleSystemNeg.gameObject.SetActive(false);
                whoreson.SetActive(false);
            }
        }
        else
        {
            particleSystemPos.gameObject.SetActive(false);
            particleSystemNeg.gameObject.SetActive(false);
            whoreson.SetActive(false);
        }
    }
}
