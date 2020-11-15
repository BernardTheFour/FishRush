using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementStateMachine;

public class PlayerJump : IMoveAction
{
    private string NAME = "Jump";

    private Rigidbody fishRB = new Rigidbody();
    private float jumpForce;

    private Character character;
    private MovementStateMachine stateMachine;

    public PlayerJump(Character character, MovementStateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;

        fishRB = character.MyRigidbody;
        jumpForce = character.JumpForce;
    }

    public void Enter()
    {
        fishRB.velocity = Vector3.zero;
        fishRB.AddForce(character.transform.up * jumpForce, ForceMode.Impulse);
    }

    public void Exit()
    { }

    public void HandleState()
    {
        switch (ActionState)
        {
            case PlayerAction.move:
                // jump
                stateMachine.ChangeState(character.MovingState);
                break;
        }
    }

    public string getName()
    {
        return NAME;
    }

    public void HandleLogic()
    { }

    public void HandlePhysics()
    { }
}
