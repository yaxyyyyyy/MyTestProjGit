using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellJump2 : MonoBehaviour
{
    [SerializeField] private Transform _direction;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _cur;
    [SerializeField] private float _max;
    [SerializeField] private float _force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            _rb.AddForce(_direction.forward * _force, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {

            _rb.AddForce(_direction.forward * _force * (-1), ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector3.zero;
        }
    }
}
