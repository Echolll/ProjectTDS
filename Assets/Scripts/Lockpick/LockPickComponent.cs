using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPickComponent : MonoBehaviour
{
    [SerializeField]
    private UnlockLockEntryPoint _unlockLock;

    public static LockPickComponent Instance { get; private set; }

    public ILocked _locked;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

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
