/*
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
    float _raycastDistance = 0.6f;
    [SerializeField]
    LayerMask _groundLayer;
    bool _resetJump = false;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();

        if (_rigid == null)
        {
            Debug.LogError("Rigidbody not found on the Player gameobject");
        }
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        // horizontal input for left and right
        float move = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(move, _rigid.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("Jump");
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
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
