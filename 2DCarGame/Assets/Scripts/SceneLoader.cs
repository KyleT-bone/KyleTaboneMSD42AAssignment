using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        // To go to the game
        SceneManager.LoadScene("GameLevel1");
    }

    public void LoadMainMenu()
    {
        // To go to the MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // To quit the application, yet unity can't, so it prints out "Quit!"
        Application.Quit();
        Debug.Log("Quit!");
    }
}
