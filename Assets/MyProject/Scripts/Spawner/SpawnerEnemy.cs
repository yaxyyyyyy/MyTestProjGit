using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : SimpleSpawner
{
    [SerializeField] private Transform _player;
    [SerializeField] private bool _isVisible;
    public bool IsVisible => _isVisible;

    void OnBecameVisible()
    {
        _isVisible = true;
    }
    void OnBecameInvisible()
    {
        _isVisible = false;
        //камера просмотра сцены (в редкатировании) также учитывается
        //Debug.Log("меня не видно");
    }
    public void SetPlayer(Transform player)
    {
        _player = player;
    }
    public new ItemInPool SpawnItem()
    {
        if (!_isVisible)
        {
            var item = base.SpawnItem();
            item.GetGameObject().GetComponent<EnemyMovementAgent>().CreateEnemyMovementAgent(_player);
            return item;
        }
        return null;
    }
}
