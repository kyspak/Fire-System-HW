using UnityEngine;

namespace Bullets
{
    public readonly struct ProjectileArgs
    {
        public Sprite Sprite { get; }
        public float Speed { get; }
        public float Damage { get; }
        public float LifeTime { get; }

        public ProjectileArgs(Sprite sprite, float speed, float damage, float lifeTime)
        {
            Sprite = sprite;
            Speed = speed;
            Damage = damage;
            LifeTime = lifeTime;
        }
    }
}
