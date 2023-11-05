using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : Health
{
    [SerializeField] private ItemInPool _itemInPool;
    public UnityEvent<int> Ev_changeHP;

    private void Start()
    {
        
    }

    public override void AddDamage(int damage)
    {
        //Ev_SpawnItem?.Invoke();
        Ev_changeHP?.Invoke(CurrentHealth - damage);
        base.AddDamage(damage);
    }

    public void ResetHealthValue() { _health = _maxHealth; Ev_changeHP?.Invoke(CurrentHealth); }

    private void OnEnable()
    {
        _itemInPool.Ev_EntryToPool.AddListener(ResetHealthValue);
        Ev_Dead.AddListener(_itemInPool.EntryToPool);

    }
}
