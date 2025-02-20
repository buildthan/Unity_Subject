using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //해당 스크립트에서는 캐릭터가 바라보는 방향을 플레이어가 누른 키보드에 따라 결정되게끔 만들어주었습니다.
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
        float horizontal = Input.GetAxisRaw("Horizontal"); //키보드 AD
        float vertical = Input.GetAxisRaw("Vertical"); //키보드 WS
        movement = new Vector2(horizontal, vertical).normalized;
        movement = movement * 5;
        _rigidbody.velocity = movement; //키보드를 누른 방향으로 일정하게 움직임
        animationHandler.Move(movement); 

        if (horizontal > 0) //오른쪽을 향한 경우
        {
            _spriteRenderer.flipX = false;
        }
        else if(horizontal<0) //왼쪽을 향한 경우
        {
            _spriteRenderer.flipX = true;
        }

    }
}
