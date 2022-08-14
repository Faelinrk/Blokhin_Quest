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
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button backButton;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;
        private GameManager gm;
        private const string Level1 = "Level1";

        private void Start()
        {
            soundSlider.value = AudioListener.volume;
            gm = FindObjectOfType<GameManager>();
            startButton.onClick.AddListener(() => SceneManager.LoadScene(Level1));
            exitButton.onClick.AddListener(gm.ExitGame);
            
            settingsButton.onClick.AddListener(OpenSettings);
            backButton.onClick.AddListener(CloseSettings);
            soundSlider.onValueChanged.AddListener(vol => AudioListener.volume = vol);
        }
        private void CloseSettings()
        {
            menuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        private void OpenSettings()
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
    }

}
