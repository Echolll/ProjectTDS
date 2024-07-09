using ProjectTDS.Enums;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class BaseWeaponComponent : MonoBehaviour, IWeapon , IUpgradable
    {
        [SerializeField]
        private string _weaponName;
        [SerializeField]
        private AudioClip _weaponSound;

        [SerializeField]
        private float _damage;
        [SerializeField]
        private AnimateKey _animKey;

        public AnimateKey AnimKey { get => _animKey; }

        public float Damage { get => _damage; set => _damage = value; }

        public string WeaponName { get => _weaponName; }

        protected AudioSource _audioSource;

        protected virtual void OnEnable()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _weaponSound;
        }

        public abstract void OnAction();

        public abstract void FirstUpgradeAttribute(int number);

        public abstract void SecondUpgradeAttribute(float number);

        public abstract void ThirdUpgradeAttribute(float number);
    }
}
