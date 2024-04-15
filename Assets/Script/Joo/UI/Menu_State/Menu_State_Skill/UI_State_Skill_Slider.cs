using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class UI_State_Skill_Slider : MonoBehaviour
{
    [SerializeField]
    UI_State_Skill_List[] slider;

    public Sprite Image;

    void Awake()
    {
        for (int i = 0; i < slider.Length; i++)
        {
            slider[i].Slider.value = 0;
        }
    }

    public void Set_SkillBar_slider(float value, int level)
    {
        for(int i = 0; i < level; i++)
        {
            slider[i].Slider.value = 1;
            slider[i].Image.sprite = Image;
        }
        slider[level].Slider.value = value;
    }

}
