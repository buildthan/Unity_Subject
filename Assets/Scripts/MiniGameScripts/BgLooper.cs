using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        Obstacles[] obstacles = GameObject.FindObjectsOfType<Obstacles>();
        //��ֹ��� �迭�� �ο�
        obstacleLastPosition = obstacles[0].transform.position;
        //������ ��ֹ� ��ġ�� ����
        obstacleCount = obstacles.Length;
        //��ֹ��� ���� ����

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
            //obstacles.cs�� ����Ǿ��ִ� setRandomPlace �Լ��� �ҷ���
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Obstacles obstacle = collision.GetComponent<Obstacles>();

        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        //obstacle�� �ε�ģ ���
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
            //obstacles.cs�� ����Ǿ��ִ� setRandomPlace �Լ��� �ҷ���
        }
    }
}
