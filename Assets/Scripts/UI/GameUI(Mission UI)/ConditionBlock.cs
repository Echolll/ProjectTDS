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
        private PlayerConditionComponent _condition;

        [SerializeField]
        private FillWidjet _armor;
        [SerializeField]
        private FillWidjet _health;

        private void OnEnable()
        {           
            _condition.UpdateConditionDataEventHandler += ConditionChangeData;
        }

        private void OnDisable()
        {
            _condition.UpdateConditionDataEventHandler -= ConditionChangeData;
        }

        private void Start() => ConditionChangeData();

        private void ConditionChangeData()
        {
            _armor.Text.text = "Armor:" + Mathf.RoundToInt(_condition.ArmorPoints).ToString();
            _armor.Fill.fillAmount = _condition.ArmorPoints / _condition.GetMaxArmor;

            _health.Text.text = "Health:" + Mathf.RoundToInt(_condition.HealthPoints).ToString();
            _health.Fill.fillAmount = _condition.HealthPoints / _condition.GetMaxArmor;
        }

        [System.Serializable]
        private struct FillWidjet
        {
            public Image Fill;
            public TextMeshProUGUI Text;
        }
    }
}


