using ProjectTDS.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        public List<BaseWeaponComponent> FirearmList { get; private set; } = new List<BaseWeaponComponent>();
        [SerializeField]
        public MeleeWeaponComponent MeleeWeapon { get; private set; }

        [field : SerializeField]
        public int MoneyInBag { get; private set; }

        public static PlayerManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;        
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public event Action UpdateMoneyInfoEventHandler;

        public void AddWeaponToList(BaseWeaponComponent weapon)
        {
            if (weapon is MeleeWeaponComponent meleeWeapon) MeleeWeapon = meleeWeapon;
            else
            {
                if (!FirearmList.Contains(weapon)) FirearmList.Add(weapon);
                else return;
            }
        }

        public List<GameObject> GetGameobjects()
        {
            List<GameObject> list = new List<GameObject>();
            GameObject obj;

            foreach (var weapon in FirearmList)
            {
                obj = weapon.gameObject;
                if(obj is GameObject) list.Add(obj);
            }

            obj = MeleeWeapon.gameObject;
            if (obj is GameObject) list.Add(obj);

            return list;
        }

        public void AddMoneyToBug(int money)
        {
            MoneyInBag += money;
            UpdateMoneyInfoEventHandler?.Invoke();
        }

        public void UpgradeItem(int money)
        {
            MoneyInBag -= money;
            UpdateMoneyInfoEventHandler?.Invoke();
        }
    }
}
