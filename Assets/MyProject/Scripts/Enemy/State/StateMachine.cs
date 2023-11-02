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
   
    public void SetState(State newState) 
    {
        CurrentState = newState;
    }





}


public interface IStateMachine
{
}
