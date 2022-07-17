using UnityEngine;

namespace Quest
{
    public class Constants : MonoBehaviour
    {
        private const string playerTag = "Player";
        private const string enemyTag = "Enemy";
        public static string PlayerTag => playerTag;
        public static string EnemyTag => enemyTag;
    }
}

