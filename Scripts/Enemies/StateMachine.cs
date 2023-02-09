using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public States currentState { get; private set; }

    public void Initialize(States startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(States newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
