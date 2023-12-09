using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellJump : MonoBehaviour
{
    public PlayerEnergy _plEnergy;
    public int _energyCost;
    public float _forceImpulse;
    public Rigidbody _rBody;
    public Transform _headCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        { 
            if (_plEnergy.GetEnergy(_energyCost))
                { _rBody.AddForce(_headCamera.forward * _forceImpulse, ForceMode.Impulse); }
        }
    }
}
