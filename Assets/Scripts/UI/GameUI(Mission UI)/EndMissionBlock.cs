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

        public void MissionEnd(bool playerWin)
        {
            _missionStatusText.text = playerWin ? "<color=green>mission complete</color>" : "<color=red>mission failed</color>";           
            _rewardText.text = 
                "Enemy with knife \nEnemy with knife \nEnemy with knife \nEnemy with knife"
            ;
        }

        public void BackToMenu_UnityEvent()
        {
            BackToMenuEventAction?.Invoke();
        }  
    }
}
