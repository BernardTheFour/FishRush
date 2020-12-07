using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController
{
    public static float Speed { private set; get; }

    private static float playTime;

    private static float multiplier = 1;

    private static bool play = false;

    public static void RunUpdate()
    {
        if (!play)
        {
            return;
        }

        playTime += Time.deltaTime;
        Speed = CalculateSpeed(multiplier, playTime);
        //Debug.Log("Speed: " + Speed);
    }

    public static void Reset()
    {
        playTime = 0;
    }

    private static float CalculateSpeed(float multiplier, float time)
    {
        float s = (2 / 3) * time + (2 * Mathf.Sin(time / 3)) + 5;
        return s * multiplier;
    }

    public static IEnumerator Timer() {
        yield return new WaitForSeconds(5f);
        play = true;
    }
}
