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
        MovementStateMachine.ActionState = MovementStateMachine.Action.move;
        MovementStateMachine.PlayerDirection = direction;
    }
}
