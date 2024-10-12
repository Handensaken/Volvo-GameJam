using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    [SerializeField]
    private string NextScene;

    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneDelayed(string sceneName, int delayTimeInSeconds)
    {
        StartCoroutine(Cock(delayTimeInSeconds, sceneName));
    }

    private IEnumerator Cock(int delay, string sceneName)
    {
        int counter = delay;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        LoadScene(sceneName);
    }

    int whore = 0;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            whore++;
        }
        if(whore >= 2){
            SceneManager.LoadScene(NextScene);
        }
    }
}
