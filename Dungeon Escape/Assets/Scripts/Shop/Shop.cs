/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private Player _player;

    public int currentSelectedItem;
    public int currentItemPrice;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player not found");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIManager.Instance.OpenShop(_player.diamonds);
            shopPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(94.0f);
                currentSelectedItem = 0;
                currentItemPrice = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-20.0f);
                currentSelectedItem = 1;
                currentItemPrice = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-119.5f);
                currentSelectedItem = 2;
                currentItemPrice = 100;
                break;
        }
    }

    public void BuyItem()
    {
        if (currentSelectedItem == 0 && currentItemPrice == 0)
        {
            currentSelectedItem = 0;
            currentItemPrice = 200;
        }

        if (_player.diamonds >= currentItemPrice)
        {
            switch (currentSelectedItem)
            {
                // flame sword
                case 0:
                    if (_player.hasFlameSword)
                    {
                        shopPanel.SetActive(false);
                        return;
                    }
                    else
                        _player.AwardFlameSword();
                    break;

                // boots of flight
                case 1:
                    if (_player.hasBootsOfFlight)
                    {
                        shopPanel.SetActive(false);
                        return;
                    }
                    else
                        _player.AwardBootsOfFlight();
                    break;

                // key to castle
                case 2:
                    if (GameManager.Instance.HasKeyToCastle)
                    {
                        shopPanel.SetActive(false);
                        return;
                    }
                    else
                        GameManager.Instance.HasKeyToCastle = true;
                    break;
            }

            _player.diamonds -= currentItemPrice;
            UIManager.Instance.OpenShop(_player.diamonds);
            UIManager.Instance.UpdateGemCount(_player.diamonds);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough gems");
            shopPanel.SetActive(false);
        }
    }
}
