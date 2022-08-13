using Quest.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Quest.Menu
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;
        private GameManager gm;
        private const string Level1 = "Level1";

        private void Start()
        {
            gm = FindObjectOfType<GameManager>();
            startButton.onClick.AddListener(() => SceneManager.LoadScene(Level1));
            exitButton.onClick.AddListener(gm.ExitGame);
        }
    }

}
