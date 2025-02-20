using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePlayerController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    GameManager manager;

    public float jumpForce = 10f;
    public float forwardSpeed = 5f;
    public bool isDie = false;

    bool isJump = false;
    bool isInAir = true;

    public bool godMode = false;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.Instance;
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isDie) //�������
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                manager.ExitMiniGame();
            }
        }
        else //���� �ʾҴٸ�
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isJump == false)
            {
                isJump = true;
            }
        }
    }
    

    public void FixedUpdate()
    {
        if (isDie) //�̹� �׾��ٸ� ���� �������� �ʴ´�.
        {
            return;
        }

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isJump && !isInAir ) //�ߺ������� �����ϱ� ���� isInAir ����
        {
            velocity.y += jumpForce;
            isInAir = true;
        }

        _rigidbody.velocity = velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isJump = false;
        isInAir = false;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (godMode)
                return;

            if (isDie)
                return;

            animator.SetBool("IsDie", true);
            isDie = true;
        }
    }

}
