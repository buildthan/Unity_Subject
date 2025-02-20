using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public GameObject resultUI;

    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI resultUIText;
    void Start()
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

        bestScoreText.text = $"현재 최고 점수  :  {bestscore}";
        resultUIText.text = $"현재 최고 점수  :  {bestscore}";

        if (PlayerPrefs.GetInt("PlayedMiniGame") == 1) //미니게임을 플레이하고 온 경우
        {
            PlayerPrefs.SetInt("PlayedMiniGame", 0);
            resultUI.SetActive(true);
        }

    }

    public void NewClick() //버튼 클릭 이벤트에 대한 함수를 만들어 준다.
    {
        Debug.Log("이거실행");
        SceneManager.LoadScene("MiniGame");
    }

    public void CloseClick()
    {
        resultUI.SetActive(false);
    }
}