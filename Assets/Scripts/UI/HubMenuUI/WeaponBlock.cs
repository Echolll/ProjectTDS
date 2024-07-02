using ProjectTDS.Weapons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTDS.UI.HubMenu
{
    public class WeaponBlock : MonoBehaviour
    {
        [SerializeField]
        private Image _weaponIcon;
        [SerializeField]
        private TextMeshProUGUI _weaponNameText;
        [SerializeField]
        private TextMeshProUGUI _firstWeaponAttribute;
        [SerializeField]
        private TextMeshProUGUI _secondWeaponAttribute;
        [SerializeField]
        private TextMeshProUGUI _thirdWeaponAttribute;

        private BaseWeaponComponent _weapon;

        public void Initialize(Sprite icon, BaseWeaponComponent weapon)
        {
            _weaponIcon.sprite = icon;
            _weapon = weapon;
            _weaponNameText.text = weapon.WeaponName;
            _firstWeaponAttribute.text = $"Damage: {weapon.Damage}";
            if(weapon is FirearmWeaponComponent firearm)
            {
                _secondWeaponAttribute.text = "Fire rate: " + firearm.FireRate.ToString();
                _thirdWeaponAttribute.text = "Reload time: " + firearm.ReloadTime.ToString();
            }
            else if(weapon is MeleeWeaponComponent melee)
            {
                _secondWeaponAttribute.text = "Delay between attack: " + melee.DelayBetweenAttack.ToString();
                _thirdWeaponAttribute.text = "";
            }
        }
    }
}
