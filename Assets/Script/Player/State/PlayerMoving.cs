using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MovementState
{
    private float targetPosition;
    private float currentPosition;
    private float maxVelocity;
    private float speedChange;

    private float velocityChange;
    private float currentVelocity;
    private float targetVelocity;

    private Vector3 finalSpeed = new Vector3();

    private Rigidbody fishRB = new Rigidbody();
    public PlayerMoving(Character character, MovementStateMachine stateMachine) : base(character, stateMachine)
    {
        fishRB = character.myRigidbody;
        maxVelocity = character.MaxVelocity;
        speedChange = character.SpeedChange;
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
        base.HandleLogic();

        //copy the value from character controller
        targetPosition = character.TargetPosition;
        currentPosition = fishRB.transform.position.x;

        //get current velocity
        currentVelocity = fishRB.velocity.x;

        //get vector direction
        targetVelocity = targetPosition - currentPosition;
        targetVelocity = Mathf.Clamp(targetVelocity, -1, 1);

        //calculate how fast we should move
        targetVelocity *= speedChange;

        //apply force that attemp to reach target velocity
        velocityChange = targetVelocity - currentVelocity;
        velocityChange = Mathf.Round(velocityChange * 100f) / 100f;
        velocityChange = Mathf.Clamp(velocityChange, -maxVelocity, maxVelocity);


        ////set those value to Vector3 format
        finalSpeed = fishRB.velocity;
        finalSpeed.x = velocityChange;
    }

    public override void HandlePhysics()
    {
        // do not delete base
        base.HandlePhysics();

        fishRB.AddForce(finalSpeed, ForceMode.VelocityChange);

        //Debug.Log("TargetPosition: " + targetPosition);
        //Debug.Log("CurrentVelocity: " + currentVelocity
        //    + "\nTargetVelocity: " + targetVelocity
        //    + "\nVelocityChange: " + velocityChange
        //    + "\nFinalSpeed: " + finalSpeed);

        //Debug.Log("Max Velocity: " + maxVelocity
        //    + "\nSpeedChange: " + speedChange);
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
