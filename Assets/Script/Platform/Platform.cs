using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Platform
{
    public string Name;
    [Range(0f,1f)]
    [Tooltip("From 0 to 1")]
    public float Probability;
    public List<GameObject> Platforms;

    public float CumulativeProbability;
}
