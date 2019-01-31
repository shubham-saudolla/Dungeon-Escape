/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigid;

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
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _rigid.velocity = new Vector2(horizontalInput, _rigid.velocity.y);
    }
}
