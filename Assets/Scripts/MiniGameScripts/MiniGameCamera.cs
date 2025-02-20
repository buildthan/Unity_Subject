using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MiniGameCamera : MonoBehaviour
{
    public Transform player;
    float difference_X;

    // Start is called before the first frame update
    void Start()
    {
        difference_X = transform.position.x - player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x + difference_X;
        transform.position = temp;
    }
}
