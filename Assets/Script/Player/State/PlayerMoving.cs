using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementStateMachine;

public class PlayerMoving : MovementState
{   
    private float targetPosition;
    private float MoveSpeed;
    private float deltaPosY;

    private Vector3 deltaPos = new Vector3();
    private Vector3 initialPosition = new Vector3();
    private Rigidbody fishRB = new Rigidbody();
    public PlayerMoving(Character character, MovementStateMachine stateMachine) : base(character, stateMachine)
    {
        fishRB = character.fishRB;
        targetPosition = character.targetPosition;
        MoveSpeed = character.Speed;

        initialPosition.y = fishRB.position.y;
        initialPosition.z = fishRB.position.z;
    }

    public override void Enter()
    {
        // do not delete base
        base.Enter();
        fishRB.useGravity = false;
    }

    public override void Exit()
    {
        // do not delete base
        base.Exit();
    }

    public override void HandleLogic()
    {
        base.HandleLogic();
    }

    public override void HandlePhysics()
    {
        // do not delete base
        base.HandlePhysics();

        deltaPos = initialPosition - fishRB.position;
        deltaPosY = targetPosition - fishRB.position.y;

        deltaPos.y = deltaPosY;
        fishRB.velocity = 1f / Time.fixedDeltaTime * deltaPos * Mathf.Pow(MoveSpeed, 90f * Time.fixedDeltaTime);

    }

    public override void HandleState()
    {
        // do not delete base
        base.HandleState();
        
        //switch (ActionState)
        //{
        //    case Action.Jump:
        //        // jump
        //        stateMachine.ChangeState(character.JumpingState);
        //        break;
        //}
    }
}
