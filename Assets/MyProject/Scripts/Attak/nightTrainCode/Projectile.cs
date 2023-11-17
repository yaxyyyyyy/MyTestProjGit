using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Common")]
    [SerializeField, Min(0)] private int _damage = 10;
    [SerializeField] private string _disposeType = "OnAnyCollision";   //OnTargetCollision //Manual

    [Header("RigidBody")]
    [SerializeField] private Rigidbody _rigidBody;

    [Header("EffectOfDestroy")]
    [SerializeField] private bool _isEffectOfDestroy = true;
    [SerializeField] private ParticleSystem _effectOfDestroyPrefab;
    [SerializeField, Min(0f)] private float _effectLifetime = 2f;

    private bool _isProjecttileDisposed;

    public int Damage => _damage;

    public string DisposeType => _disposeType;

    public Rigidbody Rigidbody => _rigidBody;

    public void SetDamage(int damage) { _damage = damage; }


    private void OnCollisionEnter(Collision collision)
    {
        if(_isProjecttileDisposed) return;

        if (collision.gameObject.TryGetComponent(out Health helth))
        {

            OnTargetCollision(collision, helth);

            if(_disposeType == "OnTargetCollision" )
            {
                DisposeProjectile();
            }
        }
        else
        {
            OnOtherCollision(collision);
        }

        OnAnyCollision(collision);

        if(_disposeType == "OnAnyCollision")
        {
            DisposeProjectile();
        }
    }

    private void DisposeProjectile()
    {
        OnDisposeProjectile();
        SpawnEffectOnDestroy();
        Destroy(gameObject);
        _isProjecttileDisposed = true;

    }
    protected virtual void OnTargetCollision(Collision c, Health h)    {    }
    protected virtual void OnOtherCollision(Collision c)    {    }
    protected virtual void OnAnyCollision(Collision c)    {    }
    protected virtual void OnDisposeProjectile()    {    }

    private void SpawnEffectOnDestroy()
    {
        if (_isEffectOfDestroy == false) return;
        var effect = Instantiate(_effectOfDestroyPrefab, transform.position, Quaternion.identity);
        Destroy(effect.gameObject, _effectLifetime);
    }

}
