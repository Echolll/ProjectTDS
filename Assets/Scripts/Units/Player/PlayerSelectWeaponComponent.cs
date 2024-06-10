using ProjectTDS.Weapons;
using UnityEngine;

public class PlayerSelectWeaponComponent : MonoBehaviour
{
    [SerializeField]
    private BaseWeaponComponent[] _weapons;
    
    [SerializeField]
    private BaseWeaponComponent _currentFirearm;
    [SerializeField]
    private BaseWeaponComponent _currentMelee;

    public IFirearm _firearm => (FirearmWeaponComponent)_currentFirearm;
    
    public IWeapon _meleeWeapon => _currentMelee;

    private void Start()
    {
        _currentFirearm = _weapons[0];
        _currentFirearm.gameObject.SetActive(true);
    }

    public void OnSelectWeapon(int weaponIndex)
    {
        if (weaponIndex < 0 || weaponIndex >= _weapons.Length) return;

        if (_weapons[weaponIndex] != null)
        {
            _currentFirearm.gameObject.SetActive(false);
            _currentFirearm = _weapons[weaponIndex];
            _currentFirearm.gameObject.SetActive(true);
            Debug.Log($"Weapon changed to {_currentFirearm.name}");
        }
        else return;
    }
}
