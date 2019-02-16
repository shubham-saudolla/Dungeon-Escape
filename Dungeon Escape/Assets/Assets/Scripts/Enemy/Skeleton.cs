/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("Skeleton Damage() Health is " + Health);

        Health--;

        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
