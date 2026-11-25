using System;
using Bullets;
using UnityEngine;

namespace BulletSO
{
    [CreateAssetMenu(fileName = "BulletDataSO", menuName = "ScriptableObjects/BulletDataSO")]
    public class BulletDataSO : ScriptableObject
    {
        [Header("Базовые параметры пули")]
        [field: SerializeField]
        public string BulletName { get; private set; } = "Change name!!!!";
    
        [field: SerializeField] public Sprite BulletSprite{ get; private set; }

        [field: SerializeField] public float Speed { get; private set; } = 15f;
        [field: SerializeField] public float LifeTime { get; private set; } = 10f;
        [field: SerializeField] public float Damage { get; private set; } = 20f;
    }

}
