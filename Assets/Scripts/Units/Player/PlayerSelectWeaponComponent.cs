using ProjectTDS.Enums;
using ProjectTDS.Unit;
using ProjectTDS.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerSelectWeaponComponent : BaseSelectWeaponComponent
    {
        [SerializeField]
        private BaseWeaponComponent _currentMelee;

        [Space,SerializeField]
        private BaseWeaponComponent[] _weapons;

        private Dictionary<BaseWeaponComponent, int> _weaponKeyAnim;
  
        public IFirearm _firearm => (FirearmWeaponComponent)_currentWeapon;

        public IWeapon _meleeWeapon => _currentMelee;

        protected override void Start()
        {
            InitWeaponDictionary();
            OnSelectWeapon(0);
            base.Start();
        }

        private void InitWeaponDictionary()
        {
            _weaponKeyAnim = new Dictionary<BaseWeaponComponent, int>();

            foreach (var weapon in _weapons) _weaponKeyAnim.Add(weapon, GetWeaponLayerIndex(weapon.AnimKey));
            _weaponKeyAnim.Add(_currentMelee, GetWeaponLayerIndex(_currentMelee.AnimKey));
        }

        private int GetWeaponLayerIndex(AnimateKey key)
        {
            var animator = Owner._animator;
            int index = animator.GetLayerIndex(key.ToString());
            return index;
        }

        public void OnSelectWeapon(int weaponIndex)
        {
            if (weaponIndex < 0 || weaponIndex >= _weapons.Length) return;
            if(_currentWeapon == null) _currentWeapon = _weapons[weaponIndex];

            if (_weapons[weaponIndex] != null)
            {
                _currentWeapon.gameObject.SetActive(false);
                _currentWeapon = _weapons[weaponIndex];
                ChangeAnimationSet(_weaponKeyAnim[_currentWeapon]);
                _currentWeapon.gameObject.SetActive(true);               
            }
            else return;
        }

        public void ChangeAnimationSet(int indexLayer)
        {
            var anim = Owner._animator;
            for(int i = 0; i < anim.layerCount; i++) anim.SetLayerWeight(i, 0f);
            anim.SetLayerWeight(indexLayer, 1f);
        }

        public void MeleeAction()
        {            
            var anim = Owner._animator;
            StartCoroutine(MeleeActionDo(_weaponKeyAnim[_currentMelee], anim));               
        }

        private IEnumerator MeleeActionDo(int layerKey, Animator anim)
        {
            _currentWeapon.gameObject.SetActive(false);
            _currentMelee.gameObject.SetActive(true);

            anim.SetLayerWeight(layerKey, 0.5f);
            anim.SetTrigger("MeleeAction");
            yield return new WaitForSeconds(2f);

            anim.SetLayerWeight(layerKey, 0f);
            _currentWeapon.gameObject.SetActive(true);
            _currentMelee.gameObject.SetActive(false);
        }
    }
}
