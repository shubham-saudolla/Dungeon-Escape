/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    Vector3 _currentTarget;
    SpriteRenderer _mossGiantSprite;
    Animator _anim;

    void Start()
    {
        _mossGiantSprite = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
        if (_mossGiantSprite == null)
        {
            Debug.LogError("Sprite renderer not found");
        }
        if (_anim == null)
        {
            Debug.LogError("Animator not found on the moss giant");
        }
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
        if (transform.position == pointA.position)
        {
            _mossGiantSprite.flipX = false;
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _mossGiantSprite.flipX = true;
            _currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }

    public override void Attack()
    {

    }
}
