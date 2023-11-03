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
        Cursor.lockState = CursorLockMode.None;
    }

    public void GetRestart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _health = _maxHealth;
    }
}
