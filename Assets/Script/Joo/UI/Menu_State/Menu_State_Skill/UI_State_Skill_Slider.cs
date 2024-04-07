using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class UI_State_Skill_Slider : MonoBehaviour
{
    public static UI_State_Skill_Slider skill_slider;

    [SerializeField]
    UI_State_Skill_List[] slider;

    void Awake()
    {
        //skill_slider = this;

        //for (int i = 0; i < slider.Length; i++)
        //{
        //    slider[i].value = 0;
        //}
    }

    public void Set_SkillBar_slider(float value, int level)
    {
        //for(int i = 0; i < level-1; i++)
        //{
        //    slider[level].value = 1;
        //}
        //slider[level].value = value;
    }


}
