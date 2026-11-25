using UnityEngine;
using UnityEngine.UI;
using Weapon;
using Zenject;

namespace UI
{
    public class WeaponSelectButton : MonoBehaviour
    {
        [SerializeField] private WeaponDataSO _weaponData;
        
        private Button _button;
        private IWeaponEquipper _weaponEquipper;

        [Inject]
        public void Construct(IWeaponEquipper weaponEquipper)
        {
            _weaponEquipper = weaponEquipper;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            _weaponEquipper?.EquipWeapon(_weaponData);
        }
    }
}