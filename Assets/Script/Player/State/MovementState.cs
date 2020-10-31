using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementState
{
    protected Character character;
    protected MovementStateMachine stateMachine;

    public MovementState(Character character, 
        MovementStateMachine stateMachine)
    {
        this.character = character;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void HandleState() { }
    public virtual void HandleLogic() { }

    public virtual void HandlePhysics() { }
}
