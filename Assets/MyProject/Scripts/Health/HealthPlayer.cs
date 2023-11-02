using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : Health
{
    [SerializeField] protected GameObject UIRestartMenu;
    private void Start()
    {
        UIRestartMenu.SetActive(false);
        Ev_Dead.AddListener(GetWindowRestart);
    }

    private void GetWindowRestart()
    {
        UIRestartMenu.SetActive(true);
    }

    public void GetRestart()
    {
        _health = _maxHealth;
    }
}
