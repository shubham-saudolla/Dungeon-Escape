/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [HideInInspector]
    public bool isPaused = false;

    public Player player { get; private set; }

    public GameObject completedGamePanel;

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

    public void CompleteGame()
    {
        StartCoroutine(Complete());
    }

    IEnumerator Complete()
    {
        yield return new WaitForSeconds(1.0f);
        completedGamePanel.SetActive(true);
        completedGamePanel.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Credits");
    }
}
