using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPolarityDisplayBehaviour : MonoBehaviour
{
    public Image img;
    public Sprite pos;
    public Sprite neg;
    public Magnet mag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mag.charge == Charge.Positive){
            img.sprite = pos;
        }else if (mag.charge == Charge.Negative)img.sprite=neg;else img.sprite = null;
    }
}
