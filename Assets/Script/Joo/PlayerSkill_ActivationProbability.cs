using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_ActivationProbability
{

    // �Ƿε� ���� ���� ( * )  // Fitness
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

    // ������ ȸ�� ���� ( * )  // Fitness
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

    // ������ �Ҹ� ���� ( * )  // Fitness
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

    // ���ݷ� ���� ( * )  // Axe �� ���� ���� up�� ����
    float Basic_Increase_in_Attack_Power = 0.3f;  // ���� ������ ��
    float Increase_in_Attack_Power = 0.0f;  // ���� ���� ��
    public float Get_Increase_in_Attack_Power() { return  Increase_in_Attack_Power; }

    public void Set_Increase_in_Attack_Power_forSkill(Weapon_type SkillName, float SkillLevel, bool IsEquipping)
    {
        float Axe_BonusState;
        float Others_BonusState;
        Increase_in_Attack_Power = Basic_Increase_in_Attack_Power;

        switch (SkillName)
        {
            case Weapon_type.Axe:
                Axe_BonusState = 0.1f * SkillLevel;
                if (IsEquipping)
                    Increase_in_Attack_Power = Basic_Increase_in_Attack_Power + Axe_BonusState;
                break;
            case Weapon_type.LongBlunt:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Increase_in_Attack_Power = Basic_Increase_in_Attack_Power + Others_BonusState;
                break;
            case Weapon_type.ShortBlunt:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Increase_in_Attack_Power = Basic_Increase_in_Attack_Power + Others_BonusState;
                break;
            case Weapon_type.LongBlade:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Increase_in_Attack_Power = Basic_Increase_in_Attack_Power + Others_BonusState;
                break;
            case Weapon_type.ShortBlade:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Increase_in_Attack_Power = Basic_Increase_in_Attack_Power + Others_BonusState;
                break;
            case Weapon_type.Spear:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Increase_in_Attack_Power = Basic_Increase_in_Attack_Power + Others_BonusState;
                break;
            case Weapon_type.Gun:

                break;
            default:
                break;
        }
    }

    // ���� ���ݷ� ���� ( * )  // Strength
    float Melee_Attack_Power_Ratio = 0.75f;
    float Melee_Attack_Power_Ratio_forMoodle = 1f;
    public float Get_Melee_Attack_Power_Ratio() { return Melee_Attack_Power_Ratio * Melee_Attack_Power_Ratio_forMoodle; }

    public void Set_Melee_Attack_Power_Ratio_forSkill(float SkillLevel)
    {
        Melee_Attack_Power_Ratio = (0.75f + 0.05f * SkillLevel);
    }

    public void Set_Melee_Attack_Power_Ratio_forMoodle(float value)
    {
        Melee_Attack_Power_Ratio_forMoodle = 1 - value;

    }


    // ���� �ӵ� ( + )  // Fitness // Axe �� ����  // Moodle_Heavy_Load
    float Basic_Attack_Speed = 0f;  // ���� ������ ��
    float Attack_Speed_for_Weapon = 0f;  // ���� ���� ��
    float Attack_Speed_for_Moodle = 1f;
    float Total_Attack_Speed = 0f;
    public float Get_Attack_Speed() { return Total_Attack_Speed * Attack_Speed_for_Moodle; }

    public void Set_Attack_Speed_forSkill(string SkillName, float SkillLevel, bool IsEquipping)
    {
        float Axe_BonusState;
        float Others_BonusState;
        Total_Attack_Speed = Basic_Attack_Speed * Attack_Speed_for_Moodle;

        if (SkillName == "Fitness")
        {
            Basic_Attack_Speed = 0.02f * SkillLevel;
            Total_Attack_Speed = Basic_Attack_Speed * Attack_Speed_for_Moodle;
        }
        else
        {
            if (SkillName == "Axe")
            {
                Axe_BonusState = 0.03f * SkillLevel;
                if (IsEquipping)
                    Total_Attack_Speed = (Basic_Attack_Speed + Axe_BonusState);
            }
            else if (SkillName == "LongBlunt")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Total_Attack_Speed = (Basic_Attack_Speed + Others_BonusState);
            }
            else if (SkillName == "ShortBlunt")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Total_Attack_Speed = (Basic_Attack_Speed + Others_BonusState);
            }
            else if (SkillName == "LongBlade")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Total_Attack_Speed = (Basic_Attack_Speed + Others_BonusState);
            }
            else if (SkillName == "ShortBlade")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Total_Attack_Speed = (Basic_Attack_Speed + Others_BonusState);
            }
            else if (SkillName == "Spear")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Total_Attack_Speed = (Basic_Attack_Speed + Others_BonusState);
            }
            else if (SkillName == "Maintenance")
            {

            }
            else if (SkillName == "Aiming" || SkillName == "Reloading")
            {

            }
        }
    }

    float Attack_Speed_for_Endurance = 1;
    float Attack_Speed_for_Heavy_Load = 1;

    public void Set_Attack_Speed_forMoodle(Moodles_private_code _Moodle_Code, float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Endurance:
                Attack_Speed_for_Endurance = 1 - value;
                break;
            case Moodles_private_code.Heavy_Load:
                Attack_Speed_for_Heavy_Load = 1 - value;
                break;
        }
        Attack_Speed_for_Moodle = Attack_Speed_for_Endurance + Attack_Speed_for_Heavy_Load;
    }


    // �Ѿ��� Ȯ�� ( - )  // Fitness  // Moodle_Heavy_Load, Moodle_Pain
    float Probability_of_Falling = 0f;
    float Probability_of_Falling_forSkill = 0f;
    float Probability_of_Falling_forMoodle = 0f;
    public float Get_Probability_of_Falling() { return Probability_of_Falling + Probability_of_Falling_forMoodle; }

    public void Set_Probability_of_Falling_forSkill(float SkillLevel)
    {
        if (Probability_of_Falling_forSkill == 0f)
        {
            Probability_of_Falling_forSkill = 0.02f * SkillLevel;
        }
        else
        {
            Probability_of_Falling_forSkill = Probability_of_Falling_forSkill + 0.02f;
        }
        Probability_of_Falling = Probability_of_Falling_forSkill;
    }

    float Probability_of_Falling_for_Endurance = 0;
    float Probability_of_Falling_for_Heavy_Load = 0;
    float Probability_of_Falling_for_Pain = 0;
    public void Set_Probability_of_Falling_forMoodle(Moodles_private_code _Moodle_Code, float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Endurance:
                Probability_of_Falling_for_Endurance = value;
                break;
            case Moodles_private_code.Heavy_Load:
                Probability_of_Falling_for_Heavy_Load = value;
                break;
            case Moodles_private_code.Pain:
                Probability_of_Falling_for_Pain = value;
                break;

        }
        Probability_of_Falling_forMoodle = Probability_of_Falling_for_Endurance + Probability_of_Falling_for_Heavy_Load + Probability_of_Falling_for_Pain;
    }

    // ���� ���� ���� Ȯ�� ( + )  // Fitness, Strength  // Moodle_Heavy_Load
    float Probability_of_Crossing_a_High_Wall = 0.5f;
    float Probability_of_Crossing_a_High_Wall_forSkill = 0f;
    float Probability_of_Crossing_a_High_Wall_forMoodle = 0f;
    public float Get_Probability_of_Crossing_a_High_Wall() { return Probability_of_Crossing_a_High_Wall + Probability_of_Crossing_a_High_Wall_forSkill - Probability_of_Crossing_a_High_Wall_forMoodle; }

    public void Set_Probability_of_Crossing_a_High_Wall_forSkill(float SkillLevel)
    {
        if (Probability_of_Crossing_a_High_Wall_forSkill == 0f)
        {
            Probability_of_Crossing_a_High_Wall_forSkill = 0.02f * SkillLevel;
        }
        else
        {
            Probability_of_Crossing_a_High_Wall_forSkill += 0.02f;
        }
        
    }

    float Probability_of_Crossing_a_High_Wall_for_Endurance = 0;
    float Probability_of_Crossing_a_High_Wall_for_Heavy_Load = 0;
    public void Set_Probability_of_Crossing_a_High_Wall_forMoodle(Moodles_private_code _Moodle_Code, float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Endurance:
                Probability_of_Crossing_a_High_Wall_for_Endurance = value;
                break;
            case Moodles_private_code.Heavy_Load:
                Probability_of_Crossing_a_High_Wall_for_Heavy_Load = value;
                break;
        }
        Probability_of_Crossing_a_High_Wall_forMoodle = Probability_of_Crossing_a_High_Wall_for_Endurance + Probability_of_Crossing_a_High_Wall_for_Heavy_Load;
    }

    // ġ��Ÿ Ȯ�� ( + )  // Axe �� ����  // Moodle_Heavy_Load 
    float Basic_Critical_Hit_Chance = 0.0f;
    float Critical_Hit_Chance = 0.0f;
    float Critical_Hit_Chance_forMoodle = 1;
    public float Get_Critical_Hit_Chance() { return Critical_Hit_Chance * Critical_Hit_Chance_forMoodle; }

    public void Set_Critical_Hit_Chance_forSkill(Weapon_type SkillName, float SkillLevel, bool IsEquipping)
    {
        float Axe_BonusState;
        float Others_BonusState;
        Critical_Hit_Chance = Basic_Critical_Hit_Chance;

        switch (SkillName)
        {
            case Weapon_type.Axe:
                Axe_BonusState = 0.03f * SkillLevel;
                if (IsEquipping)
                    Critical_Hit_Chance = Basic_Critical_Hit_Chance + Axe_BonusState;
                break;
            case Weapon_type.LongBlunt:
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Critical_Hit_Chance = Basic_Critical_Hit_Chance + Others_BonusState;
                break;
            case Weapon_type.ShortBlunt:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Critical_Hit_Chance = Basic_Critical_Hit_Chance + Others_BonusState;
                break;
            case Weapon_type.LongBlade:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Critical_Hit_Chance = Basic_Critical_Hit_Chance + Others_BonusState;
                break;
            case Weapon_type.ShortBlade:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Critical_Hit_Chance = Basic_Critical_Hit_Chance + Others_BonusState;
                break;
            case Weapon_type.Spear:
                Others_BonusState = 0.1f * (SkillLevel - 1);
                if (IsEquipping)
                    Critical_Hit_Chance = Basic_Critical_Hit_Chance + Others_BonusState;
                break;
            case Weapon_type.Gun:

                break;
            default:
                break;
        }

    }

    public void Set_Critical_Hit_Chance_forMoodle(float value)
    {
        Critical_Hit_Chance_forMoodle = (1 - value);
    }

    // ���ĳ� Ȯ�� ( * )   // Strength
    float HitForce = 0.45f;
    public float Get_HitForce() { return HitForce; }

    public void Set_HitForce_forSkill(float SkillLevel)
    {
        float player_Endurance = 1.0f;
        if(Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodle_current_value() < 0.5)  // �����¿� ���� ���ĳ� Ȯ�� ����
        {
            player_Endurance = 0.4f;
        }
        else if(Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodle_current_value() >= 0.5 && Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodle_current_value() < 0.7)
        {
            player_Endurance = 0.7f;
        }
        else
        {
            player_Endurance = 1;
        }

        switch (SkillLevel)  // ���ĳ� Ȯ�� * ���¹̳� * �ٷ�
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

    // ���� Ȯ�� ( + )  // Fitness, Strength // Axe �� ����     // ���� �÷��̾� ���� �� �� ������ ���� Ȯ��
    float Basic_Block_chance = 0.0f;
    float Block_chance = 0.0f;
    public float Get_Block_chance() { return Block_chance; }

    public void Set_Block_chance_forSkill(string SkillName, float SkillLevel, bool IsEquipping) // �ٷ�, ü�� ������ ���� ��� Ȯ��
    {
        float Axe_BonusState;
        float Others_BonusState;
        Block_chance = Basic_Block_chance;

        if (SkillName == "Fitness" || SkillName == "Strength")
        {
            if(Basic_Block_chance == 0)
            {
                Basic_Block_chance = 0.02f * SkillLevel;
            }
            else
            {
                Basic_Block_chance += 0.02f * SkillLevel;
            }
            Block_chance = Basic_Block_chance;
        }
        else
        {
            if (SkillName == "Axe")
            {
                Axe_BonusState = 0.03f * SkillLevel;
                if (IsEquipping)
                    Block_chance = Basic_Block_chance + Axe_BonusState;
            }
            else if (SkillName == "LongBlunt")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Block_chance = Basic_Block_chance + Others_BonusState;
            }
            else if (SkillName == "ShortBlunt")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Block_chance = Basic_Block_chance + Others_BonusState;
            }
            else if (SkillName == "LongBlade")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Block_chance = Basic_Block_chance + Others_BonusState;
            }
            else if (SkillName == "ShortBlade")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Block_chance = Basic_Block_chance + Others_BonusState;
            }
            else if (SkillName == "Spear")
            {
                Others_BonusState = 0.03f * (SkillLevel - 1);
                if (IsEquipping)
                    Block_chance = Basic_Block_chance + Others_BonusState;
            }
            else if (SkillName == "Maintenance")
            {

            }
            else if (SkillName == "Aiming" || SkillName == "Reloading")
            {

            }
        }

    }


    // ���� ���� ������� ��� ���� Ȯ�� // Moodle_Endurance, Moodle_Heavy_Load
    float Chance_of_Blocking_zombie_frontal_attack = 0f;
    float Chance_of_Blocking_zombie_frontal_attack_for_Endurance = 0;
    float Chance_of_Blocking_zombie_frontal_attack_for_Heavy_Load = 0;
    public float Get_Chance_of_Blocking_zombie_frontal_attack() { return (1 - Chance_of_Blocking_zombie_frontal_attack); }
    public void Set_Chance_of_Blocking_zombie_frontal_attack_forMoodle(Moodles_private_code _Moodle_Code, float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Endurance:
                Chance_of_Blocking_zombie_frontal_attack_for_Endurance = (1 - value);
                break;
            case Moodles_private_code.Heavy_Load:
                Chance_of_Blocking_zombie_frontal_attack_for_Heavy_Load = (1 - value);
                break;
        }

        Chance_of_Blocking_zombie_frontal_attack = Chance_of_Blocking_zombie_frontal_attack_for_Endurance + Chance_of_Blocking_zombie_frontal_attack_for_Heavy_Load;
    }


    // ȸ���� Ȯ�� ( + )  // Axe �� ����     // ���� �÷��̾� ���� �� �� ������ ������ �� ȸ���� Ȯ��
    float Basic_Injury_chance = -0.05f;
    float Injury_chance = -0.05f;
    public float Get_Injury_chance() { return Injury_chance; }

    public void Set_Injury_chance_forSkill(Weapon_type SkillName, float SkillLevel, bool IsEquipping)
    {
        float Axe_BonusState;
        float Others_BonusState;
        Injury_chance = Basic_Injury_chance;

        switch (SkillName)
        {
            case Weapon_type.Axe:
                if (IsEquipping)
                {
                    if (SkillLevel == 0)  // -0.05
                    {
                        Axe_BonusState = 0.0f;
                        Injury_chance = Basic_Injury_chance + Axe_BonusState;
                    }
                    else if (SkillLevel == 1)  // -0.02
                    {
                        Axe_BonusState = 0.03f;
                        Injury_chance = Basic_Injury_chance + Axe_BonusState;
                    }
                    else if (SkillLevel >= 2 && SkillLevel < 8)
                    {
                        Axe_BonusState = 0.05f + 0.01f * (SkillLevel - 2);
                        Injury_chance = Basic_Injury_chance + Axe_BonusState;
                    }
                    else if (SkillLevel >= 8)
                    {
                        Axe_BonusState = 0.05f + 0.01f * (SkillLevel - 3);
                        Injury_chance = Basic_Injury_chance + Axe_BonusState;
                    }
                }
                break;
            case Weapon_type.LongBlunt:
                if (SkillLevel <= 1)  // -0.05
                {
                    Others_BonusState = 0.0f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel == 2)  // -0.02
                {
                    Others_BonusState = 0.03f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 3 && SkillLevel < 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 3);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 4);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                break;
            case Weapon_type.ShortBlunt:
                if (SkillLevel <= 1)  // -0.05
                {
                    Others_BonusState = 0.0f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel == 2)  // -0.02
                {
                    Others_BonusState = 0.03f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 3 && SkillLevel < 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 3);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 4);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                break;
            case Weapon_type.LongBlade:
                if (SkillLevel <= 1)  // -0.05
                {
                    Others_BonusState = 0.0f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel == 2)  // -0.02
                {
                    Others_BonusState = 0.03f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 3 && SkillLevel < 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 3);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 4);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                break;
            case Weapon_type.ShortBlade:
                if (SkillLevel <= 1)  // -0.05
                {
                    Others_BonusState = 0.0f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel == 2)  // -0.02
                {
                    Others_BonusState = 0.03f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 3 && SkillLevel < 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 3);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 4);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                break;
            case Weapon_type.Spear:
                if (SkillLevel <= 1)  // -0.05
                {
                    Others_BonusState = 0.0f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel == 2)  // -0.02
                {
                    Others_BonusState = 0.03f;
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 3 && SkillLevel < 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 3);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                else if (SkillLevel >= 9)
                {
                    Others_BonusState = 0.05f + 0.01f * (SkillLevel - 4);
                    Injury_chance = Basic_Injury_chance + Others_BonusState;
                }
                break;
            case Weapon_type.Gun:

                break;
            default:
                break;
        }

    }
    

    // �޸��� �ӵ� ( * )  // Sprinting
    float Running_Speed = 1.0f;
    public float Get_Running_Speed() { return Running_Speed; }

    public void Set_Running_Speed_forSkill(float SkillLevel)
    {
        Running_Speed = 1.0f + 0.05f * SkillLevel;
    }

    // �߼Ҹ� �ݰ� ( * )  // Lightfooted
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

    // ���ؽ� �̵��ӵ� ( * )  // Nimble
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

    // ���ؽ� �߼Ҹ� �ݰ� ( * )  // Nimble
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

    // ���� �� �߼Ҹ� �ݰ� ( * )  // Sneaking
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

    // ���� �� ���񿡰� �߰��� Ȯ�� ( * )  // Sneaking
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

    // ��ݽ� ��Ȯ�� ( + )  ( ��ǥ���� ������ �⺻ Ȯ�� )
    float Gun_Accuracy = 0.0f;
    public float Get_Gun_Accuracy() { return Gun_Accuracy; }
    
    public void Set_Gun_Accuracy(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Gun_Accuracy = 0.00f;
                break;
            case 1:
                Gun_Accuracy = 0.02f;
                break;
            case 2: case 3:
                Gun_Accuracy = 0.05f;
                break;
            case 4: case 5:
                Gun_Accuracy = 0.07f;
                break;
            case 6: case 7:
                Gun_Accuracy = 0.10f;
                break;
            case 8:
                Gun_Accuracy = 0.12f;
                break;
            case 9:
                Gun_Accuracy = 0.15f;
                break;
            case 10:
                Gun_Accuracy = 0.17f;
                break;
        }
    }

    // ��ݽ� ���е� ( + )  ( ġ��Ÿ�� ���� Ȯ��. ġ��Ÿ �� 2�� �̻� ���ظ� ũ�� ���� )
    float Precision = 0.0f;
    public float Get_Precision() { return Precision; }

    public void Set_Precision(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0: case 1:
                Precision = 0.00f;
                break;
            case 2: case 3:
                Precision = 0.02f;
                break;
            case 4: case 5:
                Precision = 0.05f;
                break;
            case 6: case 7:
                Precision = 0.10f;
                break;
            case 8: case 9: case 10:
                Precision = 0.15f;
                break;
        }
    }

    // ��Ÿ� ( + )  ( ��ź���� ������ ��κ��� �ѱ���� ���� �÷��̾��� �ִ� ��ȿ ������ �ణ ���� )
    float Range = 0.0f;
    public float Get_Range() { return Range; }

    public void Set_Range(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0: case 1: case 2:
                Range = 0f;
                break;
            case 3: case 4: case 5:
                Range = 1f;
                break;
            case 6: case 7: case 8:
                Range = 2f;
                break;
            case 9: case 10:
                Range = 3f;
                break;
        }
    }

    // �߻� ����( + )  ( ������ �������� Ư�� ��ǥ�� �� ��Ȯ�ϰ� �ܳ� )
    // �߻簢�� TargetAngle �� = ( 1 - ����.MinAngle ) * 360
    float Launch_Angle = 0.0f;
    public float Get_Launch_Angle() { return Launch_Angle; }

    public void Set_Launch_Angle(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0: case 1:
                Launch_Angle = 0.05f;  // 5�� up
                break;
            case 3: case 4: case 5:
                Launch_Angle = 0.15f;  // 15�� up
                break;
            case 6: case 7: case 8:
                Launch_Angle = 0.25f;  // 25�� up
                break;
            case 9: case 10:
                Launch_Angle = 0.35f;  // 35�� up
                break;
        }
    }

    // ���� �ð� ( * )  ( �÷��̾ �̵� �� �����ϴ� �� �ɸ��� �ð� )
    float Time_for_aiming = 0.0f;
    public float Get_Time_for_aiming() { return Time_for_aiming; }

    public void Set_Time_for_aiming(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0: case 1:
                Launch_Angle = 0.95f;
                break;
            case 3: case 4: case 5:
                Launch_Angle = 0.9f;
                break;
            case 6: case 7: case 8:
                Launch_Angle = 0.8f;
                break;
            case 9: case 10:
                Launch_Angle = 0.7f;
                break;
        }
    }

    // ������ �ð�
    float Time_for_reloading = 0.0f;
    public float Get_Time_for_reloading() { return Time_for_reloading; }

    public void Set_Time_for_reloading(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
            case 1:
                Launch_Angle = 0.95f;
                break;
            case 3:
            case 4:
            case 5:
                Launch_Angle = 0.9f;
                break;
            case 6:
            case 7:
            case 8:
                Launch_Angle = 0.8f;
                break;
            case 9:
            case 10:
                Launch_Angle = 0.7f;
                break;
        }
    }



}

