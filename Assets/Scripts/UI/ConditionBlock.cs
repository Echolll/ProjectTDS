using ProjectTDS.Unit.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectTDS.UI
{
    public class ConditionBlock : MonoBehaviour
    {
        [Inject]
        private PlayerUnitComponent _player;

        [SerializeField]
        private FillWidjet _armor;
        [SerializeField]
        private FillWidjet _health;

        private void OnEnable()
        {           
            var player = _player._condition as PlayerConditionComponent;
            player.UpdateConditionDataEventHandler += ConditionChangeData;
        }

        private void OnDisable()
        {
            var player = _player._condition as PlayerConditionComponent;
            player.UpdateConditionDataEventHandler += ConditionChangeData;
        }

        private void Start() => ConditionChangeData();

        private void ConditionChangeData()
        {
            _armor.Text.text = "Armor:" + Mathf.RoundToInt(_player._condition.ArmorPoints).ToString();
            _armor.Fill.fillAmount = _player._condition.ArmorPoints / 100;

            _health.Text.text = "Health:" + Mathf.RoundToInt(_player._condition.HealthPoints).ToString();
            _health.Fill.fillAmount = _player._condition.HealthPoints / 100;
        }

        [System.Serializable]
        private struct FillWidjet
        {
            public Image Fill;
            public TextMeshProUGUI Text;
        }
    }
}


