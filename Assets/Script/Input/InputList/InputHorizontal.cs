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
        if (Character.isGrounded)
        {
            MovementStateMachine.ActionState = MovementStateMachine.PlayerAction.move;
            MovementStateMachine.PlayerDirection = direction;
        }
    }
}
