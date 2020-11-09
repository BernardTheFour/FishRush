using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MovementStateMachine;

public class PlayerJump : MonoBehaviour, IMoveAction
{
    private bool midAir = false;

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
        midAir = true;
    }

    public void Exit()
    {
        midAir = false;
    }

    public void HandleLogic()
    {
        Debug.Log("State: Jump");
    }

    public void HandlePhysics()
    {    }

    public void HandleState()
    {
        if (!midAir)
        {
            stateMachine.ChangeState(character.MovingState);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
