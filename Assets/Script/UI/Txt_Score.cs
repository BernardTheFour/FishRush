using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt_Score : MonoBehaviour
{
    [SerializeField] private Text PoletScore = default;

    private void Update()
    {
        PoletScore.text = ScoreManager.Score.ToString();
    }
}
