using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : ItemInPool
{
    [SerializeField] private Rigidbody _rBody;

    private void OnCollisionEnter(Collision collision)
    {
        this.EntryToPool();
        Debug.Log("bonus");
    }
}
