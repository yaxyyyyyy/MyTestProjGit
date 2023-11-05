using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusSpeedOnPlayer : MonoBehaviour
{
    [SerializeField] private float _oldSpeed;
    [SerializeField] private float _newSpeed;
    [SerializeField] private float _time;
    [SerializeField] private IMove _moveComp;
    public UnityEvent<float> Ev_AddBonusTime = new UnityEvent<float>(); 

    public void CreateBonusOnPlayer(IMove move, float newSpeed, float time)
    {
        _newSpeed = newSpeed;
        _time = time;
        _moveComp = move;
        _oldSpeed = _moveComp.GetMoveSpeed();
        _moveComp.SetMoveSpeed(_newSpeed);
        this.enabled = true;
        Ev_AddBonusTime?.Invoke(time);
    }
    

    void Update()
    {
        _time -= Time.deltaTime;
        if(_time <= 0)
        {
            _moveComp.SetMoveSpeed(_oldSpeed);
            this.enabled = false;
            Ev_AddBonusTime?.Invoke(0);
        }
    }
}
