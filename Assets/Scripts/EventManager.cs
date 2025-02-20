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

        bestScoreText.text = $"���� �ְ� ����  :  {bestscore}";
        resultUIText.text = $"���� �ְ� ����  :  {bestscore}";

        if (PlayerPrefs.GetInt("PlayedMiniGame") == 1) //�̴ϰ����� �÷����ϰ� �� ���
        {
            PlayerPrefs.SetInt("PlayedMiniGame", 0);
            resultUI.SetActive(true);
        }

    }

    public void NewClick() //��ư Ŭ�� �̺�Ʈ�� ���� �Լ��� ����� �ش�.
    {
        Debug.Log("�̰Ž���");
        SceneManager.LoadScene("MiniGame");
    }

    public void CloseClick()
    {
        resultUI.SetActive(false);
    }
}