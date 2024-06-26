using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public class UnitConditionComponent : UnitComponent, ICanBeHit
    {
        [Header("Характеристики:"), SerializeField, Range(0f, 100f)]
        private float _maxHealthPoints = 100f;
        [SerializeField, Range(0f, 200f)]
        private float _maxArmorPoints = 25f;
        [SerializeField, Range(0f, 5f)]
        private float _moveSpeed = 3f;

        [Header("Debug:"), Space,SerializeField]
        protected float _currentHealthPoints;
        [SerializeField]
        protected float _currentArmorPoints;

        public float MoveSpeed { get => _moveSpeed;}
        public float ArmorPoints { get => _currentArmorPoints; }
        public float HealthPoints { get => _currentHealthPoints; }

        private void Start()
        {
            _currentHealthPoints = _maxHealthPoints;
            _currentArmorPoints = _maxArmorPoints;         
        }

        public virtual void OnHealthGetDamage(float damagePoints)
        {
            if(_currentArmorPoints > 0)
            {
                if(_currentArmorPoints >= damagePoints)
                {
                    _currentArmorPoints -= damagePoints;
                    return;
                }
                else
                {
                    float damageToHealth = damagePoints - _currentArmorPoints;
                    _currentArmorPoints = 0;
                    _currentHealthPoints -= damageToHealth;
                }
            }
            else
            {
                _currentHealthPoints -= damagePoints;
            }

            if (_currentHealthPoints <= 0) OnDied();  //StartCoroutine(OnDied_Coroutine());
        }

        protected virtual void OnDied()
        {
            var animator = Owner._animator;
            SetAllAnimatorLayersToZero(animator);
            animator.SetTrigger("OnDeath");
            Owner._rigibody.freezeRotation = false;            
        }

        private void SetAllAnimatorLayersToZero(Animator animator)
        {
            for (int i = 0; i < animator.layerCount; i++) animator.SetLayerWeight(i, 0);
        }
    }
}