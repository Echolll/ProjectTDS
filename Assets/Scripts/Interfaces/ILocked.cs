using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocked
{
    public bool IsUnlocked { get; }

    public void OpenLock();
}
