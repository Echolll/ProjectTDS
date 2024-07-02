using ProjectTDS.Enums;
using ProjectTDS.Unit;
using ProjectTDS.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Player
{
    public class PlayerSelectWeaponComponent : BaseSelectWeaponComponent
    {
        [SerializeField]
        private MeleeWeaponComponent _currentMelee;

        [Space,SerializeField]
        private BaseWeaponComponent[] _weapons;

        private Dictionary<BaseWeaponComponent, int> _weaponKeyAnim;
  
        public IFirearm _firearm => (FirearmWeaponComponent)_currentWeapon;

        public IWeapon _meleeWeapon => _currentMelee;

        public event Action<FirearmWeaponComponent> OnChangeWeaponEventHandler;

        protected override void Start()
        {
            InitWeaponDictionary();         
            base.Start();
            OnSelectWeapon(0);
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
                OnChangeWeaponEventHandler?.Invoke(_currentWeapon as FirearmWeaponComponent);
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
            if (_currentMelee.IsAttacking) return;
            _currentMelee.gameObject.SetActive(true);
            _currentWeapon.gameObject.SetActive(false);

            _currentMelee.OnAction();
            
            Owner._animator.SetTrigger("MeleeAction");
            Owner._animator.SetLayerWeight(_weaponKeyAnim[_currentMelee], 0.5f);                   
        }
     
        public void OnChangeAnimationWeight_UnityEvent(AnimationEvent data)
        {
            Owner._animator.SetLayerWeight(_weaponKeyAnim[_currentMelee], data.floatParameter);     
            if(data.floatParameter == 0f)
            {
                _currentMelee.gameObject.SetActive(false);
                _currentWeapon.gameObject.SetActive(true);        
            }
        }
    }
}
