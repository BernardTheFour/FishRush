using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouch : MonoBehaviour
{
    private Vector2 InitialTouch;
    private Vector2 CurrentTouch;
    private Vector2 FinalTouch;
    private Touch myTouch;

    private float SwipeAngle;

    private const float SWIPETIME = 0.2f;
    private const float SWIPEDISTANCE = 100f;
    private const float ANGLETHRESOLD = 30f;

    private Thresold timeThresold = new Thresold();

    private Thresold distanceThresold = new Thresold();

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);

            switch (myTouch.phase)
            {
                case TouchPhase.Began:
                    InitialTouch = myTouch.position;
                    Debug.Log("Finger " + myTouch.fingerId + " is began");

                    //start the time counter
                    timeThresold.Min = Time.time;
                    break;

                case TouchPhase.Moved:
                    CurrentTouch = myTouch.position;
                    Debug.Log("Finger " + myTouch.fingerId + " is moving to " + CurrentTouch);
                    break;

                case TouchPhase.Ended:
                    FinalTouch = myTouch.position;

                    timeThresold.Max = Time.time;
                    timeThresold.Delta = timeThresold.Min - timeThresold.Max;

                    distanceThresold.Min = InitialTouch.y - SWIPEDISTANCE;
                    distanceThresold.Max = InitialTouch.y + SWIPEDISTANCE;

                    //find the swipe angle
                    SwipeAngle = distanceThresold.Angle(InitialTouch, FinalTouch);
                    Debug.Log("Angle Thresold: " + SwipeAngle);

                    if (timeThresold.Delta > SWIPETIME || SwipeAngle > ANGLETHRESOLD)
                    {   //Time too long to be a swipe or not vertical enough to be called vertical swipe
                        Debug.Log("Finger " + myTouch.fingerId + " is ended");
                        break;
                    }

                    if (FinalTouch.y > distanceThresold.Max)
                    {
                        //Jump
                        Debug.Log("Finger " + myTouch.fingerId + " swiping up");
                    }
                    else if (FinalTouch.y < distanceThresold.Min)
                    {
                        //Return to water
                        Debug.Log("Finger " + myTouch.fingerId + " swiping down");
                    }
                    else
                    {   //Swipe is not far enough
                        Debug.Log("Finger " + myTouch.fingerId + " is ended");
                    }
                    break;
            }
        }
    }
}
