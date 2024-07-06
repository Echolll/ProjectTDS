using ProjectTDS.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public abstract class BaseWeaponComponent : MonoBehaviour, IWeapon , IUpgradable
    {
        [SerializeField]
        private string _weaponName;
        [SerializeField]
        private float _damage;
        [SerializeField]
        private AnimateKey _animKey;

        public AnimateKey AnimKey { get => _animKey; }

        public float Damage { get => _damage; set => _damage = value; }

        public string WeaponName { get => _weaponName; }
       
        public abstract void OnAction();

        public abstract void FirstUpgradeAttribute(int number);

        public abstract void SecondUpgradeAttribute(float number);

        public abstract void ThirdUpgradeAttribute(float number);
    }
}
