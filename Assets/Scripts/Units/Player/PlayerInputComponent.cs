using ProjectTDS.Unit.Player.Input;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Unit.Player
{
    public class PlayerInputComponent : BaseUnitInputComponent
    {
        [Inject]
        private PlayerInputHandler _inputHandler;
        [Inject]
        private PlayerActionHandler _actionHandler;

        protected Vector2 _mousePosition;

        public ref Vector2 GetMousePosition => ref _mousePosition;

        private bool _isMainActionActive;
   
        private void OnEnable()
        {
            _inputHandler.EnableInput();
            
            _inputHandler.Input.Player.MainAction.performed += context => _isMainActionActive = true;
            _inputHandler.Input.Player.MainAction.canceled += context => _isMainActionActive = false;

            _inputHandler.Input.Player.MeleeAttack.performed += context => _actionHandler.MeleeAction(Owner._weapon as PlayerSelectWeaponComponent);

            _inputHandler.Input.Player.ReloadWeapon.performed += context => _actionHandler.ReloadAction(Owner._weapon as PlayerSelectWeaponComponent);

            _inputHandler.Input.Player.FirstWeapon.performed += context => _actionHandler.ChangeWeaponInArms(Owner._weapon as PlayerSelectWeaponComponent, 0);
            _inputHandler.Input.Player.SecondWeapon.performed += context => _actionHandler.ChangeWeaponInArms(Owner._weapon as PlayerSelectWeaponComponent, 1);
            _inputHandler.Input.Player.ThirdWeapon.performed += context => _actionHandler.ChangeWeaponInArms(Owner._weapon as PlayerSelectWeaponComponent, 2);
        }



        private void OnDisable()
        {
            _inputHandler.DisableInput();
        }

        private void Update()
        {                      
            _mousePosition = _inputHandler.GetMousePosition();
            Vector2 direction = _inputHandler.GetMovementDirection();
            _movement = new Vector3(direction.x, 0, direction.y);

            if (_isMainActionActive) _actionHandler.MainAction(Owner._weapon as PlayerSelectWeaponComponent);
        }
       
        private void OnDestroy() => _inputHandler.DisableInput();
    }
}
