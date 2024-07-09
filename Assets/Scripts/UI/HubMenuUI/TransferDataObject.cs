using ProjectTDS.Weapons;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTDS.UI.HubMenu
{
    public class TransferDataObject : MonoBehaviour
    {
        [SerializeField]
        private Image _weaponIcon;

        public BaseWeaponComponent _weapon { get; private set; }

        public void Initialize(BaseWeaponComponent weapon, Sprite icon)
        {
            _weapon = weapon;
            _weaponIcon.sprite = icon;
        }
    }
}
