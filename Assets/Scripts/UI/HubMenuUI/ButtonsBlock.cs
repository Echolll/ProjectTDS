using System;
using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    public class ButtonsBlock : MonoBehaviour
    {
        public event Action OpenMissionListEventHandler;
        public event Action OpenShopBlockEventHandler;

        public void OnOpenMissionList_UnityEvent()
        {
            OpenMissionListEventHandler?.Invoke();
        }

        public void OnOpenShopPanel_UnityEvent()
        {
            OpenShopBlockEventHandler?.Invoke();
        }

        public void OnBackMenu_UnityEvent()
        {
            SceneLoader.Instance.OnLoadScene("MainMenu", true);
        }
    }
}
