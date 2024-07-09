using UnityEngine;

namespace ProjectTDS.UI.HubMenu
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private WeaponShopListBlock _weaponShop;
        [SerializeField]
        private PlayerBlock _playerBlock;

        public void SwitchShopPanel(bool Activate)
        {
            _weaponShop.gameObject.SetActive(Activate);
            _playerBlock.gameObject.SetActive(Activate);
        }

    }
}
