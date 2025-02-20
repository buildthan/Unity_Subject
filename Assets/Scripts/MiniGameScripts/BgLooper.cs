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
        //장애물을 배열에 부여
        obstacleLastPosition = obstacles[0].transform.position;
        //마지막 장애물 위치를 저장
        obstacleCount = obstacles.Length;
        //장애물의 개수 저장

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
            //obstacles.cs에 저장되어있는 setRandomPlace 함수를 불러옴
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

        //obstacle에 부딪친 경우
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
            //obstacles.cs에 저장되어있는 setRandomPlace 함수를 불러옴
        }
    }
}
