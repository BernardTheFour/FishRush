using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    [SerializeField] private GameObject DebugCard = null;
    [SerializeField] private Text StateText = null;
    [SerializeField] private Text PositionText = null;

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
}
