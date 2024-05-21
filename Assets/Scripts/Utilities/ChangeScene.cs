using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad;
    private static string lastScene;

    public void SceneToLoad()
    {
        lastScene = sceneToLoad;

        SceneManager.LoadScene(sceneToLoad);
        Time.timeScale = 1.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(lastScene);
    }


public void LoadNextScene()
    {
        if (lastScene == "Level 2" ) 
        {
            SceneManager.LoadScene("New");
        }

        if (lastScene == "New")
        {
            SceneManager.LoadScene("Level 2");
        }

    }
}