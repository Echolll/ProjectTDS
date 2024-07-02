using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    public class UIManagerInHub : MonoBehaviour
    {
        [SerializeField]
        private ButtonsBlock _buttons;
        [SerializeField]
        private ShopPanel _shopPanel;
        [SerializeField]
        private MissionListBlock _missionBlock;

        private void OnEnable()
        {
            _buttons.OpenShopBlockEventHandler += OpenShopPanel;
            _buttons.OpenMissionListEventHandler += OpenMissionPanel;

            OpenMissionPanel();
        }

        private void OnDisable()
        {
            _buttons.OpenShopBlockEventHandler -= OpenShopPanel;
            _buttons.OpenMissionListEventHandler -= OpenMissionPanel;
        }

        private void OpenShopPanel()
        {
            _shopPanel.SwitchShopPanel(true);
            _missionBlock.gameObject.SetActive(false);
        }

        private void OpenMissionPanel()
        {
            _missionBlock.gameObject.SetActive(true);
            _shopPanel.SwitchShopPanel(false);          
        }
    }
}
