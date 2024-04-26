using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_Skill_text : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static UI_State_Skill_text UI_Skill_window;

    public GameObject Detail_info_window;
    public int num;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Detail_info_window.SetActive(true);
        UI_State_Skill.state_skill_info.Set_InfoWindow(num);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Detail_info_window.SetActive(false);
    }

    private void Start()
    {
        UI_Skill_window = this;
        UI_State_Skill_Slider sslider = GetComponent<UI_State_Skill_Slider>();
        switch (num)
        {
            case 0:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Fitness_Level.Get_P_EXP(),
                    (int)Player_main.player_main.Skill.Fitness_Level.Get_P_Level());
                break;
            case 1:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Strength_Level.Get_P_EXP(),
                    (int)Player_main.player_main.Skill.Strength_Level.Get_P_Level());
                break;
            case 2:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Sprinting_Level.Get_G_EXP(),
                    (int)Player_main.player_main.Skill.Sprinting_Level.Get_G_Level());
                break;
            case 3:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Lightfooted_Level.Get_G_EXP(),
                    (int)Player_main.player_main.Skill.Lightfooted_Level.Get_G_Level());
                break;
            case 4:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Nimble_Level.Get_G_EXP(),
                    (int)Player_main.player_main.Skill.Nimble_Level.Get_G_Level());
                break;
            case 5:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Sneaking_Level.Get_G_EXP(),
                    (int)Player_main.player_main.Skill.Sneaking_Level.Get_G_Level());
                break;
            case 6:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Axe_Level.Get_W_EXP(),
                    (int)Player_main.player_main.Skill.Axe_Level.Get_W_Level());
                break;
            case 7:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.LongBlunt_Level.Get_W_EXP(),
                    (int)Player_main.player_main.Skill.LongBlunt_Level.Get_W_Level());
                break;
            case 8:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.ShortBlunt_Level.Get_W_EXP(),
                    (int)Player_main.player_main.Skill.ShortBlunt_Level.Get_W_Level());
                break;
            case 9:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.LongBlade_Level.Get_W_EXP(),
                    (int)Player_main.player_main.Skill.LongBlade_Level.Get_W_Level());
                break;
            case 10:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.ShortBlade_Level.Get_W_EXP(),
                    (int)Player_main.player_main.Skill.ShortBlade_Level.Get_W_Level());
                break;
            case 11:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Spear_Level.Get_W_EXP(),
                    (int)Player_main.player_main.Skill.Spear_Level.Get_W_Level());
                break;
            case 12:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Maintenance_Level.Get_M_EXP(),
                    (int)Player_main.player_main.Skill.Maintenance_Level.Get_M_Level());
                break;
            case 13:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Aiming_Level.Get_Gun_EXP(),
                    (int)Player_main.player_main.Skill.Aiming_Level.Get_Gun_Level());
                break;
            case 14:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Reloading_Level.Get_Gun_EXP(),
                    (int)Player_main.player_main.Skill.Reloading_Level.Get_Gun_Level());
                break;
            case 16:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Hunting_Level.Get_S_EXP(),
                    (int)Player_main.player_main.Skill.Hunting_Level.Get_S_Level());
                break;
            case 15:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Fishing_Level.Get_S_EXP(),
                    (int)Player_main.player_main.Skill.Fishing_Level.Get_S_Level());
                break;
            case 17:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Foraging_Level.Get_S_EXP(),
                    (int)Player_main.player_main.Skill.Foraging_Level.Get_S_Level());
                break;
            case 18:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Riding_Level.Get_S_EXP(),
                    (int)Player_main.player_main.Skill.Riding_Level.Get_S_Level());
                break;
            case 19:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Carpentry_Level.Get_C_EXP(),
                    (int)Player_main.player_main.Skill.Carpentry_Level.Get_C_Level());
                break;
            case 20:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Cooking_Level.Get_C_EXP(),
                    (int)Player_main.player_main.Skill.Cooking_Level.Get_C_Level());
                break;
            case 21:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Farming_Level.Get_C_EXP(),
                    (int)Player_main.player_main.Skill.Farming_Level.Get_C_Level());
                break;
            case 22:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.FirstAid_Level.Get_C_EXP(),
                    (int)Player_main.player_main.Skill.FirstAid_Level.Get_C_Level());
                break;
            case 23:
                sslider.Set_SkillBar_slider(Player_main.player_main.Skill.Electrical_Level.Get_C_EXP(),
                    (int)Player_main.player_main.Skill.Electrical_Level.Get_C_Level());
                break;
            default: break;
        }
    }
}
