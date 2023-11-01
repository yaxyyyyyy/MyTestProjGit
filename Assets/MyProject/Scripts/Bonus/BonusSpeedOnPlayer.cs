using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpeedOnPlayer : MonoBehaviour
{
    [SerializeField] private float _oldSpeed;
    [SerializeField] private float _newSpeed;
    [SerializeField] private float _time;
    [SerializeField] private IMove _moveComp;

    public void CreateBonusOnPlayer(IMove move, float newSpeed, float time)
    {
        _newSpeed = newSpeed;
        _time = time;
        _moveComp = move;
        _oldSpeed = _moveComp.GetMoveSpeed();
        _moveComp.SetMoveSpeed(_newSpeed);
        this.enabled = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        if(_time <= 0)
        {
            _moveComp.SetMoveSpeed(_oldSpeed);
            this.enabled = false;
        }
    }
}
