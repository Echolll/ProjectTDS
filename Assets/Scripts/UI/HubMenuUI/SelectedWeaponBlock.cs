using ProjectTDS.Managers;
using ProjectTDS.Weapons;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTDS.UI.HubMenu
{
    public class SelectedWeaponBlock : MonoBehaviour
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

        private void OnEnable() => LoadSelectedWeapon();

        public void SetWeapon(BaseWeaponComponent weapon, Sprite image)
        {
            if (weapon is MeleeWeaponComponent melee && _isMeleeWeapon)
            {
                _baseWeapon = melee;
                _meleeWeapon = melee;
            }
            else if (!_isMeleeWeapon)
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
            SaveSelectedWeapon();
        }

        public void LoadSelectedWeapon()
        {
            if (GameDataManager.Instance.selectedWeapon.TryGetValue(gameObject.name, out SelectedWeapon savedData))
            {
                SetWeapon(savedData.Weapon, savedData.Icon);
            }
        }

        private void SaveSelectedWeapon()
        {
            SelectedWeapon selectedWeapon = new SelectedWeapon()
            {
                Icon = _weaponIcon.sprite,
                Weapon = _baseWeapon,
                BlockName = gameObject.name
            };

            if (GameDataManager.Instance.selectedWeapon.ContainsKey(gameObject.name))           
                GameDataManager.Instance.selectedWeapon[gameObject.name] = selectedWeapon;           
            else
                GameDataManager.Instance.selectedWeapon.Add(gameObject.name, selectedWeapon);
        }
    }
}
