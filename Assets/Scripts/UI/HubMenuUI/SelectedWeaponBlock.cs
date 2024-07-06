using ProjectTDS.Weapons;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectTDS.UI.HubMenu
{
    public class SelectedWeaponBlock : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private Image _weaponIcon;
        [SerializeField]
        private TextMeshProUGUI _weaponName;

        [SerializeField]
        private bool _isMeleeWeapon;

        private BaseWeaponComponent _baseWeapon;
        private MeleeWeaponComponent _meleeWeapon;

        public event Action<BaseWeaponComponent> UpdatePlayerDataEventHandler;

        public void SetWeapon(BaseWeaponComponent weapon, Sprite image)
        {
            if (weapon is MeleeWeaponComponent melee && _isMeleeWeapon)
            {
                _baseWeapon = melee;
                _meleeWeapon = melee;
            }
            else if(!_isMeleeWeapon)
            {
                _baseWeapon = weapon;
            }

            if (_baseWeapon != null)
            {
                SetBlockData(image);
                UpdatePlayerDataEventHandler?.Invoke(_baseWeapon);
            }
        }

        private void SetBlockData(Sprite image)
        {
            _weaponName.text = _baseWeapon.WeaponName;
            _weaponIcon.sprite = image;
        }

        public void OnDrop(PointerEventData eventData)
        {
            
        }
    }
}
