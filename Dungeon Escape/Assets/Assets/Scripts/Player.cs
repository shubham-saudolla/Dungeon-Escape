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
    bool _grounded = false;
    [SerializeField]
    LayerMask _groundLayer;
    bool _resetJumpNeeded = false;

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
        // horizontal input for left and right
        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            _grounded = false;
            _resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance, _groundLayer);
        Debug.DrawRay(transform.position, dir: Vector2.down * _raycastDistance, Color.green);

        // check whether raycast has hit a collider
        if (hitInfo.collider != null)
        {
            if (_resetJumpNeeded == false)
            {
                _grounded = true;
            }
        }

        _rigid.velocity = new Vector2(move, _rigid.velocity.y);
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }
}
