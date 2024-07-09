using System.Collections;
using UnityEngine;

namespace ProjectTDS.Weapons
{
    public class MeleeWeaponComponent : BaseWeaponComponent
    {
        [SerializeField, Range (1f,5f)]
        private float _delayBetweenAttack = 2f;

        public bool IsAttacking { get; private set; }

        public float DelayBetweenAttack { get => _delayBetweenAttack; private set => _delayBetweenAttack = value; }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnAction()
        {
            if (IsAttacking) return;
            IsAttacking = true;
            _audioSource.Play();
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

        public override void FirstUpgradeAttribute(int number)
        {
            Damage += number;
        }

        public override void SecondUpgradeAttribute(float number)
        {
            _delayBetweenAttack -= number;
        }

        public override void ThirdUpgradeAttribute(float number)
        {
            return;
        }
    }
}
