using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementStateMachine;

public class PlayerMoving : IMoveAction
{
    private string NAME = "Move";

    private float targetPosition;
    private float currentPosition;
    private float maxVelocity;
    private float speedChange;

    private float velocityChange;
    private float currentVelocity;
    private float targetVelocity;

    private Vector3 finalSpeed = default;

    private Rigidbody fishRB = default;

    private Character character = default;
    private MovementStateMachine stateMachine = new MovementStateMachine();

    public PlayerMoving(Character character, MovementStateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;

        fishRB = this.character.MyRigidbody;
        maxVelocity = this.character.MaxVelocity;
        speedChange = this.character.SpeedChange;
    }

    public void Enter()
    { }

    public void Exit()
    { }

    public void HandleLogic()
    {
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

    public void HandlePhysics()
    {
        fishRB.AddForce(finalSpeed, ForceMode.VelocityChange);
    }

    public void HandleState()
    {
        switch (ActionState)
        {
            case PlayerAction.jump:
                // jump
                stateMachine.ChangeState(character.JumpingState);
                break;
        }
    }

    public string getName()
    {
        return NAME;
    }
}
