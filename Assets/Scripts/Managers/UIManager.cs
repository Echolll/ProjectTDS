using ProjectTDS.UI;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Managers
{
    public class UIManager : MonoBehaviour
    {
        [Inject]
        private LevelManager _levelManager;

        [Header("—ыллки на элементы UI:")]
        [SerializeField]
        private PauseBlock _pauseMenu;
        [SerializeField]
        private EndMissionBlock _endMissionMenu;
        [SerializeField]
        private ConditionBlock _conditionPanel;
        [SerializeField]
        private WeaponBlock _weaponPanel;

        private void OnEnable()
        {
            _pauseMenu.BackToMenuEventHandler += BackToMenu;
            _pauseMenu.RestartSceneEventHandler += RestartScene;
            _pauseMenu.ResumeGameEventHandler += SwitchPauseMenu;

            _endMissionMenu.BackToMenuEventAction += BackToMenu;

            _levelManager.MissonEndEventHandler += MissionEnd;
        }

        private void OnDisable()
        {
            _pauseMenu.BackToMenuEventHandler -= BackToMenu;
            _pauseMenu.RestartSceneEventHandler -= RestartScene;
            _pauseMenu.ResumeGameEventHandler -= SwitchPauseMenu;

            _endMissionMenu.BackToMenuEventAction -= BackToMenu;

            _levelManager.MissonEndEventHandler -= MissionEnd;
        }

        private void BackToMenu()
        {
            if(SceneLoader.Instance != null) SceneLoader.Instance.OnLoadScene("HubMenu", true);
        }

        private void RestartScene()
        {
            if(SceneLoader.Instance != null) SceneLoader.Instance.RestartCurrentScene();
        }
       
        private void OnSwitchBattleUI(bool Activate)
        {
            _conditionPanel.gameObject.SetActive(Activate);
            _weaponPanel.gameObject.SetActive(Activate);
        }

        private void MissionEnd(bool status)
        {      
            OnSwitchBattleUI(false);
            _endMissionMenu.gameObject.SetActive(true);
            _endMissionMenu.MissionEnd(status);
        }

        public void SwitchPauseMenu()
        {
            bool isPause = _pauseMenu.gameObject.activeSelf == true ? false : true;
            OnSwitchBattleUI(!isPause);
            Time.timeScale = isPause ? 0f : 1f;
            _pauseMenu.gameObject.SetActive(isPause);
        }

        
    }
}
