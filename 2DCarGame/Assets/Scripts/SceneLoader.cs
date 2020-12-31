using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGame()
    {
        // To go to the game
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        // To quit the application, yet unity can't, so it prints out "Quit!"
        Application.Quit();
        Debug.Log("Quit!");
    }
}
