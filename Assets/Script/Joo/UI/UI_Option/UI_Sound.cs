using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Sound : MonoBehaviour
{
    public UnityEngine.UI.Slider[] slider;
    public UnityEngine.UI.Image[] Sound_Image;
    public UnityEngine.UI.Button[] Buttons; // 1, 2번 버튼만
    public Sprite[] Sound_Image_array;

    float[] Current_slider = new float[3];
    UnityEngine.UI.Image[] Current_Sound_Image = new UnityEngine.UI.Image[3];

    private void Start()
    {
        for(int i = 0; i < slider.Length; i++)
        {
            slider[i].value = 0;
        }
    }

    private void OnEnable()
    {
        for(int i = 0; i < slider.Length; i++)
        {
            Current_slider[i] = slider[i].value;
            Current_Sound_Image[i] = Sound_Image[i];
        }
    }

    public void Change_Sound_Image()
    {
        for (int i = 0; i < slider.Length; i++)
        {
            if (slider[i].value > -40)
            {
                Sound_Image[i].sprite = Sound_Image_array[0];
            }
            else
            {
                Sound_Image[i].sprite = Sound_Image_array[1];
            }
        }

        if (slider[0].value <= -40)
        {
            for(int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = false;
                slider[i + 1].interactable = false;
            }
        }
        else
        {
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].interactable = true;
                slider[i + 1].interactable = true;
            }
        }
    }

    float temp = 0;

    public void Mute_Sound(UnityEngine.UI.Slider this_slider)
    {
        if(this_slider.value > -40)   // Mute
        {
            temp = this_slider.value;
            this_slider.value = -40;
        }
        else
        {
            this_slider.value = temp;
        }
    }

    public void Set_Sound(bool Change)  // 확인 누르면 true
    {
        if (!Change)
        {
            for (int i = 0; i < slider.Length; i++)
            {
                slider[i].value = Current_slider[i];
                Sound_Image[i] = Current_Sound_Image[i];
            }
        }

    }
}
