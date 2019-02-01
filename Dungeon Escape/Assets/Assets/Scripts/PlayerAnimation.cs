/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();

    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        _anim.SetBool("Jumping", isJumping);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }
}
