using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementState;
public class InputHorizontal : InputCommand
{
    public InputHorizontal() : base()
    {

    }

    public override void Execute(float Direction)
    {
        ActionState = Action.Move;
        PlayerDirection = Direction;
    }
}
