using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPassiveSkill_Level  // 체력, 근력
{
    PlayerInventory_main P_Inven = new PlayerInventory_main();

    string P_SkillName = "";
    float P_Level = 0f;
    float P_Min_Level = 0f;
    float P_Max_Level = 10f;

    float P_EXP = 0f;
    List<float>[] P_expRequirements;
    // 레벨 0 ~ 10
    // 레벨별 필요 경험치

    public PlayerPassiveSkill_Level(float initialLevel, string skillName)
    {
        if (initialLevel >= P_Min_Level && initialLevel <= P_Max_Level)
        {
            P_SkillName = skillName;
            P_Level = initialLevel;
            InitializeExpRequirements();

            if (P_SkillName == "Fitness")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Fatigue_Generation_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Endurance_Recovery_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Endurance_Depletion_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill("Fitness", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Fitness", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 미반영사항: 특성
                   (0~1: 비실함, 2~4: 건강 이상, 5: -, 6~8: 건강함, 9~10: 육상선수)
                 */
            }
            else if(P_SkillName == "Strength")
            {
                P_Inven.Inventory_Weight.Set_MaxWeight_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_HitForce_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Strength", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 미반영사항: 특성
                   (0~1: 약함, 2~4: 연약함, 5: -, 6~8: 통통함, 9~10: 튼튼함)
                 */
            }
        }
    }

    void InitializeExpRequirements()
    {
        P_expRequirements = new List<float>[10];
        for(int i = 0; i < P_expRequirements.Length; i++)
        {
            P_expRequirements[i] = new List<float>();
        }

        // P_EXP와 비교
        P_expRequirements[0].Add(1500f);  // Level 0 -> 1
        P_expRequirements[1].Add(3000f);  // Level 1 -> 2
        P_expRequirements[2].Add(6000f);  // Level 2 -> 3
        P_expRequirements[3].Add(9000f);  // Level 3 -> 4
        P_expRequirements[4].Add(18000f);  // Level 4 -> 5
        P_expRequirements[5].Add(30000f);  // Level 5 -> 6
        P_expRequirements[6].Add(60000f);  // Level 6 -> 7
        P_expRequirements[7].Add(90000f);  // Level 7 -> 8
        P_expRequirements[8].Add(120000f);  // Level 8 -> 9
        P_expRequirements[9].Add(150000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        P_EXP += exp;
        if(P_Level < P_Max_Level && P_EXP >= P_expRequirements[(int)P_Level][0])
        {
            P_EXP -= P_expRequirements[(int)P_Level][0];
            P_Level++;

            if (P_SkillName == "Fitness")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Fatigue_Generation_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Endurance_Recovery_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Endurance_Depletion_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill("Fitness", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Fitness", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 미반영사항: 특성
                   (0~1: 비실함, 2~4: 건강 이상, 5: -, 6~8: 건강함, 9~10: 육상선수)
                 */
            }
            else if (P_SkillName == "Strength")
            {
                P_Inven.Inventory_Weight.Set_MaxWeight_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_HitForce_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Strength", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 미반영사항: 특성
                   (0~1: 약함, 2~4: 연약함, 5: -, 6~8: 통통함, 9~10: 튼튼함)
                 */
            }
        }
        /*
         미반영사항: 운동을 통해 Fitness/Strength 레벨 상승하는 함수
         */
    }

    public float Get_P_Level()
    {
        return P_Level;
    }

    public float Get_P_CurrentEXP()
    {
        return P_EXP;
    }
}

public class PlayerGeneralSkill_Level  // 능숙한 달리기, 조용한 발걸음, 전투시 발걸음, 은밀한 움직임
{
    string G_SkillName = "";
    float G_Level = 0f;
    float G_Min_Level = 0f;
    float G_Max_Level = 10f;

    bool G_Is_Weapon = false;

    float G_EXP = 0f;
    List<float>[] G_expRequirements;
    // 레벨 0 ~ 10
    // 레벨별 필요 경험치

    public PlayerGeneralSkill_Level(float initialLevel, string skillname)  
    {
        if (initialLevel >= G_Min_Level && initialLevel <= G_Max_Level)
        {
            G_SkillName = skillname;
            G_Level = initialLevel;
            InitializeExpRequirements();

            if (G_SkillName == "Sprinting")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Running_Speed_forSkill(G_Level);
            }
            else if (G_SkillName == "Lightfooted")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Footstep_Radius_forSkill(G_Level);
            }
            else if(G_SkillName == "Nimble")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Movement_Speed_while_Aiming_forSkill(G_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Footstep_Radius_while_Aiming_forSkill(G_Level);
            }
            else if(G_SkillName == "Sneaking")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Footstep_Radius_while_Sneaking_forSkill(G_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Detection_by_Zombies_while_Sneaking_forSkill(G_Level);
            }
        }
    }

    void InitializeExpRequirements()
    {
        G_expRequirements = new List<float>[10];
        for (int i = 0; i < G_expRequirements.Length; i++)
        {
            G_expRequirements[i] = new List<float>();
        }

        // _TotalEXP와 비교
        G_expRequirements[0].Add(75f);  // Level 0 -> 1
        G_expRequirements[1].Add(150f);  // Level 1 -> 2
        G_expRequirements[2].Add(300f);  // Level 2 -> 3
        G_expRequirements[3].Add(750f);  // Level 3 -> 4
        G_expRequirements[4].Add(1500f);  // Level 4 -> 5
        G_expRequirements[5].Add(3000f);  // Level 5 -> 6
        G_expRequirements[6].Add(4500f);  // Level 6 -> 7
        G_expRequirements[7].Add(6000f);  // Level 7 -> 8
        G_expRequirements[8].Add(7500f);  // Level 8 -> 9
        G_expRequirements[9].Add(9000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        G_EXP += exp;
        if (G_Level < G_Max_Level && G_EXP >= G_expRequirements[(int)G_Level][0])
        {
            G_EXP -= G_expRequirements[(int)G_Level][0];
            G_Level++;

            if (G_SkillName == "Sprinting")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Running_Speed_forSkill(G_Level);
            }
            else if (G_SkillName == "Lightfooted")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Footstep_Radius_forSkill(G_Level);
            }
            else if (G_SkillName == "Nimble")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Movement_Speed_while_Aiming_forSkill(G_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Footstep_Radius_while_Aiming_forSkill(G_Level);
            }
            else if (G_SkillName == "Sneaking")
            {
                Player_main.player_main.playerSkill_ActivationProbability.Set_Footstep_Radius_while_Sneaking_forSkill(G_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Detection_by_Zombies_while_Sneaking_forSkill(G_Level);
            }

        }
    }

    public float Get_G_Level()
    {
        return G_Level;
    }

    public float Get_G_CurrentEXP()
    {
        return G_EXP;
    }
}

public class PlayerWeaponSkill_Level  // 도끼, 긴 둔기, 짧은 둔기, 장검, 단검, 창
{
    Weapon_type W_type;
    string W_SkillName = "";
    float W_Level = 0f;
    float W_Min_Level = 0f;
    float W_Max_Level = 10f;

    float W_EXP = 0f;
    List<float>[] W_expRequirements;
    // 레벨 0 ~ 10
    // 레벨별 필요 경험치

    public PlayerWeaponSkill_Level(float initialLevel, Weapon_type type)
    {
        if (initialLevel >= W_Min_Level && initialLevel <= W_Max_Level)
        {
            W_type = type;
            W_Level = initialLevel;
            InitializeExpRequirements();
        }
    }

    void InitializeExpRequirements()
    {
        W_expRequirements = new List<float>[10];
        for (int i = 0; i < W_expRequirements.Length; i++)
        {
            W_expRequirements[i] = new List<float>();
        }

        // _TotalEXP와 비교
        W_expRequirements[0].Add(75f);  // Level 0 -> 1
        W_expRequirements[1].Add(150f);  // Level 1 -> 2
        W_expRequirements[2].Add(300f);  // Level 2 -> 3
        W_expRequirements[3].Add(750f);  // Level 3 -> 4
        W_expRequirements[4].Add(1500f);  // Level 4 -> 5
        W_expRequirements[5].Add(3000f);  // Level 5 -> 6
        W_expRequirements[6].Add(4500f);  // Level 6 -> 7
        W_expRequirements[7].Add(6000f);  // Level 7 -> 8
        W_expRequirements[8].Add(7500f);  // Level 8 -> 9
        W_expRequirements[9].Add(9000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        if (W_Level < 5)
            W_EXP += exp;

        if (W_Level < W_Max_Level && W_EXP >= W_expRequirements[(int)W_Level][0])
        {
            W_EXP -= W_expRequirements[(int)W_Level][0];
            W_Level++;
        }
    }

    public float Get_W_Level()
    {
        return W_Level;
    }

    public int Get_W_Level(Weapon_type type)
    {
        return (int)W_Level;
    }

    public float Get_W_CurrentEXP()
    {
        return W_EXP;
    }

    // 무기 착용, 해제 시 각각 반영되는 효과 설정
    public void Set_Weapon_Equipping_Effect(bool IsEquipping)
    {
        if (W_SkillName == "Axe")
        {
            Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forSkill(Weapon_type.Axe, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forSkill(Weapon_type.Axe, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Injury_chance_forSkill(Weapon_type.Axe, W_Level, IsEquipping);
        }
        else if (W_SkillName == "LongBlunt")
        {
            Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forSkill(Weapon_type.LongBlunt, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forSkill(Weapon_type.LongBlunt, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Injury_chance_forSkill(Weapon_type.LongBlunt, W_Level, IsEquipping);
        }
        else if (W_SkillName == "ShortBlunt")
        {
            Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forSkill(Weapon_type.ShortBlunt, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forSkill(Weapon_type.ShortBlunt, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Injury_chance_forSkill(Weapon_type.ShortBlunt, W_Level, IsEquipping);
        }
        else if (W_SkillName == "LongBlade")
        {
            Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forSkill(Weapon_type.LongBlade, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forSkill(Weapon_type.LongBlade, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Injury_chance_forSkill(Weapon_type.LongBlade, W_Level, IsEquipping);
        }
        else if (W_SkillName == "ShortBlade")
        {
            Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forSkill(Weapon_type.ShortBlade, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forSkill(Weapon_type.ShortBlade, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Injury_chance_forSkill(Weapon_type.ShortBlade, W_Level, IsEquipping);
        }
        else if (W_SkillName == "Spear")
        {
            Player_main.player_main.playerSkill_ActivationProbability.Set_Increase_in_Attack_Power_forSkill(Weapon_type.Spear, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Critical_Hit_Chance_forSkill(Weapon_type.Spear, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill(W_SkillName, W_Level, IsEquipping);
            Player_main.player_main.playerSkill_ActivationProbability.Set_Injury_chance_forSkill(Weapon_type.Spear, W_Level, IsEquipping);
        }
    }

}

public class PlayerMaintenanceSkill_Level  // 물건관리
{
    string M_SkillName = "";
    float M_Level = 0f;
    float M_Min_Level = 0f;
    float M_Max_Level = 10f;

    float M_EXP = 0f;
    List<float>[] M_expRequirements;
    // 레벨 0 ~ 10
    // 레벨별 필요 경험치

    public PlayerMaintenanceSkill_Level(float initialLevel)
    {
        if (initialLevel >= M_Min_Level && initialLevel <= M_Max_Level)
        {
            M_Level = initialLevel;
            InitializeExpRequirements();
        }
    }

    void InitializeExpRequirements()
    {
        M_expRequirements = new List<float>[10];
        for (int i = 0; i < M_expRequirements.Length; i++)
        {
            M_expRequirements[i] = new List<float>();
        }

        // _TotalEXP와 비교
        M_expRequirements[0].Add(75f);  // Level 0 -> 1
        M_expRequirements[1].Add(150f);  // Level 1 -> 2
        M_expRequirements[2].Add(300f);  // Level 2 -> 3
        M_expRequirements[3].Add(750f);  // Level 3 -> 4
        M_expRequirements[4].Add(1500f);  // Level 4 -> 5
        M_expRequirements[5].Add(3000f);  // Level 5 -> 6
        M_expRequirements[6].Add(4500f);  // Level 6 -> 7
        M_expRequirements[7].Add(6000f);  // Level 7 -> 8
        M_expRequirements[8].Add(7500f);  // Level 8 -> 9
        M_expRequirements[9].Add(9000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        M_EXP += exp;
        if (M_Level < M_Max_Level && M_EXP >= M_expRequirements[(int)M_Level][0])
        {
            M_EXP -= M_expRequirements[(int)M_Level][0];
            M_Level++;
        }
    }

    public float Get_M_Level()
    {
        return M_Level;
    }

    public float Get_M_CurrentEXP()
    {
        return M_EXP;
    }

    float maintenancemod = 1;
    public float Get_Maintenance(Item_Weapons Weapon)  // 근접무기의 내구도 소모율에 영향
    {
        switch (Weapon.WeaponType)
        {
            case Weapon_type.Axe:
                maintenancemod = (Get_M_Level() + (Player_main.player_main.Skill.Axe_Level.Get_W_Level() / 2)) / 2;
                break;
            case Weapon_type.LongBlunt:
                maintenancemod = (Get_M_Level() + (Player_main.player_main.Skill.LongBlunt_Level.Get_W_Level() / 2)) / 2;
                break;
            case Weapon_type.ShortBlunt:
                maintenancemod = (Get_M_Level() + (Player_main.player_main.Skill.ShortBlunt_Level.Get_W_Level() / 2)) / 2;
                break;
            case Weapon_type.LongBlade:
                maintenancemod = (Get_M_Level() + (Player_main.player_main.Skill.LongBlade_Level.Get_W_Level() / 2)) / 2;
                break;
            case Weapon_type.ShortBlade:
                maintenancemod = (Get_M_Level() + (Player_main.player_main.Skill.ShortBlade_Level.Get_W_Level() / 2)) / 2;
                break;
            case Weapon_type.Spear:
                maintenancemod = (Get_M_Level() + (Player_main.player_main.Skill.Spear_Level.Get_W_Level() / 2)) / 2;
                break;
            default: break;

        }
        return 1 / (Weapon.W_Condition_lower_chance + (maintenancemod * 2));
    }

}

public class PlayerGunSkill_Level  // 조준(총), 재장전(총)
{
    Weapon_type Gun_type;
    string Gun_SkillName = "";
    float Gun_Level = 0f;
    float Gun_Min_Level = 0f;
    float Gun_Max_Level = 10f;

    float Gun_EXP = 0f;
    List<float>[] Gun_expRequirements;
    // 레벨 0 ~ 10
    // 레벨별 필요 경험치

    public PlayerGunSkill_Level(float initialLevel, Weapon_type type, string SkillName)
    {
        if (initialLevel >= Gun_Min_Level && initialLevel <= Gun_Max_Level)
        {
            Gun_type = type;
            Gun_SkillName = SkillName;
            Gun_Level = initialLevel;
            InitializeExpRequirements();
        }
    }

    void InitializeExpRequirements()
    {
        Gun_expRequirements = new List<float>[10];
        for (int i = 0; i < Gun_expRequirements.Length; i++)
        {
            Gun_expRequirements[i] = new List<float>();
        }

        // _TotalEXP와 비교
        Gun_expRequirements[0].Add(75f);  // Level 0 -> 1
        Gun_expRequirements[1].Add(150f);  // Level 1 -> 2
        Gun_expRequirements[2].Add(300f);  // Level 2 -> 3
        Gun_expRequirements[3].Add(750f);  // Level 3 -> 4
        Gun_expRequirements[4].Add(1500f);  // Level 4 -> 5
        Gun_expRequirements[5].Add(3000f);  // Level 5 -> 6
        Gun_expRequirements[6].Add(4500f);  // Level 6 -> 7
        Gun_expRequirements[7].Add(6000f);  // Level 7 -> 8
        Gun_expRequirements[8].Add(7500f);  // Level 8 -> 9
        Gun_expRequirements[9].Add(9000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        if (Gun_Level < 5)
            Gun_EXP += exp;
        else  // 레벨 5 이상에서는 경험치 획득량 약 37%로 감소
            Gun_EXP += exp * 0.37f;

        if (Gun_Level < Gun_Max_Level && Gun_EXP >= Gun_expRequirements[(int)Gun_Level][0])
        {
            Gun_EXP -= Gun_expRequirements[(int)Gun_Level][0];
            Gun_Level++;
        }
    }

    public float Get_Gun_Level()
    {
        return Gun_Level;
    }

    public float Get_Gun_CurrentEXP()
    {
        return Gun_EXP;
    }

    // 무기 착용, 해제 시 각각 반영되는 효과 설정
    public void Set_Gun_Equipping_Effect(bool IsEquipping)
    {
        // 무기 정보 받아서 정확도 등 계산

        if (Gun_SkillName == "Aiming")
        {
            // 정확도
            Player_main.player_main.playerSkill_ActivationProbability.Set_Gun_Accuracy(Gun_Level);
            // 정밀도
            Player_main.player_main.playerSkill_ActivationProbability.Set_Precision(Gun_Level);
            // 사거리
            Player_main.player_main.playerSkill_ActivationProbability.Set_Range(Gun_Level);
            // 발사각도
            Player_main.player_main.playerSkill_ActivationProbability.Set_Launch_Angle(Gun_Level);
            // 조준시간 감소
            Player_main.player_main.playerSkill_ActivationProbability.Set_Time_for_aiming(Gun_Level);
        }
        else if (Gun_SkillName == "Reloading")
        {
            // 재장전 시간 감소
            Player_main.player_main.playerSkill_ActivationProbability.Set_Time_for_reloading(Gun_Level);
        }
    }
}
public class PlayerCraftingSkill_Level  // 목공, 요리, 농사, 의료, 전기공학
{
    string C_SkillName = "";
    float C_Level = 0f;
    float C_Min_Level = 0f;
    float C_Max_Level = 10f;

    float C_EXP = 0f;
    List<float>[] C_expRequirements;
    // 레벨 0 ~ 10
    // 레벨별 필요 경험치

    public PlayerCraftingSkill_Level(float initialLevel, string skillname)
    {
        if (initialLevel >= C_Min_Level && initialLevel <= C_Max_Level)
        {
            C_SkillName = skillname;
            C_Level = initialLevel;
            InitializeExpRequirements();

            if (C_SkillName == "Carpentry")
            {

            }
            else if (C_SkillName == "Cooking")
            {

            }
            else if (C_SkillName == "Farming")
            {

            }
            else if (C_SkillName == "FirstAid")
            {

            }
            else if (C_SkillName == "Electrical")
            {

            }
        }
    }

    void InitializeExpRequirements()
    {
        C_expRequirements = new List<float>[10];
        for (int i = 0; i < C_expRequirements.Length; i++)
        {
            C_expRequirements[i] = new List<float>();
        }

        // _TotalEXP와 비교
        C_expRequirements[0].Add(75f);  // Level 0 -> 1
        C_expRequirements[1].Add(150f);  // Level 1 -> 2
        C_expRequirements[2].Add(300f);  // Level 2 -> 3
        C_expRequirements[3].Add(750f);  // Level 3 -> 4
        C_expRequirements[4].Add(1500f);  // Level 4 -> 5
        C_expRequirements[5].Add(3000f);  // Level 5 -> 6
        C_expRequirements[6].Add(4500f);  // Level 6 -> 7
        C_expRequirements[7].Add(6000f);  // Level 7 -> 8
        C_expRequirements[8].Add(7500f);  // Level 8 -> 9
        C_expRequirements[9].Add(9000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        C_EXP += exp;
        if (C_Level < C_Max_Level && C_EXP >= C_expRequirements[(int)C_Level][0])
        {
            C_EXP -= C_expRequirements[(int)C_Level][0];
            C_Level++;

            if (C_SkillName == "Carpentry")
            {

            }
            else if (C_SkillName == "Cooking")
            {

            }
            else if (C_SkillName == "Farming")
            {

            }
            else if (C_SkillName == "FirstAid")
            {

            }
            else if (C_SkillName == "Electrical")
            {

            }

        }
    }

    public float Get_C_Level()
    {
        return C_Level;
    }

    public float Get_C_CurrentEXP()
    {
        return C_EXP;
    }

}

