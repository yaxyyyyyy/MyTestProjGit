using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAfterEnemyDead : SimpleSpawner
{
    public static SpawnerAfterEnemyDead Instance { get; private set; }

    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }
    public ItemInPool SpawnItem(Transform positionSpawn)
    {
        var item = _pool.GetRealItemInPool();
        item.GetGameObject().transform.position = positionSpawn.position + Vector3.up;
        item.ExitFromPool();
        return item;
    }
}
