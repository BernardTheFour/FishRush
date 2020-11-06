using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thresold
{
    public float Min { get; set; }
    public float Max { get; set; }

    private float y2y1;
    private float x2x1;
    private float angle;
    private float delta;

    public float Delta
    {
        set { delta = Mathf.Abs(value); }
        get { return delta; }
    }

    public float Angle(Vector2 firstPoint, Vector2 lastPoint)
    {
        /*angle = atan(y2-y1)/(x2-x1)
         * 
         * well just read as it is
         */
        y2y1 = Mathf.Abs(firstPoint.y - lastPoint.y);
        x2x1 = Mathf.Abs(firstPoint.x - lastPoint.x);
        angle = Mathf.Abs(Mathf.Atan2(y2y1, x2x1) * Mathf.Rad2Deg);

        //return angle from vertical standpoint
        return 90 - angle;
    }
}
