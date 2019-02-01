﻿/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigid;
    [SerializeField]
    float _jumpForce = 5f;
    [SerializeField]
    float _raycastDistance = 0.9f;
    [SerializeField]
    LayerMask _groundLayer;
    bool _resetJump = false;
    [SerializeField]
    float _speed = 2.5f;
    bool _playerfacingRight = true;

    PlayerAnimation _playerAnim;
    SpriteRenderer _playerSprite;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        if (_rigid == null)
        {
            Debug.LogError("Rigidbody not found on the Player gameobject");
        }

        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        // to visualise the raycast
        Debug.DrawRay(transform.position, Vector2.down * _raycastDistance, Color.green);
        Movement();
    }

    void Movement()
    {
        // horizontal input for left and right
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
        {
            Flip(_playerfacingRight);
        }
        else if (move < 0)
        {
            Flip(!_playerfacingRight);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _groundLayer);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
