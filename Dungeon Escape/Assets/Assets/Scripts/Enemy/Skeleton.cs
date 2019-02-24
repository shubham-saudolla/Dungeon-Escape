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
        Health--;

        Debug.Log("Skeleton Damage() Health is " + Health);

        anim.SetTrigger("Hit");
        isHit = true;

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
