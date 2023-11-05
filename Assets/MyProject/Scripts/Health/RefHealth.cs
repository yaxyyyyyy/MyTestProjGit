using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefHealth : Health
{
    [SerializeField] Health mainHelth;
    public override void AddDamage(int damage)
    {
        //TODO убрать костыль для Projectile Attak
        mainHelth.AddDamage(damage);
    }
}
