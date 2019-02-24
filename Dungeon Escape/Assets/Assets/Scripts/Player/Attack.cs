/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_canDamage == true)
            {
                hit.Damage();
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
        }
    }

    private IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.3f);
        _canDamage = true;
    }
}
