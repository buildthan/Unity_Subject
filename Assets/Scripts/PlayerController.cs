using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�ش� ��ũ��Ʈ������ ĳ���Ͱ� �ٶ󺸴� ������ �÷��̾ ���� Ű���忡 ���� �����ǰԲ� ������־����ϴ�.
    Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    Vector2 movement = Vector2.zero;

    protected AnimationHandler animationHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //Ű���� AD
        float vertical = Input.GetAxisRaw("Vertical"); //Ű���� WS
        movement = new Vector2(horizontal, vertical).normalized;
        movement = movement * 5;
        _rigidbody.velocity = movement; //Ű���带 ���� �������� �����ϰ� ������
        animationHandler.Move(movement); 

        if (horizontal > 0) //�������� ���� ���
        {
            _spriteRenderer.flipX = false;
        }
        else if(horizontal<0) //������ ���� ���
        {
            _spriteRenderer.flipX = true;
        }

    }
}
