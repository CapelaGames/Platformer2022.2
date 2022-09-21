using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent or base class of EnemySinMovement
public class EnemyMovement : MonoBehaviour
{
    //think of protected to be exactly like private
    //except...
    protected Rigidbody2D _rb2D;
    protected SpriteRenderer _sprite;
    protected Vector2 _velocity;

    [SerializeField] protected float _speed = 1f;
    [SerializeField] protected bool _isMovingRight = true;
    
    [SerializeField] protected float _leftXBoundsOffset = -1;
    [SerializeField] protected float _rightXBoundsOffset = 1;
    protected float _leftXBound = 0;
    protected float _rightXBound = 0;

    protected Vector2 previousPosition;
    protected float prevPosTime = float.MinValue;
    
    protected void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    
    protected void OnEnable()
    {
        _velocity = Vector2.zero;
        _leftXBound = transform.position.x + _leftXBoundsOffset;
        _rightXBound = transform.position.x + _rightXBoundsOffset;
    }

    //If dealing with physics, Use FixedUpdate instead of Update
    protected void FixedUpdate()
    {
        if (_rb2D.position.x > _rightXBound)
        {
            _isMovingRight = false;
        }
        else if(_rb2D.position.x < _leftXBound)
        {
            _isMovingRight = true;
        }

        MoveEnemy();
    }

    protected virtual void MoveEnemy()
    {
        //we can shorten with a ternary operator
        if (_isMovingRight)
        {
            _velocity.x = _speed;
            _sprite.flipX = false;
        }
        else
        {
            _velocity.x = -_speed;
            _sprite.flipX = true;
        }

        _rb2D.MovePosition(_rb2D.position + (_velocity * Time.deltaTime));
    }


   // protected Vector2 previousPosition;
    //protected float prevPosTime = float.MinValue;

    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        previousPosition = transform.position;
        prevPosTime = Time.time;
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (Vector2.Distance(previousPosition, transform.position) < 0.01f
            && prevPosTime + 0.1f > Time.time)
        {
            _isMovingRight = !_isMovingRight;
        }
    }

    protected virtual void OnCollisionExit2D(Collision2D other)
    {
        previousPosition = Vector2.zero;
        prevPosTime = float.MinValue;
    }
}
