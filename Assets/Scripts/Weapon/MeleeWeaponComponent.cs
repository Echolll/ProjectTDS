using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public class MeleeWeaponComponent : BaseWeaponComponent
    {
        [SerializeField, Range (1f,5f)]
        private float _delayBetweenAttack = 2f;

        public bool IsAttacking { get; private set; }

        public override void OnAction()
        {
            if (IsAttacking) return;
            IsAttacking = true;
            StartCoroutine(OnAttackEnd());
        }

        private IEnumerator OnAttackEnd()
        {
            yield return new WaitForSeconds(_delayBetweenAttack);
            IsAttacking = false;
        }    

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out ICanBeHit health))
            {
                health.OnHealthGetDamage(Damage);
            }
        }       
    }
}
