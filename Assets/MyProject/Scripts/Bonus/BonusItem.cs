using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusItem : ItemInPool
{
    [SerializeField] private Rigidbody _rBody;

    private void OnCollisionEnter(Collision collision)
    {
        this.EntryToPool();
        GetBonus(collision.gameObject);
    }

    public abstract void GetBonus(GameObject targetBonus);
    //{
    //    Debug.Log("bonus");
    //}
}
