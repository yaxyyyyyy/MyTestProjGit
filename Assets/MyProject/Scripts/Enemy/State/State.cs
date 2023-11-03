using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class State
{
    public StateMachine Machine;
    public void CreateState(StateMachine machine) { Machine = machine; }
    public abstract void UpdateState();
    public abstract void Enter();
    public abstract void Exit();

}

