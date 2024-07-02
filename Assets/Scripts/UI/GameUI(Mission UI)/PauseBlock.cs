using ProjectTDS.Managers;
using ProjectTDS.Unit.Player;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectTDS.UI
{
    public class PauseBlock : MonoBehaviour
    {
        [Inject]
        private UIManager _uiManager;
        [Inject]
        private PlayerInputComponent _playerInput;

        [SerializeField]
        private Button _resumeGame;
        [SerializeField]
        private Button _restartGame;
        [SerializeField]
        private Button _backToMenu;
        [SerializeField]
        private Button _exitApplication;

        public event Action RestartSceneEventHandler;
        public event Action BackToMenuEventHandler;
        public event Action ResumeGameEventHandler;

        private void OnEnable() => _playerInput.SwitchPlayerInput(false);

        private void OnDisable() => _playerInput.SwitchPlayerInput(true);

        public void BackToMenu_UnityEvent() => BackToMenuEventHandler?.Invoke();

        public void RestartScene_UnityEvent() => RestartSceneEventHandler?.Invoke();

        public void ExitApplication_UnityEvent()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void ResumeGame_UnityEvent() => ResumeGameEventHandler?.Invoke();
    }
}
