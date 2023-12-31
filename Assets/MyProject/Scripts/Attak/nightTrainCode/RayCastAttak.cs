
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;



public class RayCastAttak : MonoBehaviour, IAttaker
{

    [Header("Damage")]
    [SerializeField, Min(0)] private int _damage = 9;

    [Header("Ray")]
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Min(0)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(0)] private int _shotCount = 1;

    [Header("Spread")]
    [SerializeField] private bool _useSpread;
    [SerializeField, Min(0)] private float _spreadFactor = 1f;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem _muzzleEffect;
    [SerializeField] private ParticleSystem _hitEffectPrefab;
    [SerializeField] private ParticleSystem _nonehitEffectPrefab;
    [SerializeField, Min(0)] private float _hitEffectDestroyDelay = 2f;

    [Header("Audio")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void SetDamage(int damage) { _damage = damage; }

    public void PerfomAttak()
    {
        for (int i = 0; i < _shotCount; i++)
        { PerfomRaycast(); }
        PerfomEffects();
    }

    private void PerfomRaycast()
    {
        var direction = _useSpread ? transform.forward + CalculateSpread() : transform.forward;
        var ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out Health damageable))
            {
                damageable.AddDamage(_damage);
                SpawnParticleEffectOnHit(hitInfo, _hitEffectPrefab);
            }
            else
            {
                SpawnParticleEffectOnHit(hitInfo, _nonehitEffectPrefab);
            }

        }
    }


    private void PerfomEffects()
    {
        if(_muzzleEffect != null)                      { _muzzleEffect.Play(); }
        if(_audioSource != null && _audioClip != null) { _audioSource.PlayOneShot(_audioClip); }
    }

    private void SpawnParticleEffectOnHit(RaycastHit hitInfo, ParticleSystem effect)
    {
        if(_hitEffectPrefab != null)
        {
            var hitEffectRotation = Quaternion.LookRotation(hitInfo.normal);
            var hitEffect = Instantiate(effect, hitInfo.point, hitEffectRotation);

            Destroy(hitEffect.gameObject, _hitEffectDestroyDelay);
        }
    }
    private Vector3 CalculateSpread()
    {
        return new Vector3()
        {
            x = Random.Range(-_spreadFactor, _spreadFactor),
            y = Random.Range(-_spreadFactor, _spreadFactor),
            z = Random.Range(-_spreadFactor, _spreadFactor)
        };
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerfomRaycast();
        }
    }

    private void OnDrawGizmos()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out var hitInfo, _distance, _layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            var hitPosition = ray.origin + ray.direction * _distance;

            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }
    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPositionRadius = 0.15f;

        Debug.DrawRay(ray.origin, ray.direction * distance, color);
        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPositionRadius);
    }
}
