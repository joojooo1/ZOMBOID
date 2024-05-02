using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_text : MonoBehaviour
{
    Animator anim;
    public GameObject text_window;
    public UnityEngine.UI.Text text_window_text;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void text_window_playing(string text, string text_kr)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            text_window_text.text = text_kr;
        }
        else
        {
            text_window_text.text = text;
        }

        anim.SetTrigger("talk");
    }
}
