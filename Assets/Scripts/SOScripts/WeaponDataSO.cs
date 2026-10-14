using System.Collections.Generic;
using Bullets;
using BulletSO;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataSO", menuName = "ScriptableObjects/WeaponDataSO")]
public class WeaponDataSO : ScriptableObject
{
    [Header("Основные характеристики оружия")]
    [field: SerializeField] public Sprite Icon { get; set; }
    [field: SerializeField] public string Name { get; set; } = "Change this name!!!!!";
    [field: SerializeField] public string Description { get; set; } = "lorem ipsum";
    [field: SerializeField] public float FireRate { get; set; } = 1f;
    [field: SerializeField] public float DamageMultiplier { get; set; } = 1.0f;
    [field: SerializeField] public Vector2 FirePointOffset { get; set; } = new Vector2(1.45f, 0.01f);
    
    [Header("Параметры дроби/разброса")]
    [field: SerializeField] public int BulletsPerShot { get; set; } = 1;
    [field: SerializeField] public float SpreadAngle { get; set; } = 0f;
    
    
    [Header("Допустимый вид пуль")]
    [field: SerializeField] public BulletDataSO BulletData{ get; set; }

    public ProjectileArgs CreateProjectileArgs()
    {
        return new ProjectileArgs(
            BulletData.BulletSprite,
            BulletData.Speed, 
            BulletData.Damage * DamageMultiplier,
            BulletData.LifeTime);
    }
    
}
