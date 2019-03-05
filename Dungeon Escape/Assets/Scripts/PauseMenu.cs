/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        GameManager.Instance.Pause();
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        GameManager.Instance.Resume();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
