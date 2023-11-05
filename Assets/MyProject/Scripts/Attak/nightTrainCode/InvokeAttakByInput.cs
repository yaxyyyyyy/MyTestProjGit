using MyInputActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvokeAttakByInput : MonoBehaviour
{
    [SerializeField] private RayCastAttak _rayCastAttak;


    //[Inject]private MyInputActions.MyInputActions _actions;

    //private void Start()
    //{
    //    var inputPlayer = GetComponent<MyInputActions.MyInputActions>();
    //    _actions = inputPlayer;
    //}
    //private void OnEnable()
    //{
    //    _actions.Player.Fire1.performed += PerfomAttak;
    //}
    //private void OnDisable()
    //{
    //    _actions.Player.Fire1.performed -= PerfomAttak;
    //}

    private void OnFire1()
    {

        _rayCastAttak.PerfomAttak();
    }

    //private void PerfomAttak(InputAction.CallbackContext callbackContext)
    //{
    //    _rayCastAttak.PerfomAttak();
    //}
}
