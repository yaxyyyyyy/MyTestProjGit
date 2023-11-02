using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : IState
{
    public StateSwitcher Switcher        { get; private set; }
    public UnityEvent<State> Ev_EndState { get; private set; } = new UnityEvent<State>();
    public void CreateState(StateSwitcher switcher)
    {
        Switcher = switcher;
    }
    public abstract void UpdateState();
    
    public void EnterState()
    {
        Ev_EndState.AddListener(Switcher.EndState);
    }
    public void ExitState()
    {
        Ev_EndState.RemoveAllListeners();
    }
}

public interface IState
{
   
}
