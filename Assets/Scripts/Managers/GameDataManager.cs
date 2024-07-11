using ProjectTDS.UI.HubMenu;
using ProjectTDS.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Managers
{
    public class GameDataManager : MonoBehaviour
    {
        public static GameDataManager Instance { get; private set; }

        public Dictionary<string, SelectedWeapon> selectedWeapon = new Dictionary<string, SelectedWeapon>();

        public Dictionary<string, BaseWeaponComponent> createdWeaponsOnScene = new Dictionary<string, BaseWeaponComponent>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(gameObject);
        }       
    }
   
    [Serializable]
    public class SelectedWeapon
    {
        public Sprite Icon;
        public BaseWeaponComponent Weapon;
        public string BlockName;
    }
}
