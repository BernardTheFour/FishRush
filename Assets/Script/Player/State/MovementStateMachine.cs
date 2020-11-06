using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine
{
    public enum Action
    {
        move, jump
    }

    public static Action ActionState { get; set; }

    public static Vector2 PlayerDirection { get; set; }

    public MovementState CurrentState { get; private set; }

    public void Initialize (MovementState startingState)
    {
        ActionState = Action.move;
        PlayerDirection = Vector2.zero;

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
