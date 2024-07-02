using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerConditionComponent : UnitConditionComponent, IRepairHealth, IRepairArmor
    {
        public float GetMaxHealth { get => _maxHealthPoints; }
        public float GetMaxArmor { get => _maxArmorPoints; }

        public event Action PlayerDeathEventHandler;
        public event Action UpdateConditionDataEventHandler;

        private bool _isDead = false;

        protected override void Start()
        {
            _currentArmorPoints = _maxArmorPoints / 2;
            _currentHealthPoints = _maxHealthPoints / 2;
        }

        public void OnArmorRepair(float repairPoints)
        {
            _currentArmorPoints += repairPoints;
            Mathf.Clamp(_currentArmorPoints, 0, _maxArmorPoints);
            UpdateConditionDataEventHandler?.Invoke();
        }

        public void OnHealthRepair(float repairPoints)
        {
            _currentHealthPoints += repairPoints;
            Mathf.Clamp(_currentHealthPoints, 0, _maxHealthPoints);
            UpdateConditionDataEventHandler?.Invoke();
        }

        public override void OnHealthGetDamage(float damagePoints)
        {
            base.OnHealthGetDamage(damagePoints);
            UpdateConditionDataEventHandler?.Invoke();
        }

        protected override void OnDied()
        {
            if(_isDead) return;
            _isDead = true;
            Owner._controls.enabled = false;
            base.OnDied();
            PlayerDeathEventHandler?.Invoke();
        }
    }
}

