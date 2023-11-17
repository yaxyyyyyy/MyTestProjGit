using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefHealth : Health
{
    //костыль перенаправляющий урон с (gameobject"EnemyAgent" + RefHealth) на (gameobject"Capsule" + mainHelth)
    [SerializeField] Health mainHelth;
    public override void AddDamage(int damage)
    {
        //TODO убрать костыль для Projectile Attak
        mainHelth.AddDamage(damage);
    }
}
