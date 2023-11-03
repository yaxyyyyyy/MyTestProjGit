using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealthItem : BonusItem
{
    [SerializeField] private int _healthBonus;
    public override void GetBonus(GameObject targetBonus)
    {
        var health = targetBonus.GetComponent<Health>();
        if(health != null) { health.AddDamage(- _healthBonus); }
    }
}
