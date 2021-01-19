using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadGame()
    {
        // To go to the game
        SceneManager.LoadScene("GameLevel1");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadMainMenu()
    {
        // To go to the MainMenu
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        // To quit the application, yet unity can't, so it prints out "Quit!"
        Application.Quit();
        Debug.Log("Quit!");
    }
}
