using Input;
using UnityEngine;
using Weapon;
using Zenject;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private WeaponController _weapon;
        
        private IInputService _inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnEnable()
        {
            if (_inputService != null)
            {
                _inputService.OnFire += HandleFire;
            }
        }

        private void OnDisable()
        {
            if (_inputService != null)
            {
                _inputService.OnFire -= HandleFire;
            }
        }

        private void HandleFire()
        {
            _weapon.TryShoot();
        }
    }
}