using ProjectTDS.Managers;
using ProjectTDS.Weapons;
using TMPro;
using UnityEngine;
using Zenject;

namespace ProjectTDS.UI.HubMenu
{
    public class PlayerBlock : MonoBehaviour
    {
        [Inject]
        private PlayerManager _player;

        [SerializeField]
        private SelectedWeaponBlock _primaryWeapon;
        [SerializeField]
        private SelectedWeaponBlock _secondaryWeapon;
        [SerializeField]
        private SelectedWeaponBlock _meleeWeapon;

        [SerializeField]
        private TextMeshProUGUI _playerMoneyText;

        private void OnEnable()
        {
            _primaryWeapon.UpdatePlayerDataEventHandler += PlayerDataUpdating;
            _secondaryWeapon.UpdatePlayerDataEventHandler += PlayerDataUpdating;
            _meleeWeapon.UpdatePlayerDataEventHandler += PlayerDataUpdating;

            _playerMoneyText.text = _player.MoneyInBag.ToString();
        }

        private void OnDisable()
        {
            _primaryWeapon.UpdatePlayerDataEventHandler -= PlayerDataUpdating;
            _secondaryWeapon.UpdatePlayerDataEventHandler -= PlayerDataUpdating;
            _meleeWeapon.UpdatePlayerDataEventHandler -= PlayerDataUpdating;
        }

        private void PlayerDataUpdating(BaseWeaponComponent weapon)
        {
            _player.AddWeaponToList(weapon);
        }
    }   
}