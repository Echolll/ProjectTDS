using ProjectTDS.Managers;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Unit
{ 
    public class Unit : MonoBehaviour
    {
        [Inject]
        protected internal LevelManager _level;

        protected internal Rigidbody _rigibody;
        protected internal Animator _animator;
        protected internal BaseUnitInputComponent _controls;
        protected internal UnitMoveComponent _move;
        protected internal UnitConditionComponent _condition;
        protected internal BaseSelectWeaponComponent _weapon;
        protected internal UnitSoundComponent _sound;

        protected virtual void Awake()
        {
            _condition = GetComponent<UnitConditionComponent>();
            _rigibody = GetComponent<Rigidbody>();
            _controls = GetComponent<BaseUnitInputComponent>();
            _move = GetComponent<UnitMoveComponent>();    
            _weapon = GetComponent<BaseSelectWeaponComponent>();
            _animator = GetComponent<Animator>();
            _sound = GetComponent<UnitSoundComponent>();
        }
    }
}
    