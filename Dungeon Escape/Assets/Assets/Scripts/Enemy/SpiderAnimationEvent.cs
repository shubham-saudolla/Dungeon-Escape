/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;

    void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }

    public void Fire()
    {
        _spider.Attack();
    }
}
