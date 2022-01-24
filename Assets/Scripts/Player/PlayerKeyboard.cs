using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboard : MonoBehaviour
{
    [SerializeField] private AnimationsSinc _anim;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private float _speed;
    [SerializeField] private float _health, _maxHealth, _damag;
    private bool _isAttack = false;
    
    void Start()
    {
        
    }

    void moveTo(Vector2 v)
    {
        if (!_isAttack)
        {
            v = v.normalized;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _rb.velocity = v * _speed * 2;
            }
            else
            {
                _rb.velocity = v * _speed;
            }
        }
    }

    void animation(Vector2 v)
    {
        string name = "idle";
        if (v.x != 0)
        {
            name = "walk";
            if (v.x < 0)
            {
                _sr.flipX = true;
            }
            else
            {
                _sr.flipX = false;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                name = "run";
            }
        }

        if (v.y != 0)
        {
            name = "jump";
        }
        if(!_isAttack) _anim.SetAnimation(name);
    }

    void attack()
    {
        _isAttack = true;
        _anim.SetAnimation("attack_foot");
    }

    void sit()
    {
        _isAttack = true; 
        _anim.SetAnimation("sit");
    }
    
    void Update()
    {
        if (_isAttack)
        {
            string tmp = _anim.GetState();
            if (tmp == "idle") _isAttack = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            attack();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            sit();
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            _isAttack = false;
        }

        if (!_isAttack)
        {
            Vector2 v2 = new Vector2();
            if (Input.GetKey(KeyCode.A)) v2.x -= 1;
            if (Input.GetKey(KeyCode.D)) v2.x += 1;
            if (Input.GetKey(KeyCode.W)) v2.y += 1;
            if (Input.GetKey(KeyCode.S)) v2.y -= 1;
            moveTo(v2);
            animation(v2);
        }
    }
}
