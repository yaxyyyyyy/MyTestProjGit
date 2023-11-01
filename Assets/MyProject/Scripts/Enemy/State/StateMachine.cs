using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public GameObject OwnerStateMachine  => this.gameObject;
    public StateSwitcher StateSwitcher { get; private set; }
    public State CurrentState { get; private set; }
    public static T CreateStateMachine<T, K>
        (GameObject owner,
        /*StateMachine machine,*/ 
        List<State> states, 
        int indexCurrentState) 
        where T : StateMachine 
        where K : StateSwitcher, new()
    {
        var newStateMachine = owner.AddComponent<T>();
        var switcher = new K();
        switcher.CreateStateSwitcher(newStateMachine, states, indexCurrentState);
        newStateMachine.StateSwitcher = switcher;//CurrentState задаю там
        
        return newStateMachine;
    }
    protected abstract void Update();
    //{
    //    Debug.Log("tuk");
    //    CurrentState.UpdateState();
    //}
    public void SetState(State newState) 
    {
        CurrentState = newState;
    }





    //private StateSwitcher _stateSwitcher;
    //private State _startState;
    //private State _currentState;
    //public State CurrentState => _currentState;
    //public StateSwitcher CurrentSwitcher => _stateSwitcher;

    //public void CreateStateMachine()
    //{
    //    _startState = new State();
    //    _currentState = _startState;
    //    var newSwitcher = new StateSwitcher();
    //    newSwitcher.CreateSwitcher(this);
    //    _stateSwitcher = newSwitcher;
    //}

    //public void SetState(State newState) { _currentState = newState; }
    //void Update()
    //{
    //    _currentState.UpdateState();
    //}




    //public void CreateStateMachine(IState startState, IStateSwitcher switcher)
    //{
    //    _startState = (State)startState;
    //    _currentState = _startState;
    //    _stateSwitcher = (StateSwitcher)switcher;
    //}
    //public void SetState(IState newState) { _currentState = (State)newState; }
}


public interface IStateMachine
{
    //public void SetState(IState newState);
}
