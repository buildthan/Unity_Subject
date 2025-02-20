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
           Mathf.Abs(player.position.y - transform.position.y) < 1f) // 플레이어가 접근해 온다면
        {
            ui.SetActive(true); //npc ui 활성화
        }else
        {
            ui.SetActive(false); //플레이어가 접근하지 않았다면 npc ui 비활성화
        }
    }
}
