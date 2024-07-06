using ProjectTDS.Managers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTDS.UI
{
    public class EndMissionBlock : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _missionStatusText;
        [SerializeField]
        private TextMeshProUGUI _rewardText;
        [SerializeField]
        private Button _backToMenu;

        public event Action BackToMenuEventAction;

        public void MissionEnd(bool playerWin, float multiply, int killedEnemies, int money)
        {
            _missionStatusText.text = playerWin ? "<color=green>mission complete</color>" : "<color=red>mission failed</color>";

            int totalMoney = (int)((killedEnemies * money) * multiply);

            _rewardText.text = $"TOTAL KILLED:{killedEnemies}*{money} \nGet Money:{totalMoney}";

            PlayerManager.Instance.AddMoneyToBug(totalMoney);
        }

        public void BackToMenu_UnityEvent()
        {
            BackToMenuEventAction?.Invoke();
        }  
    }
}
