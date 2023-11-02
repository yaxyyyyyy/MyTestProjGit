using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class StateSwitcher:IStateSwitcher
{
    public StateMachine StateMachine { get; private set; }
    public List<State> States { get; set; } = new List<State>();

    public void CreateStateSwitcher(StateMachine machine, List<State> states, int indexCurrentState )
    {
        StateMachine = machine;
        foreach(var state in states)
        {
            state.CreateState(this);
        }
        states[indexCurrentState].EnterState();
        machine.SetState(states[indexCurrentState]);
    }
    public abstract void EndState(State state);

    public void SwitchState(int index)
    {
        StateMachine.CurrentState.ExitState();
        var newState = States[index];
        newState.EnterState();
        StateMachine.SetState(newState);
    }

}

public interface IStateSwitcher
{
}
