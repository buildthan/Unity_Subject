using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacles : MonoBehaviour
{
    public Transform Object;

    public float widthPadding;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        widthPadding = Random.Range(3,10);
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);

        transform.position = placePosition;

        return placePosition;
    }
}
