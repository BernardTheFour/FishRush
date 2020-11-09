/*Put this code inside fish main gameobject
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    #region StateMachineVariables
    public MovementStateMachine movementSM;
    public PlayerMoving MovingState;
    public PlayerJump JumpingState;
    #endregion

    #region UnityComponentVariables
    public Rigidbody MyRigidbody;
    #endregion

    #region CharacterVariables
    public float MaxVelocity { get; private set; }
    public float SpeedChange { get; private set; }
    public float TargetPosition { get; private set;}
    public float JumpForce { get; private set; }
    #endregion

    #region Monobehavior Callbacks
    private void Awake()
    {
        //initialize this first before assigned to object
        MaxVelocity = 1f;
        SpeedChange = 8f;

        MyRigidbody = this.GetComponent<Rigidbody>();

        movementSM = new MovementStateMachine();

        MovingState = new PlayerMoving(this, movementSM);
        JumpingState = new PlayerJump(this, movementSM);        
    }

    private void Start()
    {
        movementSM.Initialize(MovingState);
    }

    private void Update()
    {
        TargetPosition = MovementStateMachine.PlayerDirection.x;

        movementSM.CurrentState.HandleState();
        movementSM.CurrentState.HandleLogic();
        //Debug.Log("Target Position: " + targetPosition);
    }

    private void FixedUpdate()
    {
        movementSM.CurrentState.HandlePhysics();
    }
    #endregion
}
