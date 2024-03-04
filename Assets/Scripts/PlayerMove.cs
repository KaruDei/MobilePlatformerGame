using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _direction;
    private bool _isGround = false;
    private SpriteRenderer _spriteRenderer;
    private float _raycastDistance = 0.1f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _isGround = IsGround();
        if (_isGround)
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                Debug.Log("Attack");
            else
                State = States.idle;
        else
            State = States.jump;

        _direction = _joystick.GetDirection();

        if (_direction.y > 0.6f && _isGround) {
            Jamp();
        }

        if (_direction.magnitude > 0 && _isGround)
        {
            Move();
        }
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircle(transform.position, _raycastDistance, _groundLayer);
    }

    private void Jamp()
    {
        _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y + _jumpForce));
    }

    private void Move()
    {
        if (_isGround)
        {
            State = States.run;
        }

        if (_direction.x < 0)
            _spriteRenderer.flipX = true;
        else if (_direction.x > 0)
            _spriteRenderer.flipX = false;

        _rigidbody.velocity = transform.TransformDirection(
            (_direction.x * _speed * Time.fixedDeltaTime),
            _rigidbody.velocity.y,
            0
        );
    }

    public void Attack ()
    {
        if (_isGround)
            State = States.attack;
    }

    private States State
    {
        get { return (States)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }
}

public enum States 
{ 
    idle,
    attack,
    run,
    jump,
    death
}