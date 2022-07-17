using System;
using System.Collections;
using System.Collections.Generic;
using Quest;
using Quest.Common;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Constants.EnemyTag))
        {
            if (other.gameObject.TryGetComponent<HpObject>(out HpObject hpObject))
            {
                hpObject.GetDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
