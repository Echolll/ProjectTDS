using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

namespace ProjectTDS.Unit.Player.Input
{
    public class PlayerActionHandler
    {
        public void MainAction(PlayerSelectWeaponComponent _weapon) => _weapon._firearm.OnAction();
        
        public void ReloadAction(PlayerSelectWeaponComponent _weapon) => _weapon._firearm.Relaod();

        public void ChangeWeaponInArms(PlayerSelectWeaponComponent _weapon, int index) => _weapon.OnSelectWeapon(index);      
        
        public void MeleeAction(PlayerSelectWeaponComponent _weapon) => _weapon._meleeWeapon.OnAction();
    }
}
