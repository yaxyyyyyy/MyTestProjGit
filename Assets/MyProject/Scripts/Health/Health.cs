using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 15;
    [SerializeField] private int _maxHealth = 15;
    [SerializeField] private ItemInPool _itemInPool;

    public UnityEvent Ev_SpawnItem;
    public UnityEvent Ev_Dead;

    public void AddDamage(int damage)
    {

        Debug.Log("AddDamage [dmg=" + damage + "/cur=" + _health + "/max=" + _maxHealth + "] from " + gameObject.name);
        _health = Mathf.Min(_maxHealth, _health - damage);
        if (_health <= 0)
        {
            Ev_SpawnItem?.Invoke();
            Ev_Dead?.Invoke(); 
            Ev_Dead.RemoveAllListeners();
            //_health = _maxHealth; // - גûחמגועסÿ סמבûעטול
        }
    }
    public void ResetHealthValue() { _health = _maxHealth; }

    private void OnEnable()
    {
        _itemInPool.Ev_EntryToPool.AddListener(ResetHealthValue);
        Ev_Dead.AddListener(_itemInPool.EntryToPool);
        
    }
}
