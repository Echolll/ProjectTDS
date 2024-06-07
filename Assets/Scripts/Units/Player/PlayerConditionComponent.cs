using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerConditionComponent : UnitConditionComponent, IRepairHealth, IRepairArmor
    {
        public void OnArmorRepair(float repairPoints)
        {
            _currentArmorPoints += repairPoints;
            Debug.Log($"Броня:{_currentArmorPoints}");
        }

        public void OnHealthRepair(float repairPoints)
        {
            _currentHealthPoints += repairPoints;
        }
    }
}

