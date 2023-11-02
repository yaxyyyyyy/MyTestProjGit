using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitBox : MonoBehaviour
{
    [SerializeField] private int _damage = 6;
    [SerializeField] string _maskEnemy;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer(_maskEnemy);
    }
    private void OnTriggerEnter(Collider collider)
    {
        //var hp = collider.GetComponent<HealthEnemy>();
        var hp = collider.GetComponent<Health>();
        if (hp != null) { hp.AddDamage(_damage); }
    }
}
