/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Player _player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered the trigger");
            _player = other.GetComponent<Player>();

            if (GameManager.Instance.HasKeyToCastle)
            {
                Debug.Log("Inside the if block");
                GameManager.Instance.CompleteGame();
            }
            else
            {
                Debug.Log("in else");
            }
        }
    }
}
