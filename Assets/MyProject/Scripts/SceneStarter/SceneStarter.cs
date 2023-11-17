using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStarter : MonoBehaviour
{

    [SerializeField] private HealthPlayer _healthPlayer;


    [SerializeField] private PlayerCamera _mouseSensetive;

    [SerializeField] private PlayerMovement _movePlayer;


    [SerializeField] private RayCastAttak _gunPlayer;
    [SerializeField] private ProjectileAttak _knifePlayer;
    [SerializeField] private ProjectileAttak _grenadePlayer;
    private ExplosiveProjectile _grenade;
    private void Awake()
    {
        _healthPlayer.SetHealth(10, 15);


        _mouseSensetive.SetSensetive(100f, 100f);

        _movePlayer.SetMovement(7f, 12, 0.25f, 0.4f);


        _gunPlayer.SetDamage(20);

        _knifePlayer.Pref.SetDamage(35);

        _grenade = (ExplosiveProjectile)_grenadePlayer.Pref;
        _grenade.OverlapSphere.SetRadius(5f);
        _grenade.SetDamage(25);
    }
}
