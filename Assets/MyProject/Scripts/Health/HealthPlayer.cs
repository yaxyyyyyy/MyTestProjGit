using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthPlayer : Health
{
    public UnityEvent<int> Ev_changeHP = new UnityEvent<int>();
    public override void AddDamage(int damage)
    {
        //CECK DEBUG LOG
        //Debug.Log("AddDamage [dmg=" + damage + "/cur=" + _health + "/max=" + _maxHealth + "] from " + gameObject.name);
        _health = Mathf.Min(_maxHealth, _health - damage);

        Ev_changeHP?.Invoke(_health);
        if (_health <= 0)
        {
            Ev_Dead?.Invoke();
            Ev_Dead.RemoveAllListeners();
            //_health = _maxHealth; // - גûחמגועסÿ סמבûעטול
        }
    }
}
