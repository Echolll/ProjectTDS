using ProjectTDS.Weapons;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectTDS.UI.HubMenu
{
    public class WeaponBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [Header("Основная информация:")]
        [SerializeField]
        private Image _weaponIcon;
        [SerializeField]
        private TextMeshProUGUI _weaponNameText;

        [Space, Header("Оружейные атрибуты:")]
        [SerializeField]
        private TextMeshProUGUI _firstWeaponAttributeName;
        [SerializeField]
        private TextMeshProUGUI _secondWeaponAttributeName;
        [SerializeField]
        private TextMeshProUGUI _thirdWeaponAttributeName;

        [Space,Header("Оружейные атрибуты:")]
        [SerializeField]
        private TextMeshProUGUI _firstWeaponAttribute;
        [SerializeField]
        private TextMeshProUGUI _secondWeaponAttribute;
        [SerializeField]
        private TextMeshProUGUI _thirdWeaponAttribute;

        [Space, Header("Оружейные атрибуты:")]
        [SerializeField]
        private TextMeshProUGUI _firstUpgradeWeaponAttribute;
        [SerializeField]
        private TextMeshProUGUI _secondUpgradeAttribute;
        [SerializeField]
        private TextMeshProUGUI _thirdUpgradeAttribute;

        [Space, Header("Для педачи данных:")]
        [SerializeField]
        private GameObject _clonePrefab;
                    
        private GameObject _clone;
        private Canvas _canvas;
        private RectTransform _rectTransform;
        
        private BaseWeaponComponent _weapon;
        private UpgradeWeaponComponenet _upgradeWeapon;

        private void Start()
        {
            _canvas = GetComponentInParent<Canvas>();
        }

        public void Initialize(Sprite icon, BaseWeaponComponent weapon)
        {
            _weaponIcon.sprite = icon;
            
            _weapon = weapon;
            _upgradeWeapon = weapon.gameObject.GetComponent<UpgradeWeaponComponenet>();
            if(_upgradeWeapon != null) _upgradeWeapon.Init(weapon);
                       
            _weaponNameText.text = weapon.WeaponName;
            _firstWeaponAttributeName.text = $"Damage:";
            _firstWeaponAttribute.text = weapon.Damage.ToString();

            _firstUpgradeWeaponAttribute.text = $"${_upgradeWeapon.CostFirstAttribute}";
            _secondUpgradeAttribute.text = $"${_upgradeWeapon.CostSecondAttribute}";

            if (weapon is FirearmWeaponComponent firearm)
            {
                _secondWeaponAttributeName.text = "Fire rate: ";
                _secondWeaponAttribute.text = firearm.FireRate.ToString();
                
                _thirdWeaponAttributeName.text = "Reload time: ";
                _thirdWeaponAttribute.text = firearm.ReloadTime.ToString() + " sec";
                
                _thirdUpgradeAttribute.text = $"${_upgradeWeapon.CostThirdAttribute}";
            }
            else if(weapon is MeleeWeaponComponent melee)
            {
                _secondWeaponAttributeName.text = "Delay between attack: ";
                _secondWeaponAttribute.text = melee.DelayBetweenAttack.ToString() + " sec";

                _thirdWeaponAttributeName.gameObject.SetActive(false);
            }                    
        }

        #region EventTrigger

        public void OnBeginDrag(PointerEventData eventData)
        {
            _clone = Instantiate(_clonePrefab.gameObject, _canvas.transform);
                        
            _rectTransform = _clone.GetComponent<RectTransform>();
            _rectTransform.position = eventData.position;
          
            _clone.TryGetComponent(out TransferDataObject obj);
            obj.Initialize(_weapon, _weaponIcon.sprite);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(_clone != null)
            {
                _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(_clone != null )
            {
                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };

                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, raycastResults);

                foreach(RaycastResult result in raycastResults)
                {
                    if (result.gameObject.TryGetComponent(out SelectedWeaponBlock block))
                    {
                        block.SetWeapon(_weapon, _weaponIcon.sprite);
                    }
                }

                Destroy(_clone);
            }
        }

        #endregion

        #region Upgrade

        public void UpgradeFirstAttribute_UnityEvent()
        {
            _upgradeWeapon.UpgradeFistAttribute();
            _firstWeaponAttribute.text = _weapon.Damage.ToString();
            _firstUpgradeWeaponAttribute.text = $"${_upgradeWeapon.CostFirstAttribute}";
        }

        public void UpgradeSecondAttribute_UnityEvent()
        {
            _upgradeWeapon.UpgradeSecondAttribute();

            if (_weapon is FirearmWeaponComponent firearm) _secondWeaponAttribute.text = firearm.FireRate.ToString();
            else if (_weapon is MeleeWeaponComponent melee) _secondWeaponAttribute.text = melee.DelayBetweenAttack.ToString();

            _secondUpgradeAttribute.text = $"${_upgradeWeapon.CostSecondAttribute}";
        }

        public void UpgradeThridAttribute_UnityEvent()
        {
            _upgradeWeapon.UpgradeThirdAttribute();
            
            if(_weapon is FirearmWeaponComponent firearm)
            _thirdWeaponAttribute.text = $"{firearm.ReloadTime} sec";
            _thirdUpgradeAttribute.text = $"${_upgradeWeapon.CostThirdAttribute}";
        }

        #endregion
    }
}
