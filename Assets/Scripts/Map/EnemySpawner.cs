using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest.Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        void Start()
        {
            Instantiate(enemyPrefab, transform);
        }
        
    }
}

