using ProjectTDS.Weapons;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public class BaseSelectWeaponComponent : UnitComponent
    {
        [SerializeField]
        protected BaseWeaponComponent _currentWeapon;

        protected virtual void Start()
        {
            if( _currentWeapon != null) _currentWeapon.gameObject.SetActive(true);
        }      
    }
}
