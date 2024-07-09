using UnityEngine;

namespace ProjectTDS.Minigame
{
    public class UnlockLockEntryPoint : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        [SerializeField]
        private Lock _lock;

        [SerializeField]
        private Pick _pick;

        private void OnEnable()
        {
            SwitchLock(true);

            _pick.Init(_camera, _lock);
            _lock.Init(_pick);
        }

        private void OnDisable()
        {
            SwitchLock(false);
        }

        private void SwitchLock(bool activate)
        {
            _camera.gameObject.SetActive(activate);
            _lock.gameObject.SetActive(activate);
            _pick.gameObject.SetActive(activate);
        }
    }
}