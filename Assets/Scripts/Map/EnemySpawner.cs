using UnityEngine;

namespace Quest.Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        private void Awake()
        {
            Instantiate(enemyPrefab, transform);
        }
    }
}
