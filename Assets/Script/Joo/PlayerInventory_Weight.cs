using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory_Weight
{
    public static PlayerInventory_Weight playerInventory_Weight;

    float MinWeight = 0.0f;
    float Basic_MaxWeight = 6.0f;
    float Moodles_point = 0.0f;
    float Bag_point = 0.0f;
    float Skill_point = 0.0f;
    public float Total_MaxWeight = 0.0f;

    public void Awake()
    {
        playerInventory_Weight = this;
        Total_MaxWeight = Basic_MaxWeight + Moodles_point + Skill_point + Bag_point;
    }

    public void Set_Add_Moodles_Point(Moodles_private_code Moodles_name, int Moodles_step)
    {
        switch (Moodles_name)
        {
            case Moodles_private_code.Hungry: break;
            case Moodles_private_code.Stuffed: break;
            case Moodles_private_code.Thirsty: break;
            case Moodles_private_code.Panic: break;
            case Moodles_private_code.Bored: break;
            case Moodles_private_code.Stressed: break;
            case Moodles_private_code.Unhappy: break;
            case Moodles_private_code.Drunk: break;
            case Moodles_private_code.Heavy_Load: break;
            case Moodles_private_code.Endurance: break;
            case Moodles_private_code.Tired: break;
            case Moodles_private_code.Hyperthermia_Hot: break;
            case Moodles_private_code.Hyperthermia_Cold: break;
            case Moodles_private_code.Windchill: break;
            case Moodles_private_code.Wet: break;
            case Moodles_private_code.Injured:
                float Set_point_for_Injured = 0f;
                switch (Moodles_step)
                {
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
                Moodles_point = Moodles_point + Set_point_for_Injured;
                break;
            case Moodles_private_code.Pain: break;
            case Moodles_private_code.Bleeding:
                float Set_point_for_Bleeding = 0f;
                switch (Moodles_step)
                {
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
                Moodles_point = Moodles_point + Set_point_for_Bleeding;
                break;
            case Moodles_private_code.Has_a_Cold: break;
            case Moodles_private_code.Sick: break;
            case Moodles_private_code.Restricted_Movement: break;
        }

    }

    public void Set_Add_Skill_point(float Set_point)
    {
        Skill_point += Set_point;
    }

    public void Set_Add_Bag_point(float Set_point)
    {
        Bag_point += Set_point;
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
