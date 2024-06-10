using UnityEngine;

namespace ProjectTDS.Unit.Player.Input
{
    public class PlayerActionHandler
    {
        public void MainAction(PlayerUnitComponent player) => player._weapon._firearm.OnAction();
        
        public void ReloadAction(PlayerUnitComponent player) => player._weapon._firearm.Relaod();

        public void ChangeWeaponInArms(PlayerUnitComponent player, int index) => player._weapon.OnSelectWeapon(index);      
        
        public void MeleeAction(PlayerUnitComponent player) => player._weapon._meleeWeapon.OnAction();
    }
}
