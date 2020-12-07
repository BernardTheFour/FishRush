using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public static float Speed { private set; get; }

    private static float playTime;

    private static float multiplier = 0.6f;

    private void Update()
    {
        playTime += Time.deltaTime;
        Speed = CalculateSpeed(multiplier, playTime);
    }

    public static void Reset()
    {
        playTime = 0;
    }

    private float CalculateSpeed(float multiplier, float time)
    {
        float s = (2 / 3) * time + (2 * Mathf.Sin(time / 3)) + 5;
        return s * multiplier;
    }
}
