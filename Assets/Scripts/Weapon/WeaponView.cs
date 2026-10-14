using UnityEngine;

namespace Weapon
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private WeaponController _weaponController;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            if (_weaponController != null)
                _weaponController.OnWeaponChanged += UpdateVisual;

        }

        private void OnDisable()
        {
            if (_weaponController != null)
                _weaponController.OnWeaponChanged -= UpdateVisual;
        }

        private void UpdateVisual(WeaponDataSO weapon)
        {
            if (weapon != null)
            {
                _spriteRenderer.sprite = weapon.Icon;
            }
        }
    }
}