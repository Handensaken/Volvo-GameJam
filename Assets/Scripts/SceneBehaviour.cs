using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    [SerializeField]
    private string NextScene;
    int whore = 0;
    public TextMeshProUGUI textMeshPro;

    [Tooltip("If true, restarts on star. If false plays nextscene variable")]
    public bool restartOnStart = true;

    public void Update()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = $"{whore / 2}/2";
        }
    }
    public void OnStart()
    {
        if (restartOnStart)
        {
            //ReloadScene();
        }
        else
        {
            if (NextScene != null)
            {
                LoadScene(NextScene);
            }
        }
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SceneManager.GetActiveScene();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadSceneDelayed(float delayTimeInSeconds)
    {
        ReloadScene();
        //StartCoroutine(Cock(delayTimeInSeconds));
    }

    private IEnumerator Cock(float delay)
    {
        float counter = delay;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        ReloadScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            whore++;
        }
        if (whore >= 2)
        {
            SceneManager.LoadScene(NextScene);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            whore--;
        }
    }
}
