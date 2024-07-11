using ProjectTDS.Managers;
using ProjectTDS.Weapons;
using System.Collections.Generic;
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
        private List<SelectedWeaponBlock> _weapons;

        [SerializeField]
        private TextMeshProUGUI _playerMoneyText;

        private void OnEnable()
        {
            foreach (var weapon in _weapons)
            {
                weapon.UpdatePlayerDataEventHandler += PlayerDataUpdating;
            }

            _player.UpdateMoneyInfoEventHandler += UpdataMoneyInformation;
        }

        private void OnDisable()
        {
            foreach (var weapon in _weapons)
            {
                weapon.UpdatePlayerDataEventHandler -= PlayerDataUpdating;
            }

            _player.UpdateMoneyInfoEventHandler -= UpdataMoneyInformation;
        }

        private void Start() => UpdataMoneyInformation();

        private void UpdataMoneyInformation()
        {
            _playerMoneyText.text = $"${_player.MoneyInBag}";
        }

        private void PlayerDataUpdating(BaseWeaponComponent weapon)
        {
            _player.AddWeaponToList(weapon);
        }
    }   
}
