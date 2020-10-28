using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementState;

public class InputJump : InputCommand
{
    public InputJump()
    {
    }

    public override void Execute()
    {
        ActionState = Action.Jump;
    }
}
