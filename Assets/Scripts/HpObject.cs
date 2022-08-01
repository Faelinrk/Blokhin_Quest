using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Common
{
    public class HpObject : MonoBehaviour
    {
        [SerializeField] private int hp;

        public void GetDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

