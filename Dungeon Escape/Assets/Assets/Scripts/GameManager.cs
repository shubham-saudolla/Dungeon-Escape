/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public Player player { get; private set; }

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public bool HasKeyToCastle { get; set; }

    void Awake()
    {
        _instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
