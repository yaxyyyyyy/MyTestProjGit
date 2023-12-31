using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBonus : SimpleSpawner
{
    [SerializeField] private float _maxTimeCuldown = 10f;
    [SerializeField] private float _currentTime;
    [SerializeField] private bool _isOpen;

    [SerializeField] private ItemInPool Test;
    void Start()
    {
        _currentTime = _maxTimeCuldown;
        _isOpen = true;
    }

    void Update()
    {
        if(_isOpen)
        {
            _currentTime -= Time.deltaTime;

            if (_currentTime < 0)
            {
                _currentTime = _maxTimeCuldown;
                _isOpen = false;
                var itemInPool = this.SpawnItem();
                Test = itemInPool;
                itemInPool.Ev_EntryToPool.AddListener(SwapOpenSpawner);
            }
        }
    }

    private void SwapOpenSpawner()
    {
        //��������� �����-������ � ������� ������ � �����������
        _isOpen = true;

    }
}
