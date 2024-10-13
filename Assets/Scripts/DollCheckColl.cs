using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollCheckColl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        sceneManager = GameObject.FindFirstObjectByType<SceneBehaviour>();
        Debug.Log(sceneManager.name );
     }

    [SerializeField]
    private SceneBehaviour sceneManager;

    // Update is called once per frame
    void Update() { }

    private void OnCollisionEnter2D(Collision2D col)
    {
//        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Hazard"))
        {
            GameObject.FindObjectOfType<PlayerManager>().Players.Remove(this.gameObject);
            Debug.Log("huhrensohn");
            sceneManager.ReloadSceneDelayed(3);

            if (gameObject.transform.parent != null)
            {
                Destroy(gameObject.transform.parent.parent.gameObject);
            }else Destroy(this.gameObject);
        }
    }
    public void ManualRestart(){
        sceneManager.ReloadScene();
    }
}
