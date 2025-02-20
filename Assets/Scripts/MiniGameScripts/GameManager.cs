using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject homeUI;
    public GameObject gameUI;
    public GameObject scoreUI;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentScoreText_ScoreBoard;
    public TextMeshProUGUI bestScoreText;

    static GameManager gameManager;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    int Score = 0;

    private void Awake()
    {
        gameManager = this;
        homeUI.SetActive(true);
    }

    public void GameStart()
    {
        player.SetActive(true);
        homeUI.SetActive(false);

        gameUI.SetActive(true);


    }

    public void GameOver()
    {
        int bestscore = 0;

        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestscore = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }

        if(Score > bestscore)
        {
            PlayerPrefs.SetInt("BestScore", Score); //�ְ� ���� ����
        }

        bestScoreText.text = $"�ְ� ����  :  {bestscore}";

        gameUI.SetActive(false);
        scoreUI.SetActive(true);
    }

    public void ExitMiniGame()
    {
        PlayerPrefs.SetInt("PlayedMiniGame", 1);
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        Score = Score + score;
        currentScoreText.text = $"���� ���� : {Score}";
        currentScoreText_ScoreBoard.text = $"���� ����  :  {Score}";
    }


}
