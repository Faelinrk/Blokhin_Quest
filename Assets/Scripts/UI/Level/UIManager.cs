using System;
using Quest.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Quest.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button backButton;
        [SerializeField] private Button exitButton;
        private GameManager gm;
        private bool isPaused;
        private float lastHP;
        private HpObject playerHp;
        private const string MenuButton = "MenuButton";

        private void Awake()
        {
            gm = FindObjectOfType<GameManager>();
            playerHp = GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<HpObject>();
            
        }

        private void Start()
        {
            soundSlider.value = AudioListener.volume;
            lastHP = playerHp.Hp;
            healthSlider.maxValue = lastHP;
            healthSlider.value = lastHP;
            
            settingsButton.onClick.AddListener(OpenSettings);
            backButton.onClick.AddListener(CloseSettings);
            exitButton.onClick.AddListener(gm.ExitGame);
            soundSlider.onValueChanged.AddListener(vol => AudioListener.volume = vol);

        }

        private void CloseSettings()
        {
            pausePanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        private void OpenSettings()
        {
            pausePanel.SetActive(false);
            settingsPanel.SetActive(true);
        }


        private void Update()
        {
            ManageHpSlider();
            if (Input.GetButtonDown(MenuButton))
            {
                OpenPauseMenu();
            }
        }

        private void OpenPauseMenu()
        {
            isPaused = !isPaused;
            pausePanel.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
            Cursor.lockState = isPaused ? CursorLockMode.Confined : CursorLockMode.Locked;
        }

        private void ManageHpSlider()
        {
            if (playerHp.Hp != lastHP)
            {
                lastHP = playerHp.Hp;
                healthSlider.value = lastHP;
            }
        }

    }
}

