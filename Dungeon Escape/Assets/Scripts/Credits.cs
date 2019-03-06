/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject creditsOptionsPanel;

    void Start()
    {
        creditsOptionsPanel.GetComponent<Animator>().SetTrigger("ShowButtons");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void CreditsButton()
    {
        Debug.Log("Show credits");
    }
}
