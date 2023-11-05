using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScanProjectile : Projectile
{
    protected override void OnTargetCollision(Collision c, Health h)
    {
        h.AddDamage(Damage);
    }
}
