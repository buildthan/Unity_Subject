using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    //게임 진행, 점수, 그리고 UI와 관련된 모든 것을 이곳에서 해결합니다.
{
    public GameObject player;
    //플레이어 관련

    public GameObject homeUI;
    public GameObject gameUI;
    public GameObject scoreUI;
    //UI 관련

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentScoreText_ScoreBoard;
    public TextMeshProUGUI bestScoreText;
    //UI 관련 2

    static GameManager gameManager;
    public static GameManager Instance
    {
        get { return gameManager; }
    }

    int Score = 0;

    private void Awake()
    {
        gameManager = this;
        homeUI.SetActive(true); //홈 ui 생성
    }

    public void GameStart() //홈 Ui 끄고 게임 진행 Ui 활성화
    {
        player.SetActive(true);
        homeUI.SetActive(false);

        gameUI.SetActive(true);

    }

    public void GameOver() //게임 진행 Ui 끄고 점수 보드 Ui 활성화
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
            PlayerPrefs.SetInt("BestScore", Score); //최고 점수 저장
        }

        bestScoreText.text = $"최고 점수  :  {bestscore}";

        gameUI.SetActive(false);
        scoreUI.SetActive(true);
    }

    public void ExitMiniGame() //나가기를 누르면 메인 스크린을 다시 불러옴
    {
        PlayerPrefs.SetInt("PlayedMiniGame", 1); //미니게임을 플레이했다고 메인신에 알려줌.
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        Score = Score + score;
        currentScoreText.text = $"현재 점수 : {Score}";
        currentScoreText_ScoreBoard.text = $"현재 점수  :  {Score}";
    }


}
