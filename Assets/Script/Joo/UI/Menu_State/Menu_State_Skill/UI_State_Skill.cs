using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_State_Skill : MonoBehaviour
{
    public static UI_State_Skill state_skill_info;

    public UnityEngine.UI.Text Name_text;
    public UnityEngine.UI.Text Level_text;
    public UnityEngine.UI.Text Exp_text;
    public GameObject[] Multiplier_icon;
    public UI_State_Skill_anim[] Multiplier_icon_anim;

    public void Start()
    {
        state_skill_info = this;
    }

    public void Open_Multiplier_icon(int index)
    {
        Multiplier_icon[index].SetActive(true);
    }

    public void Close_Multiplier_icon(int index)
    {
        Multiplier_icon[index].SetActive(false);
    }

    public void Set_anim(int index, int step)
    {
        Multiplier_icon_anim[index].OnSpeed(step);
    }

    public void Set_InfoWindow(int num)
    {
        switch(num)
        {
            case 0:
                Name_text.text = Player_main.player_main.Skill.Fitness_Level.Get_P_SkillName();
                Level_text.text = Player_main.player_main.Skill.Fitness_Level.Get_P_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Fitness_Level.Get_P_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Fitness_Level.Get_P_TotalEXP();
                break;
            case 1:
                Name_text.text = Player_main.player_main.Skill.Strength_Level.Get_P_SkillName();
                Level_text.text = Player_main.player_main.Skill.Strength_Level.Get_P_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Strength_Level.Get_P_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Strength_Level.Get_P_TotalEXP();
                break;
            case 2:
                Name_text.text = Player_main.player_main.Skill.Sprinting_Level.Get_G_SkillName();
                Level_text.text = Player_main.player_main.Skill.Sprinting_Level.Get_G_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Sprinting_Level.Get_G_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Sprinting_Level.Get_G_TotalEXP();
                break;
            case 3:
                Name_text.text = Player_main.player_main.Skill.Lightfooted_Level.Get_G_SkillName();
                Level_text.text = Player_main.player_main.Skill.Lightfooted_Level.Get_G_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Lightfooted_Level.Get_G_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Lightfooted_Level.Get_G_TotalEXP();
                break;
            case 4:
                Name_text.text = Player_main.player_main.Skill.Nimble_Level.Get_G_SkillName();
                Level_text.text = Player_main.player_main.Skill.Nimble_Level.Get_G_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Nimble_Level.Get_G_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Nimble_Level.Get_G_TotalEXP();
                break;
            case 5:
                Name_text.text = Player_main.player_main.Skill.Sneaking_Level.Get_G_SkillName();
                Level_text.text = Player_main.player_main.Skill.Sneaking_Level.Get_G_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Sneaking_Level.Get_G_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Sneaking_Level.Get_G_TotalEXP();
                break;
            case 6:
                Name_text.text = Player_main.player_main.Skill.Axe_Level.Get_W_SkillName();
                Level_text.text = Player_main.player_main.Skill.Axe_Level.Get_W_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Axe_Level.Get_W_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Axe_Level.Get_W_TotalEXP();
                break;
            case 7:
                Name_text.text = Player_main.player_main.Skill.LongBlunt_Level.Get_W_SkillName();
                Level_text.text = Player_main.player_main.Skill.LongBlunt_Level.Get_W_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.LongBlunt_Level.Get_W_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.LongBlunt_Level.Get_W_TotalEXP();
                break;
            case 8:
                Name_text.text = Player_main.player_main.Skill.ShortBlunt_Level.Get_W_SkillName();
                Level_text.text = Player_main.player_main.Skill.ShortBlunt_Level.Get_W_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.ShortBlunt_Level.Get_W_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.ShortBlunt_Level.Get_W_TotalEXP();
                break;
            case 9:
                Name_text.text = Player_main.player_main.Skill.LongBlade_Level.Get_W_SkillName();
                Level_text.text = Player_main.player_main.Skill.LongBlade_Level.Get_W_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.LongBlade_Level.Get_W_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.LongBlade_Level.Get_W_TotalEXP();
                break;
            case 10:
                Name_text.text = Player_main.player_main.Skill.ShortBlade_Level.Get_W_SkillName();
                Level_text.text = Player_main.player_main.Skill.ShortBlade_Level.Get_W_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.ShortBlade_Level.Get_W_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.ShortBlade_Level.Get_W_TotalEXP();
                break;
            case 11:
                Name_text.text = Player_main.player_main.Skill.Spear_Level.Get_W_SkillName();
                Level_text.text = Player_main.player_main.Skill.Spear_Level.Get_W_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Spear_Level.Get_W_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Spear_Level.Get_W_TotalEXP();
                break;
            case 12:
                Name_text.text = Player_main.player_main.Skill.Maintenance_Level.Get_M_SkillName();
                Level_text.text = Player_main.player_main.Skill.Maintenance_Level.Get_M_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Maintenance_Level.Get_M_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Maintenance_Level.Get_M_TotalEXP();
                break;
            case 13:
                Name_text.text = Player_main.player_main.Skill.Aiming_Level.Get_Gun_SkillName();
                Level_text.text = Player_main.player_main.Skill.Aiming_Level.Get_Gun_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Aiming_Level.Get_Gun_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Aiming_Level.Get_Gun_TotalEXP();
                break;
            case 14:
                Name_text.text = Player_main.player_main.Skill.Reloading_Level.Get_Gun_SkillName();
                Level_text.text = Player_main.player_main.Skill.Reloading_Level.Get_Gun_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Reloading_Level.Get_Gun_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Reloading_Level.Get_Gun_TotalEXP();
                break;
            case 16:
                Name_text.text = Player_main.player_main.Skill.Hunting_Level.Get_S_SkillName();
                Level_text.text = Player_main.player_main.Skill.Hunting_Level.Get_S_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Hunting_Level.Get_S_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Hunting_Level.Get_S_TotalEXP();
                break;
            case 15:
                Name_text.text = Player_main.player_main.Skill.Fishing_Level.Get_S_SkillName();
                Level_text.text = Player_main.player_main.Skill.Fishing_Level.Get_S_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Fishing_Level.Get_S_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Fishing_Level.Get_S_TotalEXP();
                break;
            case 17:
                Name_text.text = Player_main.player_main.Skill.Foraging_Level.Get_S_SkillName();
                Level_text.text = Player_main.player_main.Skill.Foraging_Level.Get_S_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Foraging_Level.Get_S_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Foraging_Level.Get_S_TotalEXP();
                break;
            case 18:
                Name_text.text = Player_main.player_main.Skill.Riding_Level.Get_S_SkillName();
                Level_text.text = Player_main.player_main.Skill.Riding_Level.Get_S_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Riding_Level.Get_S_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Riding_Level.Get_S_TotalEXP();
                break;
            case 19:
                Name_text.text = Player_main.player_main.Skill.Carpentry_Level.Get_C_SkillName();
                Level_text.text = Player_main.player_main.Skill.Carpentry_Level.Get_C_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Carpentry_Level.Get_C_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Carpentry_Level.Get_C_TotalEXP();
                break;
            case 20:
                Name_text.text = Player_main.player_main.Skill.Cooking_Level.Get_C_SkillName();
                Level_text.text = Player_main.player_main.Skill.Cooking_Level.Get_C_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Cooking_Level.Get_C_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Cooking_Level.Get_C_TotalEXP();
                break;
            case 21:
                Name_text.text = Player_main.player_main.Skill.Farming_Level.Get_C_SkillName();
                Level_text.text = Player_main.player_main.Skill.Farming_Level.Get_C_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Farming_Level.Get_C_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Farming_Level.Get_C_TotalEXP();
                break;
            case 22:
                Name_text.text = Player_main.player_main.Skill.FirstAid_Level.Get_C_SkillName();
                Level_text.text = Player_main.player_main.Skill.FirstAid_Level.Get_C_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.FirstAid_Level.Get_C_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.FirstAid_Level.Get_C_TotalEXP();
                break;
            case 23:
                Name_text.text = Player_main.player_main.Skill.Electrical_Level.Get_C_SkillName();
                Level_text.text = Player_main.player_main.Skill.Electrical_Level.Get_C_Level().ToString();
                Exp_text.text = Player_main.player_main.Skill.Electrical_Level.Get_C_CurrentEXP() + " / " +
                    Player_main.player_main.Skill.Electrical_Level.Get_C_TotalEXP();
                break;
            default: break;
        }
    }
}
