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
    //{

    //}

    public void SwitchState(int index)
    {
        StateMachine.CurrentState.ExitState();
        var newState = States[index];
        newState.EnterState();
        StateMachine.SetState(newState);
        //return state.CanSwitch ? States[index] : state.SetCanState();
    }

    //public StateMachine Machine;
    //public List<IState> StatesAll;
    //public void CreateSwitcher(IStateMachine machine)
    //{
    //    Machine = (StateMachine)machine;
    //}
    //public void CreateSwitcher(StateMachine machine)
    //{
    //    Machine = machine;
    //    Machine.CurrentState.Ev_EndState.AddListener(SwitchState);
    //}
    //public void SwitchState(IState state) { Machine.CurrentState.Exit(); state.Enter(); Machine.SetState(state); }
    //public void SwitchState(State state) { Machine.CurrentState.Exit(); state.Ev_EndState.AddListener(SwitchState); state.Enter(); Machine.SetState(state);}
}

public interface IStateSwitcher
{
    //public void CreateSwitcher(IStateMachine machine);
    //public void SwitchState(IState state);
}
