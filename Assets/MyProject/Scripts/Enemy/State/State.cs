using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : IState
{
    public StateSwitcher Switcher        { get; private set; }
    //public bool CanSwitch                { get; private set; } = true;
    public UnityEvent<State> Ev_EndState { get; private set; } = new UnityEvent<State>();
    public void CreateState(StateSwitcher switcher)//, bool canSwitch = true)
    {
        Switcher = switcher;
        //CanSwitch = canSwitch;
    }
    public abstract void UpdateState();
    //{

    //    Debug.Log("tok");
    //}
    public void EnterState()
    {
        Ev_EndState.AddListener(Switcher.EndState);
    }
    public void ExitState()
    {
        Ev_EndState.RemoveAllListeners();
    }
    //public State SetCanState(bool canSwitch = true)
    //{
    //    CanSwitch = canSwitch;
    //    return this;
    //}


    //public UnityEvent<IState> Ev_EndState = new UnityEvent<IState>();
    //public void Enter()
    //{
    //}

    //public void Exit()
    //{
    //}

    //public void UpdateState()
    //{

    //}
    //public void EndState()
    //{
    //    Ev_EndState?.Invoke(this);
    //    Ev_EndState.RemoveAllListeners();
    //    //_sMachine.EndCurrentState(this);
    //}
}

public interface IState
{
    //public void Enter();
    //public void Exit();


    //public void EndState();
    //public void UpdateState();


    //public void CanSwitch();
}
