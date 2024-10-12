using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollCheckColl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    [SerializeField]
    private SceneBehaviour sceneManager;

    // Update is called once per frame
    void Update() { }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("huhrensohn");
            sceneManager.LoadSceneDelayed("Max", 3);
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
    }
}
