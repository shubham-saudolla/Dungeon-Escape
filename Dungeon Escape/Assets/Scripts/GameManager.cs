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

    [HideInInspector]
    public bool isPaused = false;

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

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
