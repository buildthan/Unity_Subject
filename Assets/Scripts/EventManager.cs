using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public void ButtonClick() //��ư Ŭ�� �̺�Ʈ�� ���� �Լ��� ����� �ش�.
    {

        SceneManager.LoadScene("MiniGame");
    }
}