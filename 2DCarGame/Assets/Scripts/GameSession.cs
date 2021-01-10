using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;

    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    // Add scoreValure to score
    public void AddToScore(int scoreValue)
    {
        print(score);
        score += scoreValue;
        if (score >= 100)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
