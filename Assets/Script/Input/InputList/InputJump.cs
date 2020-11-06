using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementStateMachine;

public class InputJump : InputCommand
{
    public InputJump()
    {
    }

    public override void Execute()
    {
        ActionState = Action.jump;
    }
}
