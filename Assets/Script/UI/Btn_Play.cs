using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Play : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas = default;

    private static GameObject s_MainMenuCanvas = default;

    private void Awake()
    {
        s_MainMenuCanvas = MainMenuCanvas;
    }

    public void PlayGame()
    {
        SpeedController.play = true;

        ShowTitle(false);
    }

    public static void ShowTitle(bool value)
    {
        s_MainMenuCanvas.SetActive(value);
    }
}
