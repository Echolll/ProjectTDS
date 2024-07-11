using UnityEngine;

namespace ProjectTDS.Minigame
{
    public class LockPickComponent : MonoBehaviour
    {
        [SerializeField]
        private UnlockLockEntryPoint _unlockLock;

        public ILocked _locked;

        public void OnPickTheLock(ILocked locked)
        {
            _locked = locked;
            SwitchPickTheLock(true);
        }

        public void SwitchPickTheLock(bool Activate)
        {
            _unlockLock.gameObject.SetActive(Activate);
        }

    }
}
