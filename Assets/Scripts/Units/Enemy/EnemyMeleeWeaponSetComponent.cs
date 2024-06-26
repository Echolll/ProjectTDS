using ProjectTDS.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit.Enemy
{
    public class EnemyMeleeWeaponSetComponent : BaseSelectWeaponComponent
    {
        public IWeapon _weapon => _currentWeapon;

        private MeleeWeaponComponent _currentMelee;

        protected override void Start()
        {
            _currentMelee = _currentWeapon as MeleeWeaponComponent;
            base.Start();
        }

        public void MeleeAttack()
        {
            if (_currentMelee.IsAttacking) return;
            _currentMelee.OnAction();          
            Owner._animator.SetTrigger("MeleeAction");
        }

        public void OnChangeAnimationWeight_UnityEvent(AnimationEvent data)
        {
            return;
        }
    }
}
