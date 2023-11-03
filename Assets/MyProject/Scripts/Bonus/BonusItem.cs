using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusItem : ItemInPool
{
    [SerializeField] private Rigidbody _rBody;

    private void OnTriggerEnter(Collider other)
    {
        this.EntryToPool();
        GetBonus(other.gameObject);
    }

    public abstract void GetBonus(GameObject targetBonus);
    //{
    //    Debug.Log("bonus");
    //}
}
