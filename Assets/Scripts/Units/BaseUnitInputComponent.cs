using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ProjectTDS.Unit
{
    public class BaseUnitInputComponent : UnitComponent
    {
        protected Vector3 _movement;

        public ref Vector3 MoveDirection => ref _movement;

        protected Vector2 _mousePosition; //Костыль

        public ref Vector2 GetMousePosition => ref _mousePosition; //Костыль
    }
}
