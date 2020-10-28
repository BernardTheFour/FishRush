using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    private Vector2 InitialTouchCoordinate;
    private Vector2 CurrentTouchCoordinate;
    private Vector2 FinalTouchCoordinate;
    private Touch myTouch;

    private float SwipeThreesold = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);

            switch (myTouch.phase)
            {
                case TouchPhase.Began:
                    InitialTouchCoordinate = myTouch.position;
                    Debug.Log(myTouch + " is began");
                    break;
                case TouchPhase.Moved:
                    CurrentTouchCoordinate = myTouch.position;
                    Debug.Log(myTouch + " is moving to " + CurrentTouchCoordinate);
                    break;
                case TouchPhase.Ended:
                    FinalTouchCoordinate = myTouch.position;

                    if (FinalTouchCoordinate.y > SwipeThreesold)
                    {
                        //Jump
                        Debug.Log(myTouch + " swiping up");
                    }
                    else if (FinalTouchCoordinate.y < -SwipeThreesold)
                    {
                        //Return
                        Debug.Log(myTouch + " swiping down");
                    }
                    break;
            }
        }
    }
}
