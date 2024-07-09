using UnityEngine;

namespace ProjectTDS.Unit
{
    public class UnitConditionComponent : UnitComponent, ICanBeHit
    {
        [Header("Стандартные характеристики:"), SerializeField, Range(50f, 200f)]
        protected float _maxHealthPoints = 100f;
        [SerializeField, Range(0f, 200f)]
        protected float _maxArmorPoints = 25f;
        [SerializeField, Range(0f, 5f)]
        private float _moveSpeed = 3f;
      
        [Space,Header("Проверка характеристик в реальном времени:"),SerializeField]
        protected float _currentHealthPoints;
        [SerializeField]
        protected float _currentArmorPoints;

        public float MoveSpeed { get => _moveSpeed;}
        public float ArmorPoints { get => _currentArmorPoints; }
        public float HealthPoints { get => _currentHealthPoints; }

        public bool _isDead { get; private set; } = false;

        protected virtual void Start()
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

            if (_currentHealthPoints <= 0) OnDied();
        }

        protected virtual void OnDied()
        {
            if (_isDead) return;
            _isDead = true;
            SetAllAnimatorLayersToZero(Owner._animator);
            Owner._animator.SetTrigger("OnDeath");
            Owner._sound.UnitDeadSound();
        }

        private void SetAllAnimatorLayersToZero(Animator animator)
        {
            for (int i = 0; i < animator.layerCount; i++) animator.SetLayerWeight(i, 0);
        }
    }
}