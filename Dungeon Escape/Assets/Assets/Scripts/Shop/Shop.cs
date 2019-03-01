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

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            UIManager.Instance.OpenShop(player.diamonds);
        }

        if (other.tag == "Player")
        {
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
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-20.0f);
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-119.5f);
                break;
        }
    }
}
