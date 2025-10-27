using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingMenu : MonoBehaviour
{
    
    public void StartNewGame()
    {
        // Replace "GameScene" with the name of your game's main scene
        SceneManager.LoadScene("GameScene");
    }

    // Function to load a saved game
    public void LoadGame()
    {
        // Implement code for loading a saved game here
        Debug.Log("Loading saved game...");
    }

    // Function to access settings menu
    public void OpenSettings()
    {
        // deselect this and select settings
        //SceneManager.LoadScene("SettingsScene");
    }

    // Function to exit the game
    public void ExitGame()
    {
        // Exit the game when running in standalone build
#if UNITY_STANDALONE
        Application.Quit();
#endif

        // For editor or other platforms, stop playing the scene
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
