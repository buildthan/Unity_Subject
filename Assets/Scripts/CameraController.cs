using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camera;
    float difference_X;
    float difference_Y;
    bool isYblocked = false;
    bool isXblocked = false;

    // Start is called before the first frame update
    void Start()
    {
        difference_X = camera.position.x - transform.position.x;
        difference_Y = camera.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYblocked == false)
        {
            Vector3 temp = camera.position;
            temp.y = transform.position.y + difference_Y;
            camera.position = temp;
        }
        if (isXblocked == false)
        {
            Vector3 temp = camera.position;
            temp.x = transform.position.x + difference_X;
            camera.position = temp;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraBlock_Y"))
        {
            Debug.Log("Block");
            isYblocked = true;
        }

        if (collision.CompareTag("CameraBlock_X"))
        {
            Debug.Log("Block");
            isXblocked = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraBlock_Y"))
        {
            Debug.Log("NoBlock");
            isYblocked = false;
        }

        if (collision.CompareTag("CameraBlock_X"))
        {
            Debug.Log("NoBlock");
            isXblocked = false;
        }
    }
}
