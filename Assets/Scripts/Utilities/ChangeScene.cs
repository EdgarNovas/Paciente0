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
    }

    public void Restart()
    {
            SceneManager.LoadScene(lastScene);
    }
}