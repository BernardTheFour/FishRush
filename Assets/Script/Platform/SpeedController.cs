using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController
{
    public static float Speed { private set; get; }

    public static float playTime;

    private static float multiplier = 0.8f;

    public static bool play = false;

    public static void RunUpdate()
    {
        if (!play)
        {
            Reset();
            return;
        }

        
        playTime += Time.deltaTime;
        Speed = CalculateSpeed(multiplier, playTime);
        //Debug.Log("Speed: " + Speed);
    }

    public static void Reset()
    {
        playTime = 0;
        Speed = 0;
        ScoreManager.Reset();
        Btn_Play.ShowTitle(true);
    }

    private static float CalculateSpeed(float multiplier, float time)
    {
        float s = (2 / 3) * time + (2 * Mathf.Sin(time/ 3)) + 5;
        float totalSpeed = (s) + (time / 30);
        return totalSpeed * multiplier;
    }

    public static IEnumerator Timer() {
        yield return new WaitForSeconds(5f);
        play = true;
    }
}
