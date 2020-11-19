﻿/*Put this code inside fish main gameobject
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    #region StateMachineVariables
    public MovementStateMachine movementSM { get; private set; }
    public PlayerMoving MovingState { get; private set; }
    public PlayerJump JumpingState { get; private set; }
    #endregion

    #region UnityComponentVariables
    public Rigidbody MyRigidbody { get; private set; }
    #endregion

    #region CharacterVariables
    public float MaxVelocity { get; private set; }
    public float SpeedChange { get; private set; }
    public float TargetPosition { get; private set;}
    public float JumpForce { get; private set; }
    #endregion

    #region CharacterBoolean
    public static bool isGrounded { get; private set; }
    #endregion

    #region Monobehavior Callbacks

    [SerializeField] private Debugging debugger = null;

    private void Awake()
    {
        //initialize this first before assigned to object
        MaxVelocity = 1f;
        SpeedChange = 8f;
        JumpForce = 5f;

        MyRigidbody = this.GetComponent<Rigidbody>();

        movementSM = new MovementStateMachine();

        MovingState = new PlayerMoving(this, movementSM);
        JumpingState = new PlayerJump(this, movementSM);    
    }

    private void Start()
    {
        movementSM.Initialize(MovingState);

        debugger.showDebug = true;
    }

    private void Update()
    {
        TargetPosition = MovementStateMachine.PlayerDirection.x;

        movementSM.CurrentState.HandleState();
        movementSM.CurrentState.HandleLogic();

        if (debugger.showDebug)
        {
            debugger.State = movementSM.GetState();
            debugger.Position = transform.position;
        }
    }

    private void FixedUpdate()
    {
        movementSM.CurrentState.HandlePhysics();
    }
    #endregion

    #region Collision Detection
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("River"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("River"))
        {
            isGrounded = false;
        }
    }
    #endregion    
}
