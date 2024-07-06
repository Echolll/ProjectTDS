using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace ProjectTDS.Weapons
{
    public class FirearmWeaponComponent : BaseWeaponComponent, IFirearm
    {
        
        [SerializeField]
        private float _fireRange = 100f;
        [SerializeField]
        private float _fireRate = 0.25f;       
        [SerializeField]
        private float _reloadTime = 1.5f;

        [Header("Настройки:")]
        [Space, SerializeField]
        private Transform _muzzlePosition;
        [SerializeField]
        private ParticleSystem _muzzleFlash;        
        [SerializeField]
        private BulletComponent _bulletPrefab;

        [Header("Кол-во патрон в магазине:")]
        [Space, SerializeField,Range(30,600)]
        private int _ammoInStock;
        [SerializeField]
        private bool _infinityAmmo;
        [SerializeField,Range(5,100)]
        private int _maxAmmoInMag = 30;
        [SerializeField]
        private int _currentAmmoInMag;

        private bool _isRealoding = false;
        private float _nextTimeToFire = 0f;

        public float FireRate { get => _fireRate; private set => _fireRate = value; }
        public float ReloadTime { get => _reloadTime; private set => _reloadTime = value; }
       
        public int CurrentAmmo { get => _currentAmmoInMag; }
        public int AmmoInStock { get => _ammoInStock; }

        private void Start() => _currentAmmoInMag = _maxAmmoInMag;

        private void OnEnable()
        {
            _isRealoding = false;
        }

        public override void OnAction()
        {         
            if (_isRealoding || Time.time < _nextTimeToFire || !gameObject.activeSelf) return;
            if (_currentAmmoInMag <= 0) Relaod();

            _nextTimeToFire = Time.time + _fireRate;

            if (_muzzleFlash != null) _muzzleFlash.Play();

            _currentAmmoInMag--;

            BulletComponent bullet = Instantiate(_bulletPrefab, _muzzlePosition.position, _muzzlePosition.rotation);
            bullet.Initialize(Damage);
            bullet.AddForceToBullet(_fireRange / 1.5f);
        }

        public void Relaod()
        {
            if (_isRealoding || (_ammoInStock <= 0 && !_infinityAmmo)) return;

            StartCoroutine(ReloadCoroutine());
        }

        private IEnumerator ReloadCoroutine()
        {
            _isRealoding = true;

            yield return new WaitForSeconds(_reloadTime);

            if (_infinityAmmo)
            {
                _currentAmmoInMag = _maxAmmoInMag;             
            }
            else
            {
                int ammoNeeded = _maxAmmoInMag - _currentAmmoInMag;
                int ammoToReaload = Mathf.Min(ammoNeeded, _ammoInStock);

                _currentAmmoInMag += ammoToReaload;
                _ammoInStock -= ammoToReaload;
            }
         
            _isRealoding = false;
        }        

        public override void FirstUpgradeAttribute(int number)
        {
            Damage += number;
        }

        public override void SecondUpgradeAttribute(float number)
        {
            _fireRate -= number;
        }

        public override void ThirdUpgradeAttribute(float number)
        {
            ReloadTime -= number;
        }
    }
}
