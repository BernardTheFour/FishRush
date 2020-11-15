using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine
{
    public enum PlayerAction
    {
        move, jump
    }

    public static PlayerAction ActionState { get; set; }

    public static Vector2 PlayerDirection { get; set; }

    public IMoveAction CurrentState { get; private set; }

    public string GetState()
    {
        return CurrentState.getName();
    }

    public void Initialize(IMoveAction startingState)
    {
        ActionState = PlayerAction.move;
        PlayerDirection = Vector2.zero;

        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(IMoveAction newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }
}
