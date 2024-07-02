using UnityEditor;
using UnityEngine;

namespace ProjectTDS.UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        public void NewGameButton_UnityEvent()
        {
            SceneLoader.Instance.OnLoadScene("HubMenu", true);;
        }

        public void ContinueGameButton_UnityEvent()
        {
            //TODO
        }

        public void OpenSettingsPanel_UnityEvent()
        {
            //TODO
        }

        public void ExitGameButton_UnityEvent()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
