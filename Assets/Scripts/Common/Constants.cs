using UnityEngine;

namespace Quest
{
    public class Constants : MonoBehaviour
    {
        private const string playerTag = "Player";
        private const string enemyTag = "Enemy";
        private const string bulletTag = "Bullet";
        public static string PlayerTag => playerTag;
        public static string EnemyTag => enemyTag;
        public static string BulletTag => bulletTag;
    }
}

