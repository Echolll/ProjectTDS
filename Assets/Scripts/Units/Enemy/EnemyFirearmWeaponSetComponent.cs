using ProjectTDS.Weapons;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyFirearmWeaponSetComponent : BaseSelectWeaponComponent
    {
        public IFirearm _weapon => (FirearmWeaponComponent)_currentWeapon;
    }
}
