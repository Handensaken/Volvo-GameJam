using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneDelayed(string sceneName, int delayTimeInSeconds) { 
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
}
