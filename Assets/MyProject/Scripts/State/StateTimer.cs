using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateTimer : State
{
    public float MaxTime;
    public float CurrentTime;
    public int IndexNextState;

    public virtual void CreateStateTimer(StateMachine machine, float maxTime, int indexNextState)
    {
        base.CreateState(machine);
        MaxTime = maxTime;
        CurrentTime = MaxTime;
        IndexNextState = indexNextState;
    }
    public override void Enter()
    {
        CurrentTime = MaxTime;
    }
    public override void UpdateState()
    {
        CurrentTime -= Time.deltaTime;
        if (CurrentTime < 0) { Machine.SwapState(IndexNextState); }
    }
    public override void Exit() { }

}
