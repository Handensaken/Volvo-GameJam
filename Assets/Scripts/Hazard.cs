using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public SceneBehaviour sceneManager;
    [Range(0, 10)]
    public int reloadDeley = 2;

    private void OnCollisionEnter2D(Collision2D col)
       {
           if (col.gameObject.CompareTag("Hazard"))
           {
            if (sceneManager!= null)
            {
               sceneManager.ReloadSceneDelayed(reloadDeley);

            }
               Destroy(gameObject);
           }
       }
}
