using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AggresiveWeapon : Weapon
{
    [SerializeField] protected SO_AggresiveWeapon aggresiveWeaponData;
    private List<IDamageable> detectedEnemies = new();

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        foreach (IDamageable entity in detectedEnemies.ToList())
        {
            Debug.Log($"Someone should take {aggresiveWeaponData.damageAmmount}");
            var damageData = new DamageData(aggresiveWeaponData.damageAmmount, this.gameObject);
            entity.Damage(damageData);
            GenerateImpulse(0.1f);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        var entity = collision.GetComponent<IDamageable>();

        if (entity != null)
        {
            detectedEnemies.Add(entity);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        var entity = collision.GetComponent<IDamageable>();

        if (entity != null)
        {
            detectedEnemies.Remove(entity);
        }
    }
}