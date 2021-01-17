using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Play : MonoBehaviour
{
    [SerializeField] private GameObject BtnPlay = default;
    [SerializeField] private GameObject Title = default;

    private static GameObject s_BtnPlay = default;
    private static GameObject s_Title = default;

    private void Awake()
    {
        s_BtnPlay = BtnPlay;
        s_Title = Title;
    }

    public void PlayGame()
    {
        SpeedController.play = true;

        ShowTitle(false);
    }

    public static void ShowTitle(bool value)
    {
        s_BtnPlay.SetActive(value);
        s_Title.SetActive(value);
    }
}
