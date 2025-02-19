using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public Transform player;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.position.x - transform.position.x) < 1f &&
           Mathf.Abs(player.position.y - transform.position.y) < 1f)
        {
            ui.SetActive(true);
        }else
        {
            ui.SetActive(false);
        }
    }
}
