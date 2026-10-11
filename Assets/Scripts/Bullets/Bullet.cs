using BulletSO;
using Combat;
using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private float _speed;
        private float _damage;
        private float _lifeTime;
        
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
        }
        
        public void Initialize(ProjectileArgs args)
        {
            _sr.sprite = args.Sprite;
            _speed = args.Speed;
            _damage = args.Damage;
            _lifeTime = args.LifeTime;
        }

        public void Launch()
        {
            _rb.linearVelocity = Vector2.right * _speed;
            Destroy(gameObject, _lifeTime);
        }



        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable target))
            {
                target.TakeDamage(_damage);
            }
        }
        
        
        
        
    }
}