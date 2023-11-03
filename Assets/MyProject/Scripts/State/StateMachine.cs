using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class StateMachine
{
    public List<State> States { get; private set; } = new List<State>();
    public int CurrentState;

    public void CreateMachine(List<State> states, int indexCurrentState) { States = states; CurrentState = indexCurrentState; }

    public virtual void UpdateMachine()
    {
        States[CurrentState].UpdateState();
    }

    public virtual void SwapState(int nextState) { States[CurrentState].Exit(); /*Debug.Log("swap to " + nextState);*/ CurrentState = nextState; States[CurrentState].Enter(); }

}


