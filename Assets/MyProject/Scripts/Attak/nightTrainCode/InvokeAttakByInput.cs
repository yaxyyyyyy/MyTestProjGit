using MyInputActions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InvokeAttakByInput : MonoBehaviour
{
    [SerializeField] private RayCastAttak _rayCastAttak;
    [SerializeField] private ProjectileAttak _projectileAttak;
    [SerializeField] private ProjectileAttak _projectileAttakExplosive;
    [SerializeField] private GameObject _weaponGun;

    [SerializeField] private UIWeaponPlayer _weaponPlayer;

    private IAttaker _currentWeapon;


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
    private void Start()
    {
        _currentWeapon = _rayCastAttak;
    }
    private void Update()
    {
        
    }
    private void OnFire1()
    {
        _currentWeapon.PerfomAttak();
        //_rayCastAttak.PerfomAttak();
    }
    private void OnSelectWeapon1()
    {
        _currentWeapon = _rayCastAttak;
        _weaponGun.SetActive(true);
        _weaponPlayer.SetImage(0);
    }
    private void OnSelectWeapon2()
    {
        _currentWeapon = _projectileAttak;
        _weaponGun.SetActive(false);
        _weaponPlayer.SetImage(1);
    }

    private void OnSelectWeapon3()
    {
        _currentWeapon = _projectileAttakExplosive;
        _weaponGun.SetActive(false);
        _weaponPlayer.SetImage(2);
    }
}

public interface IAttaker
{
    public void PerfomAttak();
}

