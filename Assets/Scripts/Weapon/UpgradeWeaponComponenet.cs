using ProjectTDS.Managers;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public class UpgradeWeaponComponenet : MonoBehaviour
    {
        private PlayerManager _player;

        [Header("Корректный/Максимальный уровень улучшения:")]
        [SerializeField]
        private Vector2Int _firstAttributeLevel;
        [SerializeField]
        private Vector2Int _secondAttributeLevel;
        [SerializeField]
        private Vector2Int _thirdAttributeLevel;

        [Header("На какое число улучшиться:")]
        [Space, SerializeField]
        private Vector2 _addingNumberToFirstAttribute;
        [SerializeField]
        private Vector2 _addingNumberToSecondAttribute;
        [SerializeField]
        private Vector2 _addingNumberToThirdAttribute;

        [Header("Цена улучшения:")]
        [Space, SerializeField, Range(1, 3)]
        private float _multiplierCost = 1.5f;

        [field: SerializeField]
        public int CostFirstAttribute { get; private set; }
        [field: SerializeField]
        public int CostSecondAttribute { get; private set; }
        [field: SerializeField]
        public int CostThirdAttribute { get; private set; }
      
        private IUpgradable _upgrade;

        public void Init(IUpgradable upgradable)
        {
            _player = PlayerManager.Instance;
            _upgrade = upgradable;
        }

        public void UpgradeFistAttribute()
        {
            if (_firstAttributeLevel.x >= _firstAttributeLevel.y) return;
            if (!HavePlayerMoney(CostFirstAttribute)) return;
            _firstAttributeLevel.x++;

            _upgrade.FirstUpgradeAttribute((int)_addingNumberToFirstAttribute.x);
            
            _addingNumberToFirstAttribute.x -= _addingNumberToFirstAttribute.y;
            CostFirstAttribute = OnUpCostAfterUpgrade(CostFirstAttribute);
        }

        public void UpgradeSecondAttribute()
        {
            if (_secondAttributeLevel.x >= _secondAttributeLevel.y) return;
            if (!HavePlayerMoney(CostSecondAttribute)) return;
            _secondAttributeLevel.x++;

            _upgrade.SecondUpgradeAttribute(_addingNumberToSecondAttribute.x);

            _addingNumberToSecondAttribute.x -= _addingNumberToSecondAttribute.y;
            CostSecondAttribute = OnUpCostAfterUpgrade(CostSecondAttribute);
        }

        public void UpgradeThirdAttribute()
        {
            if (_thirdAttributeLevel.x >= _thirdAttributeLevel.y) return;
            if (!HavePlayerMoney(CostThirdAttribute)) return;
            _thirdAttributeLevel.x++;

            _upgrade.ThirdUpgradeAttribute(_addingNumberToThirdAttribute.x);

            _addingNumberToThirdAttribute.x -= _addingNumberToThirdAttribute.y;
            CostThirdAttribute = OnUpCostAfterUpgrade(CostThirdAttribute);
        }

        private bool HavePlayerMoney(int cost)
        {
            if (cost < _player.MoneyInBag)
            {
                _player.UpgradeItem(cost);
                return true;
            }
            return false;
        }

        private int OnUpCostAfterUpgrade(int cost)
        {
            float finalcost = (float)cost * _multiplierCost;
            return (int)finalcost;
        }
    }
}