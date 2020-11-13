using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputHorizontal : InputCommand
{
    public InputHorizontal() : base()
    {

    }

    public override void Execute(Vector2 direction)
    {
        MovementStateMachine.ActionState = MovementStateMachine.PlayerAction.move;
        MovementStateMachine.PlayerDirection = direction;
    }
}
