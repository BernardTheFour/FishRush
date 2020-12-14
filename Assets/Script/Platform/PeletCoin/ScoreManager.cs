using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public static bool GameOver = false;
    [HideInInspector] public static int Score { set; get; }
    [HideInInspector] public static int Life { set; get; }

    private void Start()
    {
        Life = 2;
    }

    [HideInInspector] public static float VulnerableCoolDown;

    private void Update()
    {
        if (GameOver)
        {
            SpeedController.play = false;
            return;
        }
        else if (Life >= 2)
        {
            return;
        } else if (Life <= 0)
        {
            GameOver = true;
            return;
        }

        VulnerableCoolDown -= Time.deltaTime;
        
        if (VulnerableCoolDown < 0f)
        {
            Life += 1;
            VulnerableCoolDown = 2f;
        }
    }
}
