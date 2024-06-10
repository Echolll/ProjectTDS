using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public class MeleeWeaponComponent : BaseWeaponComponent
    {
        private Collider _attackCollider;

        private bool _isAttacking = false;

        private void Start()
        {
            _attackCollider = GetComponent<Collider>();
            _attackCollider.enabled = false;
        }

        public override void OnAction()
        {
            if (_isAttacking) return;
            StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            _isAttacking = true;
            _attackCollider.enabled = true;
            
            yield return new WaitForSeconds(0.1f);
          
            _attackCollider.enabled = false;
            _isAttacking = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(_isAttacking && other.TryGetComponent(out ICanBeHit health))
            {
                health.OnHealthGetDamage(Damage);
            }
        }
    }
}
