using ProjectTDS.Weapons;
using UnityEngine;
using Zenject;

namespace ProjectTDS.UI.HubMenu
{
    public class WeaponShopListBlock : MonoBehaviour
    {
        [Inject]
        private WeaponConfiguration _config;

        [SerializeField]
        private WeaponBlock _weaponBlock;
        [SerializeField]
        private RectTransform _content;

        private void Awake()
        {
            foreach(var config in _config._weaponContext)   
            {
                WeaponBlock weapon = Instantiate(_weaponBlock);
                BaseWeaponComponent weaponComponent = Instantiate(config._weapon);                
                weapon.Initialize(config._weaponIcon, weaponComponent);
                weapon.gameObject.transform.SetParent(_content);
            }
        }
    }
}
