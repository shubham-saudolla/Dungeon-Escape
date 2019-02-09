/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    Vector3 _currentTarget;
    SpriteRenderer _spiderSprite;
    Animator _anim;

    void Start()
    {
        _spiderSprite = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        Movement();
    }

    void Movement()
    {
        if (_currentTarget == pointA.position)
        {
            _spiderSprite.flipX = true;
        }
        else
        {
            _spiderSprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }
}
