using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WorldPositionOnPlane;

public class InputTouch : MonoBehaviour
{
    private Vector2 initialTouch;
    private Vector3 currentTouch;
    private Vector2 finalTouch;
    private Touch myTouch;

    private float swipeAngle;

    private const float SWIPETIME = 0.2f;
    private const float SWIPEDISTANCE = 100f;
    private const float ANGLETHRESOLD = 30f;

    private Thresold timeThresold;

    private Thresold distanceThresold;

    private static InputHorizontal inputHorizontal;
    private static InputJump inputJump;

    private WorldPositionOnPlane horizontalPlane;

    private void Awake()
    {
        myTouch = new Touch();
        timeThresold = new Thresold();
        distanceThresold = new Thresold();

        inputHorizontal = new InputHorizontal();
        inputJump = new InputJump();

        horizontalPlane = new WorldPositionOnPlane(orientation: Orientation.horizontal, offset: 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        myTouch = Input.GetTouch(0);
        switch (myTouch.phase)
        {
            case TouchPhase.Began:
                initialTouch = myTouch.position;

                //start the time counter
                timeThresold.Min = Time.time;
                break;

            case TouchPhase.Moved:
                //Code for horizontal movement
                currentTouch = myTouch.position;

                if (currentTouch.y < Screen.height * 0.2f)
                {
                    Vector3 direction = horizontalPlane.GetPoint(currentTouch);
                    inputHorizontal.Execute(direction: new Vector2(direction.x, direction.z));
                }                

                //Debug.Log("Input position: " + WorldPoint);
                break;

            case TouchPhase.Ended:
                //Code for jump behaviour
                finalTouch = myTouch.position;

                //Calculate time thresold
                timeThresold.Max = Time.time;
                timeThresold.Delta = timeThresold.Min - timeThresold.Max;

                //Calculate distance thresold 
                distanceThresold.Min = initialTouch.y - SWIPEDISTANCE;
                distanceThresold.Max = initialTouch.y + SWIPEDISTANCE;

                //find the swipe angle
                swipeAngle = distanceThresold.Angle(initialTouch, finalTouch);

                if (timeThresold.Delta > SWIPETIME || swipeAngle > ANGLETHRESOLD)
                {
                    //Time too long to be a swipe or not vertical enough to be called vertical swipe
                    //Debug.Log("Finger " + myTouch.fingerId + " is ended");
                    break;
                }

                if (finalTouch.y > distanceThresold.Max)
                {
                    //Jump
                    //Debug.Log("Jump");
                    inputJump.Execute();
                }
                else if (finalTouch.y < distanceThresold.Min)
                {
                    //Dive
                    //Debug.Log("Return to water");
                }
                break;
        }
    }
}
