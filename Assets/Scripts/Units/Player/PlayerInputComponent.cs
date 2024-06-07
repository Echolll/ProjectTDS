using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Unit.Player
{
    public class PlayerInputComponent : BaseUnitInputComponent
    {      
        [Inject]
        private PlayerInputs _input;
        
        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();

        private void Update()
        {
            Vector2 mousePosition = _input.Camera.Delta.ReadValue<Vector2>();
            Vector2 direction = _input.Player.Move.ReadValue<Vector2>();

            _mousePosition = new Vector2(mousePosition.x, mousePosition.y);
            _movement = new Vector3(direction.x, 0, direction.y);
        }

        private void OnDestroy() => _input.Dispose();
    }
}
