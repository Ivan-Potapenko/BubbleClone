using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Button _playButton;

        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _exitButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButton);
            _settingsButton.onClick.AddListener(OnSettingsButton);
            _exitButton.onClick.AddListener(OnExitButton);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButton);
            _settingsButton.onClick.RemoveListener(OnSettingsButton);
            _exitButton.onClick.RemoveListener(OnExitButton);
        }


        private void OnPlayButton()
        {

        }

        private void OnExitButton()
        {

        }

        private void OnSettingsButton()
        {

        }
            
    }

}
