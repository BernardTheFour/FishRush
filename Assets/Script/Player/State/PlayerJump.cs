using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MovementState
{
    public PlayerJump(Character character, MovementStateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        // do not delete base
        base.Enter();
    }

    public override void Exit()
    {
        // do not delete base
        base.Exit();
    }

    public override void HandleLogic()
    {
        // do not delete base
        base.HandleLogic();
    }

    public override void HandlePhysics()
    {
        // do not delete base
        base.HandlePhysics();
    }

    public override void HandleState()
    {
        // do not delete base
        base.HandleState();
    }
}
