using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    [CreateAssetMenu(fileName = "NewWeaponConfiguration", menuName = "ScriptableObjects/Contexts/Weapon Configuration", order = 2)]
    public class WeaponConfiguration : ScriptableObject
    {
        public WeaponContext[] _weaponContext;
    }
}
