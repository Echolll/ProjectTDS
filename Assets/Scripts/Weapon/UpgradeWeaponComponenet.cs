using ProjectTDS.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpgradeWeaponComponenet : MonoBehaviour
{
    private PlayerManager _player;

    [Header("Максимальный уровень улучшения:")]
    [SerializeField,Range(5,10)]
    private int _firstAttributeMaxLevel = 5;
    [SerializeField, Range(5, 10)]
    private int _secondAttributeMaxLevel = 5;
    [SerializeField, Range(5, 10)]
    private int _thirdAttributeMaxLevel = 5;

    [Header("Цена улучшения:")]
    [Space, SerializeField,Range(1,3)]
    private float _multiplierCost = 1.5f;

    [field : SerializeField]
    public int CostFirstAttribute { get; private set; }
    [field : SerializeField]
    public int CostSecondAttribute { get; private set; }
    [field : SerializeField]
    public int CostThirdAttribute { get; private set; }

    [Header("На какое число улучшиться:")]
    [Space, SerializeField]
    private float _addingNumberToFirstAttribute;
    [SerializeField]
    private float _addingNumberToSecondAttribute;
    [SerializeField]
    private float _addingNumberToThirdAttribute;

    [Space, SerializeField]
    private float _UpgradeAddingNumberToFirstAttribute;
    [SerializeField]
    private float _UpgradeAddingNumberToSecondAttribute;
    [SerializeField]
    private float _UpgradeAddingNumberToThirdAttribute;

    [Space,SerializeField]
    private int _firstAttributeLevel;
    [SerializeField]
    private int _secondAttributeLevel;
    [SerializeField]
    private int _thirdAttributeLevel;

    private IUpgradable _upgrade;

    public void Init(IUpgradable upgradable)
    {
        _player = PlayerManager.Instance;
        _upgrade = upgradable;
    }

    public void UpgradeFistAttribute()
    {
        if (_firstAttributeLevel >= _firstAttributeMaxLevel) return;
        if (!HavePlayerMoney(CostFirstAttribute)) return;
        _firstAttributeLevel++;

        _upgrade.FirstUpgradeAttribute((int)_addingNumberToFirstAttribute);

        _addingNumberToFirstAttribute -= _UpgradeAddingNumberToFirstAttribute;
        CostFirstAttribute = OnUpCostAfterUpgrade(CostFirstAttribute);
    }
    
    public void UpgradeSecondAttribute()
    {
        if (_secondAttributeLevel >= _secondAttributeMaxLevel) return;
        if (!HavePlayerMoney(CostSecondAttribute)) return;
        _secondAttributeLevel++;

        _upgrade.SecondUpgradeAttribute(_addingNumberToSecondAttribute);

        _addingNumberToSecondAttribute -= _UpgradeAddingNumberToSecondAttribute;
        CostSecondAttribute = OnUpCostAfterUpgrade(CostSecondAttribute);
    }
    
    public void UpgradeThirdAttribute()
    {
        if (_thirdAttributeLevel >= _thirdAttributeMaxLevel) return;
        if (!HavePlayerMoney(CostThirdAttribute)) return;
        _thirdAttributeLevel++;

        _upgrade.ThirdUpgradeAttribute(_addingNumberToThirdAttribute);
        
        _addingNumberToThirdAttribute -= _UpgradeAddingNumberToThirdAttribute;
        CostThirdAttribute = OnUpCostAfterUpgrade(CostThirdAttribute);
    }

    private bool HavePlayerMoney(int cost)
    {
        if(cost < _player.MoneyInBag)
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
