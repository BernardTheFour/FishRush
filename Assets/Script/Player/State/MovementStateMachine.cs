using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine
{
    public enum Action
    {
        Move, Jump
    }

    public static Action ActionState;
    public static float PlayerDirection;

    public MovementState CurrentState { get; private set; }

    public void Initialize (MovementState startingState)
    {
        ActionState = Action.Move;
        PlayerDirection = 0f;

        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(MovementState newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }
}
