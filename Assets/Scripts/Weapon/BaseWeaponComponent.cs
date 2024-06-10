using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public abstract class BaseWeaponComponent : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private float _damage;

        public float Damage { get => _damage; set => _damage = value; }

        public abstract void OnAction();
    }
}
