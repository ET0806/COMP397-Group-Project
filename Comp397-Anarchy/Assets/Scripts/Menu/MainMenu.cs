using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Name of the tutorial scene
    public string Tutorial = "TutorialScene"; // Assuming the tutorial scene name is "TutorialScene"

    public void PlayGame()
    {
        //GameDataManager.instance.NewGame();
        SceneManager.LoadSceneAsync("SampleScene"); // Load the main game scene
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("SampleScene"); // Load the main game scene
    }

    public void LoadTutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial"); // Load the tutorial scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}