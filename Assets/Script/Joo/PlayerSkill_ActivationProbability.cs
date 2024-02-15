using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_ActivationProbability
{
    public static PlayerSkill_ActivationProbability playerSkill_ActivationProbability;

    // 피로도 생성 비율 ( * )  // Fitness
    float Fatigue_Generation_Rate = 1.00f;
    public float Get_Fatigue_Generation_Rate() { return Fatigue_Generation_Rate; }

    public void Set_Fatigue_Generation_Rate_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Fatigue_Generation_Rate = 1.00f;
                break;
            case 1:
                Fatigue_Generation_Rate = 0.95f;
                break;
            case 2:
                Fatigue_Generation_Rate = 0.92f;
                break;
            case 3:
                Fatigue_Generation_Rate = 0.89f;
                break;
            case 4:
                Fatigue_Generation_Rate = 0.87f;
                break;
            case 5:
                Fatigue_Generation_Rate = 0.85f;
                break;
            case 6:
                Fatigue_Generation_Rate = 0.83f;
                break;
            case 7:
                Fatigue_Generation_Rate = 0.81f;
                break;
            case 8:
                Fatigue_Generation_Rate = 0.79f;
                break;
            case 9:
                Fatigue_Generation_Rate = 0.77f;
                break;
            case 10:
                Fatigue_Generation_Rate = 0.75f;
                break;
            default:
                break;
        }
    }

    // 지구력 회복 비율 ( * )  // Fitness
    float Endurance_Recovery_Rate = 0.7f;
    public float Get_Endurance_Recovery_Rate() { return Endurance_Recovery_Rate; }

    public void Set_Endurance_Recovery_Rate_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Endurance_Recovery_Rate = 0.7f;
                break;
            case 1:
                Endurance_Recovery_Rate = 0.8f;
                break;
            case 2:
                Endurance_Recovery_Rate = 0.9f;
                break;
            case 3:
                Endurance_Recovery_Rate = 1.0f;
                break;
            case 4:
                Endurance_Recovery_Rate = 1.1f;
                break;
            case 5:
                Endurance_Recovery_Rate = 1.2f;
                break;
            case 6:
                Endurance_Recovery_Rate = 1.3f;
                break;
            case 7:
                Endurance_Recovery_Rate = 1.4f;
                break;
            case 8:
                Endurance_Recovery_Rate = 1.5f;
                break;
            case 9:
                Endurance_Recovery_Rate = 1.55f;
                break;
            case 10:
                Endurance_Recovery_Rate = 1.6f;
                break;
            default:
                break;
        }
    }

    // 지구력 소모 비율 ( * )  // Fitness
    float Endurance_Depletion_Rate = 0.9f;
    public float Get_Endurance_Depletion_Rate() { return Endurance_Depletion_Rate; }

    public void Set_Endurance_Depletion_Rate_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Endurance_Depletion_Rate = 0.9f;
                break;
            case 1:
                Endurance_Depletion_Rate = 0.8f;
                break;
            case 2:
                Endurance_Depletion_Rate = 0.75f;
                break;
            case 3:
                Endurance_Depletion_Rate = 0.7f;
                break;
            case 4:
                Endurance_Depletion_Rate = 0.65f;
                break;
            case 5:
                Endurance_Depletion_Rate = 0.6f;
                break;
            case 6:
                Endurance_Depletion_Rate = 0.57f;
                break;
            case 7:
                Endurance_Depletion_Rate = 0.53f;
                break;
            case 8:
                Endurance_Depletion_Rate = 0.49f;
                break;
            case 9:
                Endurance_Depletion_Rate = 0.368f;
                break;
            case 10:
                Endurance_Depletion_Rate = 0.344f;
                break;
            default:
                break;
        }
    }

    // 공격력 증가 ( * )  // Axe 등 무기
    float Increase_in_Attack_Power = 0.3f;
    public float Get_Increase_in_Attack_Power() { return  Increase_in_Attack_Power; }

    public void Set_Increase_in_Attack_Power_forSkill(string SkillName, float SkillLevel)
    {
        if(SkillName == "Axe")
        {
            Increase_in_Attack_Power = 0.3f + 0.1f * SkillLevel;
        }
        else if (SkillName == "LongBlunt" || SkillName == "ShortBlunt" || SkillName == "LongBlade"
            || SkillName == "ShortBlade" || SkillName == "Spear")
        {
            Increase_in_Attack_Power = 0.3f + 0.1f * (SkillLevel - 1);
        }
    }


    // 공격 속도 ( + )  // Fitness // Axe 등 무기
    float Attack_Speed = 0f;
    public float Get_Attack_Speed() { return Attack_Speed; }

    public void Set_Attack_Speed_forSkill(string SkillName, float SkillLevel)
    {
        if(SkillName == "Fitness")
        {
            if (Attack_Speed == 0f)
            {
                Attack_Speed = 0.02f * SkillLevel;
            }
            else
            {
                Attack_Speed += 0.02f;
            }
        }
        else if(SkillName == "Axe")
        {
            if (Attack_Speed == 0f)
            {
                Attack_Speed = 0.03f * SkillLevel;
            }
            else
            {
                Attack_Speed += 0.03f;
            }
        }
        else if (SkillName == "LongBlunt" || SkillName == "ShortBlunt" || SkillName == "LongBlade" 
            || SkillName == "ShortBlade" || SkillName == "Spear")
        {
            if (Attack_Speed == 0f)
            {
                Attack_Speed = 0.03f * (SkillLevel - 1);
            }
            else
            {
                Attack_Speed += 0.03f;
            }
        }
    }

    // 넘어질 확률 ( - )  // Fitness
    float Probability_of_Falling = 0f;
    public float Get_Probability_of_Falling() { return Probability_of_Falling; }

    public void Set_Probability_of_Falling_forSkill(float SkillLevel)
    {
        if (Probability_of_Falling == 0f)
        {
            Probability_of_Falling = 0.02f * SkillLevel;
        }
        else
        {
            Probability_of_Falling += 0.02f;
        }
    }

    // 높은 담을 넘을 확률 ( + )  // Fitness, Strength
    float Probability_of_Crossing_a_High_Wall = 0f;
    public float Get_Probability_of_Crossing_a_High_Wall() { return Probability_of_Crossing_a_High_Wall; }

    public void Set_Probability_of_Crossing_a_High_Wall_forSkill(float SkillLevel)
    {
        if (Probability_of_Crossing_a_High_Wall == 0f)
        {
            Probability_of_Crossing_a_High_Wall = 0.02f * SkillLevel;
        }
        else
        {
            Probability_of_Crossing_a_High_Wall += 0.02f;
        }
    }

    // 근접 공격력 비율 ( * )  // Strength
    float Melee_Attack_Power_Ratio = 0.75f;
    public float Get_Melee_Attack_Power_Ratio() { return Melee_Attack_Power_Ratio; }

    public void Set_Melee_Attack_Power_Ratio_forSkill(float SkillLevel)
    {
        Melee_Attack_Power_Ratio = 0.75f + 0.05f * SkillLevel;
    }

    // 치명타 확률 ( + )  // Axe 등 무기
    float Critical_Hit_Chance = 0.0f;
    public float Get_Critical_Hit_Chance() { return Critical_Hit_Chance; }

    public void Set_Critical_Hit_Chance_forSkill(string SkillName, float SkillLevel)
    {
        if (SkillName == "Axe")
        {
            if (Critical_Hit_Chance == 0f)
            {
                Critical_Hit_Chance = 0.03f * SkillLevel;
            }
            else
            {
                Critical_Hit_Chance += 0.03f;
            }
        }
        else if (SkillName == "LongBlunt" || SkillName == "ShortBlunt" || SkillName == "LongBlade"
            || SkillName == "ShortBlade" || SkillName == "Spear")
        {
            if (Critical_Hit_Chance == 0f)
            {
                Critical_Hit_Chance = 0.03f * (SkillLevel - 1);
            }
            else
            {
                Critical_Hit_Chance += 0.03f;
            }
        }
    }


    // 밀쳐낼 확률 ( * )   // Strength
    float HitForce = 0.45f;
    public float Get_HitForce() { return HitForce; }

    public void Set_HitForce_forSkill(float SkillLevel)
    {
        float player_Endurance = 1.0f;
        if(Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodles_state() < 0.5)  // 지구력에 따른 밀쳐낼 확률 감소
        {
            player_Endurance = 0.4f;
        }
        else if(Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodles_state() >= 0.5 && Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodles_state() < 0.7)
        {
            player_Endurance = 0.7f;
        }
        else
        {
            player_Endurance = 1;
        }

        switch (SkillLevel)  // 밀쳐낼 확률 * 스태미나 * 근력
        {
            case 0:
                HitForce = 0.45f * player_Endurance * 0.75f;  
                break;
            case 1:
                HitForce = 0.48f * player_Endurance * 0.8f;
                break;
            case 2:
                HitForce = 0.85f * player_Endurance * 0.85f;
                break;
            case 3:
                HitForce = 0.90f * player_Endurance * 0.9f;
                break;
            case 4:
                HitForce = 0.95f * player_Endurance * 0.95f;
                break;
            case 5:
                HitForce = 1.0f * player_Endurance * 1.0f;
                break;
            case 6:
                HitForce = 1.05f * player_Endurance * 1.05f;
                break;
            case 7:
                HitForce = 1.1f * player_Endurance * 1.1f;
                break;
            case 8:
                HitForce = 1.15f * player_Endurance * 1.15f;
                break;
            case 9:
                HitForce = 1.68f * player_Endurance * 1.2f;
                break;
            case 10:
                HitForce = 1.75f * player_Endurance * 1.25f;
                break;
            default:
                break;
        }
    }

    // 막기 확률 ( + )  // Fitness, Strength // Axe 등 무기     // 좀비가 플레이어 공격 시 그 공격을 막을 확률
    float Block_chance = 0.0f;
    public float Get_Block_chance() { return Block_chance; }

    public void Set_Block_chance_forSkill(string SkillName, float SkillLevel) // 근력, 체력 레벨에 따른 방어 확률
    {
        if (SkillName == "Fitness" || SkillName == "Strength")
        {
            if (Block_chance == 0f)
            {
                Block_chance = 0.02f * SkillLevel;
            }
            else
            {
                Block_chance += 0.02f;
            }
        }
        else if (SkillName == "Axe")
        {
            if (Block_chance == 0f)
            {
                Block_chance = 0.03f * SkillLevel;
            }
            else
            {
                Block_chance += 0.03f;
            }
        }
        else if (SkillName == "LongBlunt" || SkillName == "ShortBlunt" || SkillName == "LongBlade"
            || SkillName == "ShortBlade" || SkillName == "Spear")
        {
            if (Block_chance == 0f)
            {
                Block_chance = 0.03f * (SkillLevel - 1);
            }
            else
            {
                Block_chance += 0.03f;
            }
        }
    }

    // 회피할 확률 ( + )  // Axe 등 무기     // 좀비가 플레이어 공격 시 그 공격이 성공한 후 회피할 확률
    float Injury_chance = -0.05f;
    public float Get_Injury_chance() { return Injury_chance; }

    public void Set_Injury_chance_forSkill(string SkillName, float SkillLevel)
    {
        if (SkillName == "Axe")
        { 
            if (SkillLevel == 0)
                Injury_chance = -0.05f;
            else if(SkillLevel == 1)
                Injury_chance = -0.02f;
            else if(SkillLevel >= 2 && SkillLevel < 8)
                Injury_chance = 0.01f * (SkillLevel - 2);
            else if (SkillLevel >= 8)
                Injury_chance = 0.01f * (SkillLevel - 3);
        }
        else if (SkillName == "LongBlunt" || SkillName == "ShortBlunt" || SkillName == "LongBlade"
            || SkillName == "ShortBlade" || SkillName == "Spear")
        {
            if (SkillLevel <= 1)
                Injury_chance = -0.05f;
            else if (SkillLevel == 2)
                Injury_chance = -0.02f;
            else if (SkillLevel >= 3 && SkillLevel < 9)
                Injury_chance = 0.01f * (SkillLevel - 3);
            else if (SkillLevel >= 9)
                Injury_chance = 0.01f * (SkillLevel - 4);
        }
    }
    

    // 달리기 속도 ( * )  // Sprinting
    float Running_Speed = 1.0f;
    public float Get_Running_Speed() { return Running_Speed; }

    public void Set_Running_Speed_forSkill(float SkillLevel)
    {
        Running_Speed = 1.0f + 0.05f * SkillLevel;
    }

    // 발소리 반경 ( * )  // Lightfooted
    float Footstep_Radius = 0.99f;
    public float Get_Footstep_Radius() {  return Footstep_Radius; }

    public void Set_Footstep_Radius_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Footstep_Radius = 0.99f;
                break;
            case 1:
                Footstep_Radius = 0.90f;
                break;
            case 2:
                Footstep_Radius = 0.79f;
                break;
            case 3:
                Footstep_Radius = 0.71f;
                break;
            case 4:
                Footstep_Radius = 0.65f;
                break;
            case 5:
                Footstep_Radius = 0.59f;
                break;
            case 6:
                Footstep_Radius = 0.52f;
                break;
            case 7:
                Footstep_Radius = 0.45f;
                break;
            case 8:
                Footstep_Radius = 0.37f;
                break;
            case 9:
                Footstep_Radius = 0.30f;
                break;
            case 10:
                Footstep_Radius = 0.20f;
                break;
            default:
                break;
        }
    }

    // 조준시 이동속도 ( * )  // Nimble
    float Movement_Speed_while_Aiming = 1.00f;
    public float Get_Movement_Speed_while_Aiming() { return Movement_Speed_while_Aiming; }

    public void Set_Movement_Speed_while_Aiming_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Movement_Speed_while_Aiming = 1.00f;
                break;
            case 1:
                Movement_Speed_while_Aiming = 1.10f;
                break;
            case 2:
                Movement_Speed_while_Aiming = 1.14f;
                break;
            case 3:
                Movement_Speed_while_Aiming = 1.18f;
                break;
            case 4:
                Movement_Speed_while_Aiming = 1.22f;
                break;
            case 5:
                Movement_Speed_while_Aiming = 1.26f;
                break;
            case 6:
                Movement_Speed_while_Aiming = 1.30f;
                break;
            case 7:
                Movement_Speed_while_Aiming = 1.34f;
                break;
            case 8:
                Movement_Speed_while_Aiming = 1.38f;
                break;
            case 9:
                Movement_Speed_while_Aiming = 1.42f;
                break;
            case 10:
                Movement_Speed_while_Aiming = 1.50f;
                break;
            default:
                break;
        }
    }

    // 조준시 발소리 반경 ( * )  // Nimble
    float Footstep_Radius_while_Aiming = 1.00f;
    public float Get_Footstep_Radius_while_Aiming() { return Footstep_Radius_while_Aiming; }

    public void Set_Footstep_Radius_while_Aiming_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Footstep_Radius_while_Aiming = 1.00f;
                break;
            case 1:
                Footstep_Radius_while_Aiming = 0.90f;
                break;
            case 2:
                Footstep_Radius_while_Aiming = 0.86f;
                break;
            case 3:
                Footstep_Radius_while_Aiming = 0.82f;
                break;
            case 4:
                Footstep_Radius_while_Aiming = 0.78f;
                break;
            case 5:
                Footstep_Radius_while_Aiming = 0.74f;
                break;
            case 6:
                Footstep_Radius_while_Aiming = 0.70f;
                break;
            case 7:
                Footstep_Radius_while_Aiming = 0.66f;
                break;
            case 8:
                Footstep_Radius_while_Aiming = 0.62f;
                break;
            case 9:
                Footstep_Radius_while_Aiming = 0.58f;
                break;
            case 10:
                Footstep_Radius_while_Aiming = 0.50f;
                break;
            default:
                break;
        }
    }

    // 은신 중 발소리 반경 ( * )  // Sneaking
    float Footstep_Radius_while_Sneaking = 0.24f;
    public float Get_Footstep_Radius_while_Sneaking() { return Footstep_Radius_while_Sneaking; }

    public void Set_Footstep_Radius_while_Sneaking_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Footstep_Radius_while_Sneaking = 0.24f;
                break;
            case 1:
                Footstep_Radius_while_Sneaking = 0.18f;
                break;
            case 2:
                Footstep_Radius_while_Sneaking = 0.16f;
                break;
            case 3:
                Footstep_Radius_while_Sneaking = 0.15f;
                break;
            case 4:
                Footstep_Radius_while_Sneaking = 0.14f;
                break;
            case 5:
                Footstep_Radius_while_Sneaking = 0.13f;
                break;
            case 6:
                Footstep_Radius_while_Sneaking = 0.12f;
                break;
            case 7:
                Footstep_Radius_while_Sneaking = 0.11f;
                break;
            case 8:
                Footstep_Radius_while_Sneaking = 0.10f;
                break;
            case 9:
                Footstep_Radius_while_Sneaking = 0.09f;
                break;
            case 10:
                Footstep_Radius_while_Sneaking = 0.08f;
                break;
            default:
                break;
        }
    }

    // 은신 중 좀비에게 발각될 확률 ( * )  // Sneaking
    float Probability_of_Detection_by_Zombies_while_Sneaking = 0.456f;
    public float Get_Probability_of_Detection_by_Zombies_while_Sneaking() { return Probability_of_Detection_by_Zombies_while_Sneaking; }

    public void Set_Probability_of_Detection_by_Zombies_while_Sneaking_forSkill(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.456f;
                break;
            case 1:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.4432f;
                break;
            case 2:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.384f;
                break;
            case 3:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.36f;
                break;
            case 4:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.336f;
                break;
            case 5:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.312f;
                break;
            case 6:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.288f;
                break;
            case 7:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.264f;
                break;
            case 8:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.24f;
                break;
            case 9:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.216f;
                break;
            case 10:
                Probability_of_Detection_by_Zombies_while_Sneaking = 0.192f;
                break;
            default:
                break;
        }
    }
}

