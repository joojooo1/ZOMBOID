using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory_Weight
{
    public static PlayerInventory_Weight playerInventory_Weight;

    float MinWeight = 0.0f;
    float Basic_MaxWeight = 6.0f;
    float Moodles_point = 0.0f;
    float Main_Bag_point = 0.0f;
    float Sub_Bag_point = 0.0f;
    float Skill_point = 0.0f;
    public float Total_MaxWeight = 0.0f;
    float Current_Weight = 0.0f;

    public void Awake()
    {
        playerInventory_Weight = this;
        Total_MaxWeight = Basic_MaxWeight + Moodles_point + Skill_point + Main_Bag_point + Sub_Bag_point;
    }

    public void Update()
    {
        Total_MaxWeight = Basic_MaxWeight + Moodles_point + Skill_point + Main_Bag_point + Sub_Bag_point;
        Player_main.player_main.playerMoodles.Moodle_Heavy_Load.Set_Moodles_state(Current_Weight / Total_MaxWeight);


    }

    float Set_point_for_Hungry = 0f;
    float Set_point_for_Stuffed = 0f;
    float Set_point_for_Injured = 0f;
    float Set_point_for_Bleeding = 0f;
    public void Set_Add_Moodles_Point(Moodles_private_code Moodles_name, int Moodles_step)
    {
        switch (Moodles_name)
        {
            case Moodles_private_code.Hungry:
                switch (Moodles_step)
                {
                    case 0: 
                    case 1:
                        break;
                    case 2:
                        Set_point_for_Hungry = -1;
                        break;
                    case 3:
                        Set_point_for_Hungry = -2;
                        break;
                    case 4:
                        Set_point_for_Hungry = -2;
                        break;
                }
                break;
            case Moodles_private_code.Stuffed:
                switch (Moodles_step)
                {
                    case 0:
                    case 1:
                        Set_point_for_Stuffed = +2;
                        break;
                    case 2:
                        Set_point_for_Stuffed = +2;
                        break;
                    case 3:
                        Set_point_for_Stuffed = +2;
                        break;
                    case 4:
                        Set_point_for_Stuffed = +2;
                        break;
                }
                break;
            case Moodles_private_code.Thirsty: break;
            case Moodles_private_code.Panic: break;
            case Moodles_private_code.Bored: break;
            case Moodles_private_code.Stressed: break;
            case Moodles_private_code.Unhappy: break;
            case Moodles_private_code.Drunk: break;
            case Moodles_private_code.Heavy_Load: break;
            case Moodles_private_code.Tired: break;
            case Moodles_private_code.Hyperthermia_Hot: break;
            case Moodles_private_code.Hyperthermia_Cold: break;
            case Moodles_private_code.Windchill: break;
            case Moodles_private_code.Wet: break;
            case Moodles_private_code.Injured:
                switch (Moodles_step)
                {
                    case 0:
                    case 1:
                        break;
                    case 2:
                        Set_point_for_Injured = -1;
                        break;
                    case 3:
                        Set_point_for_Injured = -2;
                        break;
                    case 4:
                        Set_point_for_Injured = -3;
                        break;
                }
                break;
            case Moodles_private_code.Pain: break;
            case Moodles_private_code.Bleeding:
                switch (Moodles_step)
                {
                    case 0:
                    case 1:
                        break;
                    case 2:
                        Set_point_for_Bleeding = -1;
                        break;
                    case 3:
                        Set_point_for_Bleeding = -2;
                        break;
                    case 4:
                        Set_point_for_Bleeding = -2;
                        break;
                }
                break;
            case Moodles_private_code.Has_a_Cold: break;
            case Moodles_private_code.Sick: break;
            case Moodles_private_code.Restricted_Movement: break;
        }
        Moodles_point = Set_point_for_Hungry + Set_point_for_Stuffed + Set_point_for_Injured + Set_point_for_Bleeding;
    }

    public void Set_Add_Skill_point(float Set_point)
    {
        Skill_point += Set_point;
    }

    public void Set_Add_Main_Bag_point(float Set_point)
    {
        Main_Bag_point += Set_point;
    }

    public void Set_Add_Sub_Bag_point(float Set_point)
    {
        Sub_Bag_point += Set_point;
    }

    public float Get_MaxWeight()
    {
        return Total_MaxWeight;
    }

    // 소지 한도  // Strength
    public void Set_MaxWeight_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Basic_MaxWeight = 6.0f;
                break;
            case 1:
                Basic_MaxWeight = 7.0f;
                break;
            case 2:
                Basic_MaxWeight = 8.0f;
                break;
            case 3:
                Basic_MaxWeight = 9.0f;
                break;
            case 4:
                Basic_MaxWeight = 11.0f;
                break;
            case 5:
                Basic_MaxWeight = 12.0f;
                break;
            case 6:
                Basic_MaxWeight = 14.0f;
                break;
            case 7:
                Basic_MaxWeight = 15.0f;
                break;
            case 8:
                Basic_MaxWeight = 16.0f;
                break;
            case 9:
                Basic_MaxWeight = 18.0f;
                break;
            case 10:
                Basic_MaxWeight = 20.0f;
                break;
            default:
                break;
        }
    }


}
