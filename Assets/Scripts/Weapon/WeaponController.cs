using System;
using Bullets;
using BulletSO;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour, IWeaponEquipper
    {
        public event Action<WeaponDataSO> OnWeaponChanged;
        
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        
        [SerializeField] private WeaponDataSO _currentWeapon;
        
        private float _nextFireTime;


        public bool TryShoot()
        {
            if (_currentWeapon == null)
            {
                return false;
            }

            if (Time.time < _nextFireTime)
            {
                return false;
            }
            
            _nextFireTime = Time.time + (1f / _currentWeapon.FireRate);
            ExecuteShot();
            return true;
        }

        private void ExecuteShot()
        {
            ProjectileArgs args = _currentWeapon.CreateProjectileArgs();
            
            float baseAngle = _firePoint.eulerAngles.z;
            // Цикл: для пистолета сработает 1 раз, для дробовика — например, 8 раз:
            for (int i = 0; i < _currentWeapon.BulletsPerShot; i++)
            {
                // Случайный разброс в диапазоне [-Spread / 2, +Spread / 2]:
                float randomSpread = UnityEngine.Random.Range(-_currentWeapon.SpreadAngle / 2f, _currentWeapon.SpreadAngle / 2f);
        
                // Поворачиваем пулю на базовый угол + отклонение разброса:
                Quaternion bulletRotation = Quaternion.Euler(0f, 0f, baseAngle + randomSpread);
                // Спавним дробинку с этим углом:
                Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, bulletRotation);
                bullet.Initialize(args);
                bullet.Launch();
            }
        }

        public void EquipWeapon(WeaponDataSO weapon)
        {
            _currentWeapon = weapon;
            if (_firePoint != null && _currentWeapon != null)
            {
                _firePoint.localPosition = _currentWeapon.FirePointOffset;
            }
            OnWeaponChanged?.Invoke(_currentWeapon);
        }
    }
}