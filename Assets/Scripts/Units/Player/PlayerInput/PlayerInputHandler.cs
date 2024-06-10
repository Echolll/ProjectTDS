using UnityEngine;

namespace ProjectTDS.Unit.Player.Input
{
    public class PlayerInputHandler
    {
        private PlayerInputs _input = new PlayerInputs();

        public PlayerInputs Input => _input;

        public void EnableInput() => _input.Enable();

        public void DisableInput() => _input.Disable();

        public void DisposeInput() => _input.Dispose();

        public Vector2 GetMousePosition() => _input.Camera.Delta.ReadValue<Vector2>();

        public Vector2 GetMovementDirection() => _input.Player.Move.ReadValue<Vector2>();

    }
}
