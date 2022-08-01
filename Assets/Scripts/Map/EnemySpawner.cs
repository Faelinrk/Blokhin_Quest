using UnityEngine;

namespace Quest.Map
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        private void Start()
        {
            Instantiate(enemyPrefab, transform);
        }
    }
}
