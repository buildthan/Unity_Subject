using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    static GameManager gameManager;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    int Score = 0;

    private void Awake()
    {
        gameManager = this;
    }

    public void GameOver()
    {

    }

    public void ExitMiniGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        Score = Score + score;
    }


}
