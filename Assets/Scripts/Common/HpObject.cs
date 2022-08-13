using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Common
{
    public class HpObject : MonoBehaviour
    {
        [SerializeField] private int hp;
        private GameManager gm;
        public int Hp => hp;

        private void Start()
        {
            gm = GameManager.FindObjectOfType<GameManager>();
        }

        public void GetDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                if (CompareTag(Constants.EnemyTag))
                    gm.EnemiesLeft--;
                Destroy(gameObject);
            }
        }
    }
}

