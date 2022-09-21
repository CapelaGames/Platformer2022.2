using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _jumpForce = 400f;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private SpriteRenderer _sprite;
    private Animator _animator;
    public float _xAxis = 0;
    //private float _yAxis = 0;
    private bool _jump = false;
    private bool _isGrounded = false;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = GroundedCheck();
        
        _rigidbody.velocity = new Vector2(_xAxis * _speed * Time.deltaTime,
                                        _rigidbody.velocity.y);

        if (_jump && _isGrounded)
        {
            _rigidbody.AddForce(new Vector2(0f,_jumpForce));
            _jump = false;
        }

        if (_isGrounded)
        {
            _animator.SetBool("isJumping", false);
        }
        else
        {
            _animator.SetBool("isJumping", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Input always in update
        _xAxis = Input.GetAxis("Horizontal");
        //_yAxis = Input.GetAxis("Vertical");

        if (_jump == false)
        {
            _jump = Input.GetButtonDown("Jump");
        }

        if (_xAxis > 0)
        {
            _sprite.flipX = false;
            _animator.SetBool("isWalking", true);
        }
        else if (_xAxis < 0)
        {
            _sprite.flipX = true;
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    
    bool GroundedCheck()
    {
        //Find bottom of sprite
        //Half the size of the collider (y axis)
        float newY = transform.position.y - _collider.bounds.extents.y;
        Vector2 bottom = new Vector2(transform.position.x, newY);
        
        //_collider.bounds.min.y
        
        //Find width of sprite
        float width = _collider.bounds.size.y;

        Collider2D[] hits = Physics2D.OverlapBoxAll(bottom, 
            new Vector2(width - 0.2f, 0.4f),
            0f);
        /*
        //testing----
        pos = bottom;
        size = new Vector2(width, 0.4f);
        */

        
        foreach (Collider2D hit in hits)
        {
            Bullet bullet = hit.GetComponent<Bullet>();
            
            //In 2d the gameobject can hit itself, (hit would be this gameobject the code
            //is attached to)
            //in 3d the gameobject cant hit itself
            if (hit.gameObject != gameObject 
                && bullet == null)
            {
                return true;
            }
        }
        return false;
        
        
        /*for (int x = 0; x < hits.Length; x++)
        {
            Collider2D hit = hits[x];
            //code here
            
        }

        int x = 0;
        while (x < hits.Length)
        {
            Collider2D hit = hits[x];
            
            //code here
            
            x++;
        }*/
    }
    
    /*//testing----
    private Vector2 pos = Vector2.zero;
    private Vector2 size = Vector2.zero;
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(pos,size);
    }*/
}
