using ProjectTDS.Unit.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Weapons
{
    public class FirearmWeaponComponent : BaseWeaponComponent, IFirearm
    {
        [SerializeField]
        private float _fireRange = 100f;
        [SerializeField]
        private float _fireRate = 0.25f;
        [SerializeField]
        private int _maxAmmo = 30;
        [SerializeField]
        private float reloadTime = 1.5f;

        [Space, SerializeField]
        private Transform _muzzlePosition;
        [SerializeField]
        private ParticleSystem _muzzleFlash;

        [Space,SerializeField]
        private int _currentAmmo;
        private bool _isRealoding = false;
        private float _nextTimeToFire = 0f;

        private void Start() => _currentAmmo = _maxAmmo;

        private void OnEnable()
        {
            _isRealoding = false;
        }

        public override void OnAction()
        {
            if (_currentAmmo <= 0 || _isRealoding || Time.time < _nextTimeToFire) return;

            _nextTimeToFire = Time.time + _fireRate;

            if (_muzzleFlash != null) _muzzleFlash.Play();

            _currentAmmo--;

            RaycastHit hit;

            if (Physics.Raycast(_muzzlePosition.position, _muzzlePosition.forward, out hit, _fireRange))
            {
                if (hit.transform.TryGetComponent(out ICanBeHit health))
                {
                    health.OnHealthGetDamage(Damage);
                }
            }
        }

        public void Relaod()
        {
            if (_isRealoding) return;

            StartCoroutine(ReloadCoroutine());
        }

        private IEnumerator ReloadCoroutine()
        {
            _isRealoding = true;

            yield return new WaitForSeconds(reloadTime);

            _currentAmmo = _maxAmmo;
            _isRealoding = false;
        }
    }
}
