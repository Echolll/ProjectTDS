using ProjectTDS.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        public List<BaseWeaponComponent> FirearmList { get; private set; }
        [SerializeField]
        public MeleeWeaponComponent MeleeWeapon { get; private set; }

        [field : SerializeField]
        public int MoneyInBag { get; private set; }

        public void AddWeaponToList(BaseWeaponComponent weapon)
        {
            if (weapon is MeleeWeaponComponent meleeWeapon) MeleeWeapon = meleeWeapon;
            else
            {
                if (!FirearmList.Contains(weapon)) FirearmList.Add(weapon);
                else return;
            }
        }

        public void AddMoneyToBug(int money)
        {
            MoneyInBag += money;
        }
    }
}
