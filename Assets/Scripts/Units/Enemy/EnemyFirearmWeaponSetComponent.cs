using ProjectTDS.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyFirearmWeaponSetComponent : BaseSelectWeaponComponent
    {
        public IFirearm _weapon => (FirearmWeaponComponent)_currentWeapon;
    }
}
