using ProjectTDS.Unit;
using ProjectTDS.Weapons;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerSelectWeaponComponent : BaseSelectWeaponComponent
    {
        [SerializeField]
        private BaseWeaponComponent _currentMelee;

        [Space,SerializeField]
        private BaseWeaponComponent[] _weapons;
      
        public IFirearm _firearm => (FirearmWeaponComponent)_currentWeapon;

        public IWeapon _meleeWeapon => _currentMelee;

        protected override void Start()
        {
            _currentWeapon = _weapons[0];
            base.Start();
        }

        public void OnSelectWeapon(int weaponIndex)
        {
            if (weaponIndex < 0 || weaponIndex >= _weapons.Length) return;

            if (_weapons[weaponIndex] != null)
            {
                _currentWeapon.gameObject.SetActive(false);
                _currentWeapon = _weapons[weaponIndex];
                _currentWeapon.gameObject.SetActive(true);
            }
            else return;
        }
    }
}
