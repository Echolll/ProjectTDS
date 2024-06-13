using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyMeleeWeaponSetComponent : BaseSelectWeaponComponent
    {
        public IWeapon _weapon => _currentWeapon;
    }
}
