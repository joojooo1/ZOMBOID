using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_Skill_text : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
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

    private void OnEnable()
    {
        switch (num)
        {
            case 0:
                UI_State_Skill_Slider.skill_slider.Set_SkillBar_slider(Player_main.player_main.Skill.Fitness_Level.Get_P_CurrentEXP()
                    / Player_main.player_main.Skill.Fitness_Level.Get_P_TotalEXP(),
                    (int)Player_main.player_main.Skill.Fitness_Level.Get_P_Level());
                break;
            case 1:
                UI_State_Skill_Slider.skill_slider.Set_SkillBar_slider(Player_main.player_main.Skill.Strength_Level.Get_P_CurrentEXP()
                    / Player_main.player_main.Skill.Strength_Level.Get_P_TotalEXP(),
                    (int)Player_main.player_main.Skill.Strength_Level.Get_P_Level());
                break;
            case 2:
                UI_State_Skill_Slider.skill_slider.Set_SkillBar_slider(Player_main.player_main.Skill.Sprinting_Level.Get_G_CurrentEXP()
                    / Player_main.player_main.Skill.Sprinting_Level.Get_G_TotalEXP(),
                    (int)Player_main.player_main.Skill.Sprinting_Level.Get_G_Level());
                break;
            case 3:
                UI_State_Skill_Slider.skill_slider.Set_SkillBar_slider(Player_main.player_main.Skill.Lightfooted_Level.Get_G_CurrentEXP()
                    / Player_main.player_main.Skill.Lightfooted_Level.Get_G_TotalEXP(),
                    (int)Player_main.player_main.Skill.Lightfooted_Level.Get_G_Level());
                break;
            //case 4:
            //    Name_text.text = Player_main.player_main.Skill.Nimble_Level.Get_G_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Nimble_Level.Get_G_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Nimble_Level.Get_G_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Nimble_Level.Get_G_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 5:
            //    Name_text.text = Player_main.player_main.Skill.Sneaking_Level.Get_G_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Sneaking_Level.Get_G_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Sneaking_Level.Get_G_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Sneaking_Level.Get_G_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 6:
            //    Name_text.text = Player_main.player_main.Skill.Axe_Level.Get_W_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Axe_Level.Get_W_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Axe_Level.Get_W_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Axe_Level.Get_W_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 7:
            //    Name_text.text = Player_main.player_main.Skill.LongBlunt_Level.Get_W_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.LongBlunt_Level.Get_W_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.LongBlunt_Level.Get_W_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.LongBlunt_Level.Get_W_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 8:
            //    Name_text.text = Player_main.player_main.Skill.ShortBlunt_Level.Get_W_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.ShortBlunt_Level.Get_W_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.ShortBlunt_Level.Get_W_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.ShortBlunt_Level.Get_W_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 9:
            //    Name_text.text = Player_main.player_main.Skill.LongBlade_Level.Get_W_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.LongBlade_Level.Get_W_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.LongBlade_Level.Get_W_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.LongBlade_Level.Get_W_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 10:
            //    Name_text.text = Player_main.player_main.Skill.ShortBlade_Level.Get_W_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.ShortBlade_Level.Get_W_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.ShortBlade_Level.Get_W_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.ShortBlade_Level.Get_W_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 11:
            //    Name_text.text = Player_main.player_main.Skill.Spear_Level.Get_W_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Spear_Level.Get_W_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Spear_Level.Get_W_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Spear_Level.Get_W_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 12:
            //    Name_text.text = Player_main.player_main.Skill.Maintenance_Level.Get_M_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Maintenance_Level.Get_M_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Maintenance_Level.Get_M_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Maintenance_Level.Get_M_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 13:
            //    Name_text.text = Player_main.player_main.Skill.Aiming_Level.Get_Gun_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Aiming_Level.Get_Gun_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Aiming_Level.Get_Gun_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Aiming_Level.Get_Gun_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 14:
            //    Name_text.text = Player_main.player_main.Skill.Reloading_Level.Get_Gun_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Reloading_Level.Get_Gun_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Reloading_Level.Get_Gun_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Reloading_Level.Get_Gun_TotalEXP();

            //    if (Multiplier.activeSelf)
            //    {
            //        Multiplier_text.text = "";
            //        Multiplier.SetActive(false);
            //    }
            //    break;
            //case 15:
            //    Name_text.text = Player_main.player_main.Skill.Hunting_Level.Get_S_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Hunting_Level.Get_S_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Hunting_Level.Get_S_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Hunting_Level.Get_S_TotalEXP();
            //    if (Player_main.player_main.Skill.Hunting_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Hunting_Level.Get_S_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 16:
            //    Name_text.text = Player_main.player_main.Skill.Fishing_Level.Get_S_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Fishing_Level.Get_S_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Fishing_Level.Get_S_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Fishing_Level.Get_S_TotalEXP();
            //    if (Player_main.player_main.Skill.Fishing_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Fishing_Level.Get_S_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 17:
            //    Name_text.text = Player_main.player_main.Skill.Foraging_Level.Get_S_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Foraging_Level.Get_S_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Foraging_Level.Get_S_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Foraging_Level.Get_S_TotalEXP();
            //    if (Player_main.player_main.Skill.Foraging_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Foraging_Level.Get_S_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 18:
            //    Name_text.text = Player_main.player_main.Skill.Riding_Level.Get_S_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Riding_Level.Get_S_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Riding_Level.Get_S_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Riding_Level.Get_S_TotalEXP();
            //    if (Player_main.player_main.Skill.Riding_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Riding_Level.Get_S_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 19:
            //    Name_text.text = Player_main.player_main.Skill.Carpentry_Level.Get_C_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Carpentry_Level.Get_C_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Carpentry_Level.Get_C_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Carpentry_Level.Get_C_TotalEXP();
            //    if (Player_main.player_main.Skill.Carpentry_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Carpentry_Level.Get_C_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 20:
            //    Name_text.text = Player_main.player_main.Skill.Cooking_Level.Get_C_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Cooking_Level.Get_C_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Cooking_Level.Get_C_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Cooking_Level.Get_C_TotalEXP();
            //    if (Player_main.player_main.Skill.Cooking_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Cooking_Level.Get_C_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 21:
            //    Name_text.text = Player_main.player_main.Skill.Farming_Level.Get_C_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Farming_Level.Get_C_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Farming_Level.Get_C_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Farming_Level.Get_C_TotalEXP();
            //    if (Player_main.player_main.Skill.Farming_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Farming_Level.Get_C_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 22:
            //    Name_text.text = Player_main.player_main.Skill.FirstAid_Level.Get_C_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.FirstAid_Level.Get_C_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.FirstAid_Level.Get_C_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.FirstAid_Level.Get_C_TotalEXP();
            //    if (Player_main.player_main.Skill.FirstAid_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.FirstAid_Level.Get_C_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            //case 23:
            //    Name_text.text = Player_main.player_main.Skill.Electrical_Level.Get_C_SkillName();
            //    Level_text.text = Player_main.player_main.Skill.Electrical_Level.Get_C_Level().ToString();
            //    Exp_text.text = Player_main.player_main.Skill.Electrical_Level.Get_C_CurrentEXP() + " / " +
            //        Player_main.player_main.Skill.Electrical_Level.Get_C_TotalEXP();
            //    if (Player_main.player_main.Skill.Electrical_Level.Change_Multiplier)
            //    {
            //        Multiplier.SetActive(true);
            //        Multiplier_text.text = "( x " + Player_main.player_main.Skill.Electrical_Level.Get_C_Multiplier() + " 적용중 )";
            //    }
            //    else
            //    {
            //        Multiplier.SetActive(false);
            //        Multiplier_text.text = "";
            //    }
            //    break;
            default: break;
        }


        //UI_State_Skill_Slider.skill_slider.Set_SkillBar_slider(num);
    }

}
