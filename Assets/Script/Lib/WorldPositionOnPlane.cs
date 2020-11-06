using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPositionOnPlane
{
    public enum Orientation
    {
        horizontal, vertical
    }

    private Ray ray = new Ray();
    private Plane plane = new Plane();
    private float distance;

    public WorldPositionOnPlane(Orientation orientation, float offset)
    {
        switch (orientation)
        {
            case Orientation.horizontal:
                plane = new Plane(Vector3.up, new Vector3(0, offset, 0));
                break;
            case Orientation.vertical:
                plane = new Plane(Vector3.forward, new Vector3(0, 0, offset));
                break;
        }
    }

    public Vector3 GetPoint(Vector3 screenPosition)
    {
        ray = Camera.main.ScreenPointToRay(screenPosition);
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
