/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public Text playerGemCountText;
    public Image selectionImage;
    public Text gemCount;
    public Image[] healthBars;
    public Image aButton;
    public Image bButton;
    private Color temp;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        UpdateButtonAlpha();
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(float yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCount.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }

    // TODO: isolate this method in a button script
    public void UpdateButtonAlpha()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button"))
        {
            temp = aButton.color;
            temp.a = 1f;
            aButton.color = temp;
        }
        else if (CrossPlatformInputManager.GetButtonDown("B_Button"))
        {
            temp = bButton.color;
            temp.a = 1f;
            bButton.color = temp;
        }
        else if (CrossPlatformInputManager.GetButtonUp("A_Button"))
        {
            temp = aButton.color;
            temp.a = (float)150 / 256;
            aButton.color = temp;
        }
        else if (CrossPlatformInputManager.GetButtonUp("B_Button"))
        {
            temp = bButton.color;
            temp.a = (float)150 / 256;
            bButton.color = temp;
        }
    }
}
