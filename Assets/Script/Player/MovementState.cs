using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState
{
    public enum Action{
        Move, Jump
    }

    public static Action ActionState;
    public static float PlayerDirection;

    public MovementState(){

    }

    public virtual void Enter(){

    }

    public virtual void Enter(float direction){

    }

    public virtual void Exit(Action actionState){

    }

    public virtual void HandleUpdate(){

    }
}
