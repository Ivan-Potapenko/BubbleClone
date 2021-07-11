using UnityEngine;
using UnityEngine.UI;
using Events;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;


        [SerializeField]
        private Button _continueButton;

        [SerializeField]
        private Button _newGameButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private EventListener _nextLevelEventListner;

        [SerializeField]
        private GameObject _menu;

        [SerializeField]
        private GameObject _settings;

        [SerializeField]
        private GameObject _game;

        [SerializeField]
        private GameObject _pause;

        [SerializeField]
        private GameObject _updateManager;

        private int _savedLevelNum = 1;

        private string _filePath;

        private const string LEVEL_NUM = "LEVEL_NUM";




        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(OnContinueButton);

            _newGameButton.onClick.AddListener(OnNewGameButton);
            _settingsButton.onClick.AddListener(OnSettingsButton);
            _exitButton.onClick.AddListener(OnExitButton);
            _nextLevelEventListner.ActionsToDo += NextLevel;

        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(OnContinueButton);
            _newGameButton.onClick.RemoveListener(OnNewGameButton);
            _settingsButton.onClick.RemoveListener(OnSettingsButton);
            _exitButton.onClick.RemoveListener(OnExitButton);
            _nextLevelEventListner.ActionsToDo -= NextLevel;
        }

        private void OnContinueButton()
        {
            if (PlayerPrefs.HasKey(LEVEL_NUM))
            {
                _savedLevelNum = PlayerPrefs.GetInt(LEVEL_NUM);
                LoadLevel();
            }
            else
            {
                OnNewGameButton();
                return;
            }
        }

        private void NextLevel()
        {
            _savedLevelNum++;
            Save();
            LoadLevel();
        }

        private void Save()
        {
            PlayerPrefs.SetInt(LEVEL_NUM, _savedLevelNum);
        }

        private void OnNewGameButton()
        {
            PlayerPrefs.DeleteKey(LEVEL_NUM);
            _savedLevelNum = 1;
            LoadLevel();
        }

        private void LoadLevel()
        {
            TurnOffAllElements();
            _game.SetActive(true);
            SceneManager.LoadScene(_savedLevelNum);
        }

        private void OnExitButton()
        {
            Application.Quit();
        }

        private void OnSettingsButton()
        {

        }

        private void TurnOffAllElements()
        {
            _menu.SetActive(false);
            _game.SetActive(false);
            _settings.SetActive(false);
        }

    }

}
