using ProjectTDS.Managers;
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
                BaseWeaponComponent weaponComponent;

                if(GameDataManager.Instance.createdWeaponsOnScene.TryGetValue(config._weapon.WeaponName, out weaponComponent))
                {
                    if(weaponComponent.gameObject.activeSelf) weaponComponent.gameObject.SetActive(false);
                }
                else
                {
                    weaponComponent = Instantiate(config._weapon);
                    DontDestroyOnLoad(weaponComponent);
                    GameDataManager.Instance.createdWeaponsOnScene.Add(weaponComponent.WeaponName, weaponComponent);
                    weaponComponent.gameObject.SetActive(false);
                }

                WeaponBlock weapon = Instantiate(_weaponBlock);                
                weapon.Initialize(config._weaponIcon, weaponComponent);
                weapon.gameObject.transform.SetParent(_content);
            }
        }
    }
}
