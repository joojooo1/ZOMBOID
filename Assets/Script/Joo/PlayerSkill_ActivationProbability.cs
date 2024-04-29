using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_ActivationProbability
{

    // 피로도 생성 비율 ( * )  // Fitness
    float Fatigue_Generation_Rate = 1.00f;
    public bool Characteristic_Sleepyhead = false;
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

        if (Characteristic_Sleepyhead)
        {
            Fatigue_Generation_Rate *= 1.3f;
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
    public float Get_Endurance_Depletion_Rate() 
    {
        if (Characteristic_Athletic)
        {
            return Endurance_Depletion_Rate * 0.8f;
        }
        else
        {
            return Endurance_Depletion_Rate;
        }
            
    }

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

    // 공격력 증가 ( * )  // Axe 등 무기 레벨 up시 적용  // Moodle_Panic
    float Basic_Increase_in_Attack_Power = 0.3f;  // 무기 미착용 시
    float Increase_in_Attack_Power = 0.0f;  // 무기 착용 시
    float Increase_in_Attack_Power_forMoodle = 0.0f;
    public float Get_Increase_in_Attack_Power(Item_Weapons current_weapon)
    {
        if(current_weapon.WeaponType == Weapon_type.Gun)
        {
            if((Increase_in_Attack_Power - Increase_in_Attack_Power_for_Panic_with_Gun) > 0)
            {
                return Increase_in_Attack_Power - Increase_in_Attack_Power_for_Panic_with_Gun;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            if((Increase_in_Attack_Power - Increase_in_Attack_Power_forMoodle) > 0)
            {
                return Increase_in_Attack_Power - Increase_in_Attack_Power_forMoodle;
            }
            else
            {
                return 0;
            }
        }
    }

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

    float Increase_in_Attack_Power_for_Panic = 0f;
    float Increase_in_Attack_Power_for_Panic_with_Gun = 0f;
    float Increase_in_Attack_Power_for_Tired = 0f;
    public void Set_Increase_in_Attack_Power_forMoodle(Moodles_private_code _Moodle_Code, int _Moodle_step,float value)
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Panic:
                Increase_in_Attack_Power_for_Panic = value;
                if(_Moodle_step > 1)  // 2단계부터 총기데미지 감소반영
                {
                    if(Player_main.player_main.Skill.Aiming_Level.Get_Gun_Level() < 6)
                    {
                        Increase_in_Attack_Power_for_Panic_with_Gun = value * 2;
                    }
                    else
                    {
                        Increase_in_Attack_Power_for_Panic_with_Gun = 0f;
                    }
                }
                break;
            case Moodles_private_code.Tired:
                Increase_in_Attack_Power_for_Tired = value;
                break;
        }

        Increase_in_Attack_Power_forMoodle = Increase_in_Attack_Power_for_Panic + Increase_in_Attack_Power_for_Tired;
    }


    // 근접 공격력 비율 ( * )  // Strength
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


    // 공격 속도 ( + )  // Fitness // Axe 등 무기  // Moodle_Heavy_Load, Endurance
    float Basic_Attack_Speed = 0f;  // 무기 미착용 시
    float Attack_Speed_for_Weapon = 0f;  // 무기 착용 시
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
    float Attack_Speed_for_HHyperthermia_Hot = 1;
    float Attack_Speed_for_Hyperthermia_Cold = 1;
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
            case Moodles_private_code.Hyperthermia_Hot:
                Attack_Speed_for_HHyperthermia_Hot = 1 - value;
                break;
            case Moodles_private_code.Hyperthermia_Cold:
                Attack_Speed_for_Hyperthermia_Cold = 1 - value;
                break;
        }
        Attack_Speed_for_Moodle = Attack_Speed_for_Endurance * Attack_Speed_for_Heavy_Load * Attack_Speed_for_HHyperthermia_Hot * Attack_Speed_for_Hyperthermia_Cold;
    }


    // 넘어질 확률 ( - )  // Fitness  // Moodle_Heavy_Load, Moodle_Pain
    // 달리거나 전력 질주를 하는 도중 낮은 울타리를 넘거나 좀비와 부딫힐 때 넘어질 확률
    float Probability_of_Falling = 0.2f;
    float Probability_of_Falling_forSkill = 0f;
    float Probability_of_Falling_forMoodle = 0f;
    public float Get_Probability_of_Falling() 
    { 
        if(Player_main.player_main.playerMoodles.Moodle_Drunk.Get_Moodle_current_step() > 0)
        {
            return Probability_of_Falling + Probability_of_Falling_forMoodle - Probability_of_Falling_for_Pain;
        }
        else
        {
            return Probability_of_Falling + Probability_of_Falling_forMoodle;
        }
    }

    public void Set_Probability_of_Falling(float value)
    {
        Probability_of_Falling += value;
    }
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

    // 높은 담을 넘을 확률 ( + )  // Fitness, Strength  // Moodle_Heavy_Load
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

    // 치명타 확률 ( + )  // Axe 등 무기  // Moodle_Heavy_Load 
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

    float Set_Critical_Hit_Chance_forMoodle_for_Heavy_Load = 0;
    float Set_Critical_Hit_Chance_forMoodle_for_Panic = 0;
    public void Set_Critical_Hit_Chance_forMoodle(Moodles_private_code _Moodle_Code, float value)  // Moodle_Heavy_Load
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Heavy_Load:
                Set_Critical_Hit_Chance_forMoodle_for_Heavy_Load = (1 - value);
                break;
            case Moodles_private_code.Panic:
                Set_Critical_Hit_Chance_forMoodle_for_Panic = (1 - value);
                break;
        }
        Critical_Hit_Chance_forMoodle = Set_Critical_Hit_Chance_forMoodle_for_Heavy_Load * Set_Critical_Hit_Chance_forMoodle_for_Panic;
    }

    // 밀쳐낼 확률 ( * )   // Strength
    float HitForce = 0.45f;
    public bool Characteristic_Strong = false;
    public float Get_HitForce() 
    {
        if (Characteristic_Strong)
        {
            return HitForce * 1.4f;
        }
        else
        {
            return HitForce;
        }
    }

    public void Set_HitForce_forSkill(float SkillLevel)
    {
        float player_Endurance = 1.0f;
        if(Player_Moodles.playerMoodles.Moodle_Endurance.Get_Moodle_current_value() < 0.5)  // 지구력에 따른 밀쳐낼 확률 감소
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
    float Basic_Block_chance = 0.0f;
    float Block_chance = 0.0f;
    public float Get_Block_chance() { return Block_chance; }

    public void Set_Block_chance_forSkill(string SkillName, float SkillLevel, bool IsEquipping) // 근력, 체력 레벨에 따른 방어 확률
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


    // 좀비에 대한 정면공격 방어 감소 확률 // Moodle_Endurance, Moodle_Heavy_Load
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


    // 회피할 확률 ( + )  // Axe 등 무기     // 좀비가 플레이어 공격 시 그 공격이 성공한 후 회피할 확률
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
    

    // 달리기 속도 ( * )  // Sprinting
    float Running_Speed = 1.0f;
    public bool Characteristic_Athletic = false;
    public float Get_Running_Speed() { return Running_Speed; }

    public void Set_Running_Speed_forSkill(float SkillLevel)
    {
        if (Characteristic_Athletic)
        {
            Running_Speed = (1.0f + 0.05f * SkillLevel) * 1.2f;
        }
        else
        {
            Running_Speed = 1.0f + 0.05f * SkillLevel;
        }
        
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
                Movement_Speed_while_Aiming = 0.79f;
                break;
            case 1:
                Movement_Speed_while_Aiming = 0.85f;
                break;
            case 2:
                Movement_Speed_while_Aiming = 0.9f;
                break;
            case 3:
                Movement_Speed_while_Aiming = 1.00f;
                break;
            case 4:
                Movement_Speed_while_Aiming = 1.10f;
                break;
            case 5:
                Movement_Speed_while_Aiming = 1.14f;
                break;
            case 6:
                Movement_Speed_while_Aiming = 1.18f;
                break;
            case 7:
                Movement_Speed_while_Aiming = 1.22f;
                break;
            case 8:
                Movement_Speed_while_Aiming = 1.26f;
                break;
            case 9:
                Movement_Speed_while_Aiming = 1.30f;
                break;
            case 10:
                Movement_Speed_while_Aiming = 1.34f;
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

    // 사격시 정확도 ( + )  ( 목표물에 명중할 기본 확률 )
    float Gun_Accuracy = 0.0f;
    public float Get_Gun_Accuracy() 
    { 
        if(Player_main.player_main.playerMoodles.Moodle_Drunk.Get_Moodle_current_step() > 0)
        {
            return Gun_Accuracy;
        }
        else
        {
            return Gun_Accuracy - Player_main.player_main.Get_Accuracy_forMoodle();
        }
    }
    
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
            case 2:
                Gun_Accuracy = 0.04f;
                break;
            case 3:
                Gun_Accuracy = 0.06f;
                break;
            case 4:
                Gun_Accuracy = 0.08f;
                break;
            case 5:
                Gun_Accuracy = 0.10f;
                break;
            case 6:
                Gun_Accuracy = 0.12f;
                break;
            case 7:
                Gun_Accuracy = 0.14f;
                break;
            case 8:
                Gun_Accuracy = 0.16f;
                break;
            case 9:
                Gun_Accuracy = 0.18f;
                break;
            case 10:
                Gun_Accuracy = 0.20f;
                break;
        }
    }

    // 사격시 정밀도 ( + )  ( 치명타를 맞을 확률. 치명타 시 2배 이상 피해를 크게 증가 )
    float Precision = 0.0f;
    public float Get_Precision() { return Precision; }

    public void Set_Precision(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0:
                Precision = 0.00f;
                break;
            case 1:
                Precision = 0.03f;
                break;
            case 2:
                Precision = 0.06f;
                break;
            case 3:
                Precision = 0.09f;
                break;
            case 4:
                Precision = 0.12f;
                break;
            case 5:
                Precision = 0.15f;
                break;
            case 6:
                Precision = 0.18f;
                break;
            case 7:
                Precision = 0.21f;
                break;
            case 8:
                Precision = 0.24f;
                break;
            case 9:
                Precision = 0.27f;
                break;
            case 10:
                Precision = 0.30f;
                break;
        }
    }

    // 사거리 ( + )  ( 산탄총을 제외한 대부분의 총기류에 대한 플레이어의 최대 유효 범위를 약간 증가 )
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

    // 발사 각도( + )  ( 범위가 좁을수록 특정 목표를 더 정확하게 겨냥 )
    // 발사각도 TargetAngle ° = ( 1 - 무기.MinAngle ) * 360
    float Launch_Angle = 0.0f;
    public float Get_Launch_Angle() { return Launch_Angle; }

    public void Set_Launch_Angle(float SkillLevel)
    {
        switch (SkillLevel)
        {
            case 0: case 1:
                Launch_Angle = 0.05f;  // 5도 up
                break;
            case 3: case 4: case 5:
                Launch_Angle = 0.15f;  // 15도 up
                break;
            case 6: case 7: case 8:
                Launch_Angle = 0.25f;  // 25도 up
                break;
            case 9: case 10:
                Launch_Angle = 0.35f;  // 35도 up
                break;
        }
    }

    // 조준 시간 ( * )  ( 플레이어가 이동 후 조준하는 데 걸리는 시간 )
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

    // 재장전 시간
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

