using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameScreen : MonoBehaviour
{
    public UnityEngine.UI.Text Screen_change_button_text;
    public bool Fullscreen_Mode = true;
    bool Current_mode = false;

    public GameObject Ui_title;
    public GameObject Button_title;
    public void OnEnable()
    {
        Current_mode = Fullscreen_Mode;

        if (Ui_title.activeSelf)
            Button_title.SetActive(false);
        else
            Button_title.SetActive(true);

    }

    public void Fullscreen()
    {
        if (Fullscreen_Mode)  // 전체화면 -> 창모드
        {
            Fullscreen_Mode = false;
            Screen_change_button_text.text = "ON";
        }
        else
        {
            Fullscreen_Mode = true;
            Screen_change_button_text.text = "OFF";
        }
    }

    public void Set_Screen(bool Change)  // 확인 누르면 true
    {
        if (!Change)
        {
            Fullscreen_Mode = Current_mode;
        }
    }
}
