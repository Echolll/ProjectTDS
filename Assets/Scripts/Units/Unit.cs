using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTDS.Unit
{
    public class Unit : MonoBehaviour
    {
        protected internal Rigidbody _rigibody;
        protected internal BaseUnitInputComponent _controls;
        protected internal UnitMoveComponent _move;
        protected internal UnitConditionComponent _condition;
        protected internal BaseSelectWeaponComponent _weapon;

        protected void Awake()
        {
            _rigibody = GetComponent<Rigidbody>();
            _controls = GetComponent<BaseUnitInputComponent>();
            _move = GetComponent<UnitMoveComponent>();
            _condition = GetComponent<UnitConditionComponent>();   
            _weapon = GetComponent<BaseSelectWeaponComponent>();
        }
    }
}
    