using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : SimpleSpawner
{
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
}
