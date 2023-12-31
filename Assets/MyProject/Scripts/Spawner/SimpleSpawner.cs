using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] protected Pool _pool;

    public ItemInPool SpawnItem()
    {
        var item = _pool.GetRealItemInPool();
        item.GetGameObject().transform.position = transform.position + Vector3.up;
        item.ExitFromPool();
        return item;
    }
}

public interface ISpawner
{
    public abstract ItemInPool SpawnItem();
}
