using System;
using UnityEngine;

public class InterctableButton : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Material _activeMat;

    private MeshRenderer _meshMaterial;

    public bool Activate { get; private set; } = false;

    public event Action ButtonIsActiveEventHandler;

    private void Awake() => _meshMaterial = GetComponent<MeshRenderer>();

    public void Interactable()
    {
        if (!Activate)
        {
            Activate = true;
            _meshMaterial.material = _activeMat;
            ButtonIsActiveEventHandler?.Invoke();
        }
        else return;
    }
}
