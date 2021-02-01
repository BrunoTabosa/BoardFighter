using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class StateMachine
{
    public State currentState;
    public StateMachine()
    {
        SetState(new State());
    }

    public void SetState(State newState)
    {
        currentState?.Exit();

        currentState = newState;
        currentState.Enter();
    }
}
