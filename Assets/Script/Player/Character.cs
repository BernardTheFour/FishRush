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
    public Rigidbody fishRB;
    #endregion

    #region CharacterVariables
    public float Speed;
    public float targetPosition;
    #endregion

    #region Monobehavior Callbacks
    private void Start()
    {
        fishRB = this.GetComponent<Rigidbody>();

        movementSM = new MovementStateMachine();

        MovingState = new PlayerMoving(this, movementSM);
        JumpingState = new PlayerJump(this, movementSM);

        movementSM.Initialize(MovingState);
    }

    private void Update()
    {
        movementSM.CurrentState.HandleState();
        //Debug.Log("Target Position: " + targetPosition);
    }

    private void FixedUpdate()
    {
        movementSM.CurrentState.HandlePhysics();
    }

    #endregion
}
