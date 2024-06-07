using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public class UnitConditionComponent : MonoBehaviour , ICanBeHit
    {
        [SerializeField, Range(0f, 100f)]
        private float _maxHealthPoints = 100f;
        [SerializeField, Range(0f, 200f)]
        private float _maxArmorPoints = 25f;
        [SerializeField, Range(0f, 5f)]
        private float _moveSpeed = 3f;

        [Space,SerializeField]
        protected float _currentHealthPoints;
        [SerializeField]
        protected float _currentArmorPoints;

        public float MoveSpeed => _moveSpeed;
       
        private void Start()
        {
            _currentHealthPoints = _maxHealthPoints;
            _currentArmorPoints = _maxArmorPoints;         
        }

        public void OnHealthGetDamage(float damagePoints)
        {
            if (_currentHealthPoints > 0)
            {
                _currentHealthPoints -= damagePoints;
                Debug.Log($"Я ранен! Здоровье: {_currentHealthPoints}");
            }
            else if (_currentHealthPoints < 0)
            {
                Debug.Log("Я уничтожен");
            }
        }
    }
}
