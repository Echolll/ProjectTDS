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
        private TrailRenderer _trailRenderer;
        [SerializeField]
        private float trailDuration = 0.05f;

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
            if (_isRealoding || Time.time < _nextTimeToFire) return;
            if (_currentAmmo <= 0) Relaod();

            _nextTimeToFire = Time.time + _fireRate;

            if (_muzzleFlash != null) _muzzleFlash.Play();

            _currentAmmo--;

            RaycastHit hit;
            Vector3 hitPoint = _muzzlePosition.position + _muzzlePosition.forward * _fireRange;

            Debug.DrawRay(_muzzlePosition.position, _muzzlePosition.forward, Color.green, 5f);

            if (Physics.Raycast(_muzzlePosition.position, _muzzlePosition.forward, out hit, _fireRange))
            {
                hitPoint = hit.point;

                if (hit.transform.TryGetComponent(out ICanBeHit health))
                {
                    health.OnHealthGetDamage(Damage);
                }
            }

            StartCoroutine(SpawnBulletTrail(_muzzlePosition.position, hitPoint));
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

        private IEnumerator SpawnBulletTrail(Vector3 startPos, Vector3 endPos)
        {
            TrailRenderer trail = Instantiate(_trailRenderer, startPos, Quaternion.identity);
            
            float elapsedTime = 0f;

            while (elapsedTime < trailDuration)
            {
                trail.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / trailDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            trail.transform.position = endPos;
            Destroy(trail.gameObject, trail.time);
        }
    }
}
