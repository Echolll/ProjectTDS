using ProjectTDS.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferDataObject : MonoBehaviour
{
    [SerializeField]
    private Image _weaponIcon;

    public BaseWeaponComponent _weapon { get; private set; }

    public void Initialize(BaseWeaponComponent weapon, Sprite icon)
    {
        _weapon = weapon;
        _weaponIcon.sprite = icon;
    }
}
