/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    Rigidbody2D _rigid;
    [SerializeField]
    float _jumpForce = 5.5f;
    [SerializeField]
    float _raycastDistance = 0.75f;
    [SerializeField]
    LayerMask _groundLayer;
    bool _resetJump = false;
    [SerializeField]
    float _speed = 2.5f;
    bool _playerfacingRight = true;
    bool _playerGrounded = false;

    PlayerAnimation _playerAnim;
    SpriteRenderer _playerSprite;
    SpriteRenderer _swordArcSprite;

    public int Health { get; set; }

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        if (_rigid == null)
        {
            Debug.LogError("Rigidbody not found on the Player gameobject");
        }

        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * _raycastDistance, Color.green);
        Movement();

        if (Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _playerAnim.Attack();
        }
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _playerGrounded = IsGrounded();

        if (move > 0)
        {
            Flip(_playerfacingRight);
        }
        else if (move < 0)
        {
            // TODO: fix the sprite position when we turn left because the raycast shifts too much to the left
            Flip(!_playerfacingRight);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.Jump(true);
        }

        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);

        _playerAnim.Move(move);
    }

    void Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector2 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.0f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        else if (faceRight == false)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector2 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.0f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _groundLayer);
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
                _playerAnim.Jump(false);
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

    public void Damage()
    {
        Debug.Log("Player Damage()");
    }
}
