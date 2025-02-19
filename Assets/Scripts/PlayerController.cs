using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
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
