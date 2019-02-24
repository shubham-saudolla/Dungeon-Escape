/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _playerAnim;
    Animator _swordAnim;

    void Start()
    {
        _playerAnim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        if (_swordAnim == null)
        {
            Debug.LogError("swordAnim not found");
        }
    }

    public void Move(float move)
    {
        _playerAnim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool isJumping)
    {
        _playerAnim.SetBool("Jumping", isJumping);
    }

    public void Attack()
    {
        _playerAnim.SetTrigger("Attack");
        _swordAnim.SetTrigger(name: "SwordAnimation");
    }
}
