using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    [SerializeField] private GameObject DebugCard = default;

    [Space(10)]
    [SerializeField] private Text GameOverText = default;
    [SerializeField] private Text PlayTimeText = default;
    [SerializeField] private Text StateText = default;
    [SerializeField] private Text PositionText = default;
    [SerializeField] private Text SpeedText = default;

    [Space(10)]
    [SerializeField] private Text PoletScoreText = default;
    [SerializeField] private Text LifesText = default;
    [SerializeField] private Text VulnerableCDText = default;

    private static bool debugIsActive;

    public bool showDebug
    {
        set
        {
            DebugCard.SetActive(value);
            debugIsActive = value;
        }
        get
        {
            return debugIsActive;
        }
    }
    public bool GameOver
    {
        set
        {
            GameOverText.text = "GameOver\t: " + value;
        }
    }

    public float PlayTime
    {
        set
        {
            PlayTimeText.text = "PlayTime\t: " + (int) value;
        }
    }

    public string State
    {
        set
        {
            StateText.text =    "State\t\t: " + value;
        }
    }
    public Vector3 Position
    {
        set
        {
            PositionText.text = "Position\t: " + value;
        }
    }

    public float Speed
    {
        set
        {

            SpeedText.text = "Speed\t\t: " + Rounded(value, 2);
        }
    }

    public int PoletScore
    {
        set
        {
            PoletScoreText.text = "Pelet(s)\t\t: " + value;
        }
    }

    public int Lifes
    {
        set
        {
            LifesText.text = "Life\t\t\t: " + value;
        }
    }

    public float VulnerableCD { 
    set
        {
            float newValue = value;

            if (value >= 2f)
            {
                newValue = 0;
            }

            VulnerableCDText.text = "LifeCD\t\t: " + Rounded(newValue, 1) + " s"; 
        }
    }

    private float Rounded(float value, int decimals)
    {
        int pow = (int) Mathf.Pow(10, decimals);
        return Mathf.Round(value * pow) / pow;
    }
}
