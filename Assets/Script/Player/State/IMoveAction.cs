using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAction
{
    void Enter();

    void Exit();

    void HandleState();
    void HandleLogic();

    void HandlePhysics();
}
