using UnityEngine;
using TMPro;
using Zenject;
using ProjectTDS.Unit.Player;
using ProjectTDS.Weapons;

namespace ProjectTDS.UI
{
    public class WeaponBlock : MonoBehaviour
    {
        [Inject]
        private PlayerSelectWeaponComponent _selectedWeapon;

        [SerializeField]
        private TextMeshProUGUI _weaponNameText;
        [SerializeField]
        private TextMeshProUGUI _ammoStockText;
        [SerializeField]
        private TextMeshProUGUI _ammoLeftText;

        private FirearmWeaponComponent _weapon;

        private void OnEnable()
        {
            _selectedWeapon.OnChangeWeaponEventHandler += WeaponUpdateInfo;
        }

        private void OnDisable()
        {
            _selectedWeapon.OnChangeWeaponEventHandler -= WeaponUpdateInfo;
        }

        private void Update()
        {
            UpdateWeaponBlock();
        }

        private void UpdateWeaponBlock()
        {
            _weaponNameText.text = _weapon.WeaponName;
            _ammoLeftText.text = _weapon.CurrentAmmo.ToString();
            _ammoStockText.text = _weapon.AmmoInStock.ToString();
        }

        private void WeaponUpdateInfo(FirearmWeaponComponent firearmWeapon)
        {
            _weapon = firearmWeapon;
        }
    }
}
