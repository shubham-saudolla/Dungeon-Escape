﻿/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public GameObject acidEffectPrefab;

    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Update()
    {
        // Do nothing
    }

    public override void Movement()
    {
        // Do nothing
    }

    public void Damage()
    {
        if (isDead)
            return;

        Health--;

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
