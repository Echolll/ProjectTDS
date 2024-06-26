using ProjectTDS.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public abstract class BaseWeaponComponent : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private float _damage;
        [SerializeField]
        private AnimateKey _animKey;

        public AnimateKey AnimKey { get => _animKey; }

        public float Damage { get => _damage; set => _damage = value; }

        public abstract void OnAction();      
    }
}
