using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int _health = 15;
    [SerializeField] protected int _maxHealth = 30;
    public int CurrentHealth => _health;
    public int MaxHealth => _maxHealth;

    public UnityEvent Ev_Dead;
    public void SetHealth(int health, int maxHealth) { _health =  health; _maxHealth = maxHealth; }
    public virtual void AddDamage(int damage)
    {
        //CECK DEBUG LOG
        //Debug.Log("AddDamage [dmg=" + damage + "/cur=" + _health + "/max=" + _maxHealth + "] from " + gameObject.name);
        _health = Mathf.Min(_maxHealth, _health - damage);
        if (_health <= 0)
        {
            Ev_Dead?.Invoke();
            Ev_Dead.RemoveAllListeners();
            //_health = _maxHealth; // - גûחמגועסÿ סמבûעטול
        }
    }
}

public interface IHealth
{
    public void AddDamage(int damage);
}

