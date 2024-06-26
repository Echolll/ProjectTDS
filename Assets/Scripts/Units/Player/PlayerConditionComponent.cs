using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerConditionComponent : UnitConditionComponent, IRepairHealth, IRepairArmor
    {
        public event Action PlayerDeathEventHandler;
        public event Action UpdateConditionDataEventHandler;

        private bool _isDead = false;

        public void OnArmorRepair(float repairPoints)
        {
            _currentArmorPoints += repairPoints;
            UpdateConditionDataEventHandler?.Invoke();
        }

        public void OnHealthRepair(float repairPoints)
        {
            _currentHealthPoints += repairPoints;
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

