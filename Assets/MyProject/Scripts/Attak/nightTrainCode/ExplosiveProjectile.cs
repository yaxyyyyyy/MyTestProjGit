using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveProjectile : Projectile
{
    [SerializeField] private Overlap _overlap;
    private List<Collider> _overlapResults = new List<Collider>(32);

    protected override void OnDisposeProjectile()
    {
        _overlapResults = _overlap.TryFind();
        if(_overlap.Size > 0 )
        {
            for(int i = 0; i < _overlap.Size; i++)
            {
                if (_overlapResults[i].TryGetComponent(out Health h) == false )
                {
                    continue;
                }
                else
                {
                    h.AddDamage(Damage);
                }
            }
        }
    }
    private void ApplyDamage(Health health)
    {
        health.AddDamage(Damage);
    }
}
