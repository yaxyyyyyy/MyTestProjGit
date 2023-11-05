using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttak : MonoBehaviour, IAttaker
{
    [SerializeField] private Transform _weaponMuzzle;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private ForceMode _forceMode = ForceMode.Impulse;
    [SerializeField, Min(0f)] private float _force = 10f;
    
    public void PerfomAttak()
    {
        var projectile = Instantiate(_projectilePrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);
        projectile.Rigidbody.AddForce(_weaponMuzzle.forward * _force, _forceMode);
    }
}
