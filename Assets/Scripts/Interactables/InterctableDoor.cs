using ProjectTDS.Minigame;
using ProjectTDS.Unit.Player;
using System.Collections;
using UnityEngine;
using Zenject;

namespace ProjectTDS.Interactables
{
    public class InterctableDoor : MonoBehaviour, IInteractable, ILocked
    {
        [Inject]
        private PlayerInputComponent _playerInput;

        [field: SerializeField]
        public bool IsUnlocked { get; private set; } = false;
        
        [Space, Header("Дверь + 2 состояния")]
        [SerializeField]
        private GameObject _door;
        [SerializeField]
        private Transform _openDoor;
        [SerializeField]
        private Transform _closeDoor;
        [SerializeField, Range(1, 3f)]
        private float _switchSpeed = 2f;

        [Space, Header("Дверь + 2 состояния")]
        [SerializeField]
        private Material _openPanel;
        [SerializeField]
        private Material _closePanel;

        private bool _doorSwitch = true;
        private MeshRenderer _panelMesh;

        private void Awake() => _panelMesh = GetComponent<MeshRenderer>();

        public void Interactable()
        {
            if (!IsUnlocked)
            {
                LockPickComponent.Instance.OnPickTheLock(this);
                _playerInput.SwitchPlayerInput(false);
            }
            else SwitchDoor();
        }

        public void OpenLock()
        {
            IsUnlocked = true;
            LockPickComponent.Instance.SwitchPickTheLock(false);
            _playerInput.SwitchPlayerInput(true);
            _panelMesh.material = _openPanel;
        }
         
        private void SwitchDoor()
        {
            _doorSwitch = !_doorSwitch;

            if (_doorSwitch)
            {
                StartCoroutine(SwitchDoorState(_openDoor));
                _panelMesh.material = _openPanel;
            }
            else if (!_doorSwitch)
            {
                StartCoroutine(SwitchDoorState(_closeDoor));
                _panelMesh.material = _closePanel;
            }
        }

        private IEnumerator SwitchDoorState(Transform _endPoint)
        {
            while(Vector3.Distance(_door.transform.position, _endPoint.transform.position) >= 0.5f) 
            {
                _door.transform.position = Vector3.Lerp(_door.transform.position, _endPoint.position, Time.deltaTime * _switchSpeed);
                yield return null;
            }

            _door.transform.position = _endPoint.position;
        }

    }
}
