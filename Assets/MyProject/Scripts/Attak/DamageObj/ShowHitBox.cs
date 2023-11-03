using ShowMeleeWeapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHitBox : MonoBehaviour
{
    [SerializeField] private DamageHitBox _hitBox;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _cdBeforeShow;
    [SerializeField] private float _cdShow;
    [SerializeField] private float _cdAfterShow;
    //private Vector3 _localPositionBoxDefault;
    private bool _isShow = false;

    private StateMachineMeleeWeapon _meleeWeaponMachine;
    private void Start()
    {
        _meleeWeaponMachine = new StateMachineMeleeWeapon(_hitBox, _cdBeforeShow, _cdShow, _cdAfterShow);
    }
    private void Update()
    {
        _meleeWeaponMachine.UpdateMachine();
    }

}




