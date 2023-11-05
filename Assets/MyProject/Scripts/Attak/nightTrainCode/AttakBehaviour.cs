using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public abstract class AttakBehaviour
{
    [SerializeField]private LayerMask _layerMaskTarget;
    public LayerMask LayerMaskTarget => _layerMaskTarget;


    [SerializeField] private Transform _startPoint;
    public Transform StartPoint => _startPoint;


    [SerializeField] private Weapon _weapon;
    public Weapon Weapon => _weapon;


    public float Damage => ProcessDamage(Weapon.Damage);
    protected AttakBehaviour(LayerMask layerMaskTarget, Transform startPoint)
    {
        _layerMaskTarget = layerMaskTarget;
        _startPoint = startPoint;
    }
    public void Setup(Weapon weapon)
    {
        if (weapon == null)
            throw new ArgumentNullException(nameof(weapon));
        _weapon = weapon;
        OnSetup();
    }

    protected virtual float ProcessDamage(float damage)
    {
        return damage;
    }
    protected virtual void OnSetup() { }
    public virtual void PrepareAttak() { }
    public abstract void PerfomAttak();
}
