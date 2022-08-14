using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quest.Common
{
    public class GameManager : MonoBehaviour
    {
        private int enemiesLeft;
        public int EnemiesLeft
        {
            get { return enemiesLeft; }
            set
            {
                enemiesLeft = value;
                if (value==0) NextLevel();
            }
        }

        private void Start()
        {
            enemiesLeft = GameObject.FindGameObjectsWithTag(Constants.EnemyTag).Length;
            Debug.Log(enemiesLeft);
        }

        public void NextLevel()
        {
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextLevelIndex+1<=SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextLevelIndex);
            else
            {
                ExitGame();
            }
        }
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
    
}


