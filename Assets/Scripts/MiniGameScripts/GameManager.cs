using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    //���� ����, ����, �׸��� UI�� ���õ� ��� ���� �̰����� �ذ��մϴ�.
{
    public GameObject player;
    //�÷��̾� ����

    public GameObject homeUI;
    public GameObject gameUI;
    public GameObject scoreUI;
    //UI ����

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentScoreText_ScoreBoard;
    public TextMeshProUGUI bestScoreText;
    //UI ���� 2

    static GameManager gameManager;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    int Score = 0;

    private void Awake()
    {
        gameManager = this;
        homeUI.SetActive(true); //Ȩ ui ����
    }

    public void GameStart() //Ȩ Ui ���� ���� ���� Ui Ȱ��ȭ
    {
        player.SetActive(true);
        homeUI.SetActive(false);

        gameUI.SetActive(true);

    }

    public void GameOver() //���� ���� Ui ���� ���� ���� Ui Ȱ��ȭ
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

    public void ExitMiniGame() //�����⸦ ������ ���� ��ũ���� �ٽ� �ҷ���
    {
        PlayerPrefs.SetInt("PlayedMiniGame", 1); //�̴ϰ����� �÷����ߴٰ� ���νſ� �˷���.
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        Score = Score + score;
        currentScoreText.text = $"���� ���� : {Score}";
        currentScoreText_ScoreBoard.text = $"���� ����  :  {Score}";
    }


}
