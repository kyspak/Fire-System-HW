using Bullets;
using BulletSO;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
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
            
            Bullet _bullet = Instantiate(_bulletPrefab,  _firePoint.position, _firePoint.rotation);
            
            _bullet.Initialize(args);
            _bullet.Launch();
        }
    }
}