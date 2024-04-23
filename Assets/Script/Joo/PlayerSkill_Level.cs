using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class PlayerPassiveSkill_Level  // ü��, �ٷ�
{
    string P_SkillName = "";
    string P_SkillName_kr = "";
    float P_Level = 0f;
    float P_Min_Level = 0f;
    float P_Max_Level = 10f;

    float P_EXP = 0f;
    List<float>[] P_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerPassiveSkill_Level(float initialLevel, string skillName, string skillname_kr)
    {
        if (initialLevel >= P_Min_Level && initialLevel <= P_Max_Level)
        {
            P_SkillName = skillName;
            P_SkillName_kr = skillname_kr;
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
                 �̹ݿ�����: Ư��
                   (0~1: �����, 2~4: �ǰ� �̻�, 5: -, 6~8: �ǰ���, 9~10: ���󼱼�)
                 */
            }
            else if (P_SkillName == "Strength")
            {
                Player_main.player_main.Inven_main.Inventory_Weight.Set_MaxWeight_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_HitForce_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Strength", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 �̹ݿ�����: Ư��
                   (0~1: ����, 2~4: ������, 5: -, 6~8: ������, 9~10: ưư��)
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

        // P_EXP�� ��
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
        P_EXP = P_EXP + exp;
        if (P_Level < P_Max_Level && P_EXP >= P_expRequirements[(int)P_Level][0])
        {
            P_EXP -= P_expRequirements[(int)P_Level][0];
            P_Level++;

            if (P_SkillName == "Fitness")
            {
                Player_Characteristic.current.Set_Characteristic_for_Fitness(Get_P_Level());
                Player_main.player_main.playerSkill_ActivationProbability.Set_Fatigue_Generation_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Endurance_Recovery_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Endurance_Depletion_Rate_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Attack_Speed_forSkill("Fitness", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Falling_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Fitness", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 �̹ݿ�����: Ư��
                   (0~1: �����, 2~4: �ǰ� �̻�, 5: -, 6~8: �ǰ���, 9~10: ���󼱼�)
                 */
            }
            else if (P_SkillName == "Strength")
            {
                Player_Characteristic.current.Set_Characteristic_for_Strength(Get_P_Level());
                Player_main.player_main.Inven_main.Inventory_Weight.Set_MaxWeight_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Melee_Attack_Power_Ratio_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_HitForce_forSkill(P_Level);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Block_chance_forSkill("Strength", P_Level, Player_main.player_main.Is_Equipping_Weapons);
                Player_main.player_main.playerSkill_ActivationProbability.Set_Probability_of_Crossing_a_High_Wall_forSkill(P_Level);
                /*
                 �̹ݿ�����: Ư��
                   (0~1: ����, 2~4: ������, 5: -, 6~8: ������, 9~10: ưư��)
                 */
            }
        }
        /*
         �̹ݿ�����: ��� ���� Fitness/Strength ���� ����ϴ� �Լ�
         */
    }

    public float Get_P_Level()
    {
        return P_Level;
    }

    public void Set_P_Level(float Start_Level)
    {
        P_Level = Start_Level;
    }

    public float Get_P_CurrentEXP()
    {
        return P_EXP;
    }

    public float Get_P_TotalEXP()
    {
        if(P_Level < 10)
            return P_expRequirements[(int)P_Level][0];
        else
            return P_expRequirements[(int)P_Level-1][0];
    }

    public float Get_P_EXP()
    {
        return Get_P_CurrentEXP() / Get_P_TotalEXP();
    }

    public string Get_P_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return P_SkillName_kr;
        }
        else
        {
            return P_SkillName;
        }
    }

}

public class PlayerGeneralSkill_Level  // �ɼ��� �޸���, ������ �߰���, ������ �߰���, ������ ������
{
    string G_SkillName = "";
    string G_SkillName_kr = "";
    float G_Level = 0f;
    float G_Min_Level = 0f;
    float G_Max_Level = 10f;

    bool G_Is_Weapon = false;

    float G_EXP = 0f;
    List<float>[] G_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerGeneralSkill_Level(float initialLevel, string skillname, string skillname_kr)  
    {
        if (initialLevel >= G_Min_Level && initialLevel <= G_Max_Level)
        {
            G_SkillName = skillname;
            G_SkillName_kr = skillname_kr;
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

        // _TotalEXP�� ��
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

    public void Set_G_Level(float Start_Level)
    {
        G_Level = Start_Level;
    }

    public float Get_G_CurrentEXP()
    {
        return G_EXP;
    }

    public float Get_G_TotalEXP()
    {
        if (G_Level < 10)
            return G_expRequirements[(int)G_Level][0];
        else
            return G_expRequirements[(int)G_Level - 1][0];
    }

    public float Get_G_EXP()
    {
        return Get_G_CurrentEXP() / Get_G_TotalEXP();
    }

    public string Get_G_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return G_SkillName_kr;
        }
        else
        {
            return G_SkillName;
        }
    }
}

public class PlayerWeaponSkill_Level  // ����, �� �б�, ª�� �б�, ���, �ܰ�, â
{
    Weapon_type W_type;
    string W_SkillName = "";
    string W_SkillName_kr = "";
    float W_Level = 0f;
    float W_Min_Level = 0f;
    float W_Max_Level = 10f;

    float W_EXP = 0f;
    List<float>[] W_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerWeaponSkill_Level(float initialLevel, Weapon_type type, string skillname, string skillname_kr)
    {
        if (initialLevel >= W_Min_Level && initialLevel <= W_Max_Level)
        {
            W_type = type;
            W_Level = initialLevel;
            W_SkillName = skillname;
            W_SkillName_kr = skillname_kr;
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

        // _TotalEXP�� ��
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

    public float Get_W_TotalEXP()
    {
        if (W_Level < 10)
            return W_expRequirements[(int)W_Level][0];
        else
            return W_expRequirements[(int)W_Level - 1][0];
    }

    public float Get_W_EXP()
    {
        return Get_W_CurrentEXP() / Get_W_TotalEXP();
    }

    public string Get_W_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return W_SkillName_kr;
        }
        else
        {
            return W_SkillName;
        }
    }

    // ���� ����, ���� �� ���� �ݿ��Ǵ� ȿ�� ����
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

public class PlayerMaintenanceSkill_Level  // ���ǰ���
{
    string M_SkillName = "";
    string M_SkillName_kr = "";
    float M_Level = 0f;
    float M_Min_Level = 0f;
    float M_Max_Level = 10f;

    float M_EXP = 0f;
    List<float>[] M_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerMaintenanceSkill_Level(float initialLevel, string skillname, string skillname_kr)
    {
        if (initialLevel >= M_Min_Level && initialLevel <= M_Max_Level)
        {
            M_Level = initialLevel;
            M_SkillName = skillname;
            M_SkillName_kr = skillname_kr;
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

        // _TotalEXP�� ��
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

    public float Get_M_TotalEXP()
    {
        if (M_Level < 10)
            return M_expRequirements[(int)M_Level][0];
        else
            return M_expRequirements[(int)M_Level - 1][0];
    }

    public float Get_M_EXP()
    {
        return Get_M_CurrentEXP() / Get_M_TotalEXP();
    }

    public string Get_M_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return M_SkillName_kr;
        }
        else
        {
            return M_SkillName;
        }
    }

    float maintenancemod = 1;
    public float Get_Maintenance(Item_Weapons Weapon)  // ���������� ������ �Ҹ����� ����
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

public class PlayerGunSkill_Level  // ����(��), ������(��)
{
    Weapon_type Gun_type;
    string Gun_SkillName = "";
    string Gun_SkillName_kr = "";
    float Gun_Level = 0f;
    float Gun_Min_Level = 0f;
    float Gun_Max_Level = 10f;

    float Gun_EXP = 0f;
    List<float>[] Gun_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerGunSkill_Level(float initialLevel, Weapon_type type, string skillname, string skillname_kr)
    {
        if (initialLevel >= Gun_Min_Level && initialLevel <= Gun_Max_Level)
        {
            Gun_type = type;
            Gun_SkillName = skillname;
            Gun_SkillName_kr = skillname_kr;
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

        // _TotalEXP�� ��
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
        else  // ���� 5 �̻󿡼��� ����ġ ȹ�淮 �� 37%�� ����
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

    public void Set_Gun_Level(float Start_Level)
    {
        Gun_Level = Start_Level;
    }

    public float Get_Gun_CurrentEXP()
    {
        return Gun_EXP;
    }

    public float Get_Gun_TotalEXP()
    {
        if (Gun_Level < 10)
            return Gun_expRequirements[(int)Gun_Level][0];
        else
            return Gun_expRequirements[(int)Gun_Level - 1][0];
    }

    public float Get_Gun_EXP()
    {
        return Get_Gun_CurrentEXP() / Get_Gun_TotalEXP();
    }

    public string Get_Gun_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return Gun_SkillName_kr;
        }
        else
        {
            return Gun_SkillName;
        }
    }

    // ���� ����, ���� �� ���� �ݿ��Ǵ� ȿ�� ����
    public void Set_Gun_Equipping_Effect(bool IsEquipping)
    {
        // ���� ���� �޾Ƽ� ��Ȯ�� �� ���

        if (Gun_SkillName == "Aiming")
        {
            // ��Ȯ��
            Player_main.player_main.playerSkill_ActivationProbability.Set_Gun_Accuracy(Gun_Level);
            // ���е�
            Player_main.player_main.playerSkill_ActivationProbability.Set_Precision(Gun_Level);
            // ��Ÿ�
            Player_main.player_main.playerSkill_ActivationProbability.Set_Range(Gun_Level);
            // �߻簢��
            Player_main.player_main.playerSkill_ActivationProbability.Set_Launch_Angle(Gun_Level);
            // ���ؽð� ����
            Player_main.player_main.playerSkill_ActivationProbability.Set_Time_for_aiming(Gun_Level);
        }
        else if (Gun_SkillName == "Reloading")
        {
            // ������ �ð� ����
            Player_main.player_main.playerSkill_ActivationProbability.Set_Time_for_reloading(Gun_Level);
        }
    }
}
public class PlayerCraftingSkill_Level  // ���, �丮, ���, �Ƿ�, �������
{
    string C_SkillName = "";
    string C_SkillName_kr = "";
    float C_Level = 0f;
    float C_Min_Level = 0f;
    float C_Max_Level = 10f;

    public bool Change_Multiplier = true;
    float C_Additional_points_through_Books = 1f;

    float C_EXP = 0f;
    List<float>[] C_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerCraftingSkill_Level(float initialLevel, string skillname, string skillname_kr)
    {
        if (initialLevel >= C_Min_Level && initialLevel <= C_Max_Level)
        {
            C_SkillName = skillname;
            C_SkillName_kr = skillname_kr;
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

        // _TotalEXP�� ��
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
        C_EXP = C_EXP + (exp * C_Additional_points_through_Books);
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

    public void Set_C_Level(float Start_Level)
    {
        C_Level = Start_Level;
    }

    public float Get_C_CurrentEXP()
    {
        return C_EXP;
    }

    public float Get_C_TotalEXP()
    {
        if (C_Level < 10)
            return C_expRequirements[(int)C_Level][0];
        else
            return C_expRequirements[(int)C_Level - 1][0];
    }

    public float Get_C_EXP()
    {
        return Get_C_CurrentEXP() / Get_C_TotalEXP();
    }

    public string Get_C_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return C_SkillName_kr;
        }
        else
        {
            return C_SkillName;
        }
    }

    public float Get_C_Multiplier()
    {
        return C_Additional_points_through_Books;
    }

    public void Set_C_Books_Point(Item_Literature Book)  // skillbook �϶� ȣ��
    {
        switch (Book.Literature_Level)
        {
            case 0:
                break;
            case 1:
                if (C_Level == 1 || C_Level == 2)
                    C_Additional_points_through_Books = 3f;
                else
                    AboutBooks(true);
                break;
            case 2:
                if (C_Level == 3 || C_Level == 4)
                    C_Additional_points_through_Books = 5f;
                else if (C_Level < 3)
                    AboutBooks(false);
                else
                    AboutBooks(true);
                break;
            case 3:
                if (C_Level == 5 || C_Level == 6)
                    C_Additional_points_through_Books = 8f;
                else if (C_Level < 5)
                    AboutBooks(false);
                else
                    AboutBooks(true);
                break;
            case 4:
                if (C_Level == 7 || C_Level == 8)
                    C_Additional_points_through_Books = 12f;
                else if (C_Level < 7)
                    AboutBooks(false);
                else
                    AboutBooks(true);
                break;
            case 5:
                if (C_Level == 9 || C_Level == 10)
                    C_Additional_points_through_Books = 16f;
                else
                    AboutBooks(false);
                break;
            default: break;
        }

    }

    public void AboutBooks(bool over)
    {
        if(over)
            Debug.Log("������� ���� ����");  // å �� ����
        else
            Debug.Log("�̹� �� �ƴ� ������");  // å�� �б������� �ƹ� ��ȭ ����
    }

    /*  Magazine  
    12. Good Cooking Magazine Vol. 1 : ����ũ ����, ���� ����, ���ݸ�Ĩ��Ű ����, ���ݸ���Ű ����, ��Ʈ����Ű ����, ��Ʈ�극����Ű ����, ������Ű ���� �����
    13. Good Cooking Magazine Vol. 2 :  ��, ����, �ٰ�Ʈ, ��Ŷ �����
    14. Electronics Magazine Vol. 1 :  ������ v1, v2, v3 �����
    15. Electronics Magazine Vol. 2 :  Ÿ�̸� �����, �ٸ� ���ǿ� Ÿ�̸� �ޱ�
    16. Electronics Magazine Vol. 3 :  ��Ǽ��� v1, v2, v3 �����
    17. Electronics Magazine Vol. 4 :  ���� Ʈ���� �����, �ٸ� ���ǿ� ���� Ʈ���� �ޱ�
    18. Engineer Magazine Vol. 1 :  ���� �߻��� �����
    19. Engineer Magazine Vol. 2 :  ����ź �����
    20. The Farming Magazine :  ������ ��������, ������ �������� �����
    21. Angler USA Magazine Vol. 1 :  ���ô� �����, ���ô� ��ġ��
    22. Angler USA Magazine Vol. 2 :  ���� �׹� �����, ���峭 ���� �׹����� ���̾� ������
    23. The Herbalist :  ���� �ִ� ����, ���� �ĺ� ����
    24. How to Use Generators :  ������ ����
    25. The Hunter Magazine Vol. 1 :  ���׾� Ʈ�� �����
    26. The Hunter Magazine Vol. 2 :  ��������1 �����, ��ƽ Ʈ�� �����
    27. The Hunter Magazine Vol. 3 :  �Լ�����2 �����,  ������Ʈ�� �����
    28. Laines Auto Manual - Commercial Models :  ǥ�� ���� ���� �������� ����
    29. Laines Auto Manual - Performance Models :  ���� ���� ���� �������� ����
    30. Laines Auto Manual - Standard Models :  ������ ���� ���� �������� ����
    31. The Metalwork Magazine Vol. 1 :  �ݼӺ� �����, �ݼ����� �����
    32. The Metalwork Magazine Vol. 2 :  �ݼ������̳� �����
    33. The Metalwork Magazine Vol. 3 :  �ݼӿ�Ÿ�� �����
    34. The Metalwork Magazine Vol. 4 :  �ݼ��� �����, �����ݼ��� �����
    35. Guerilla Radio Vol. 1 :  �ӽ� ���� ����
    36. Guerilla Radio Vol. 2 :  �ӽ� ������ ����
    37. Guerilla Radio Vol. 3 :  �ӽ� �� ���� ����
     */



}

public class PlayerSurvivalSkill_Level  // ���, ����, ä��, �¸�
{
    string S_SkillName = "";
    string S_SkillName_kr = "";
    float S_Level = 0f;
    float S_Min_Level = 0f;
    float S_Max_Level = 10f;

    public bool Change_Multiplier = true;
    float S_Additional_points_through_Books = 1f;

    float S_EXP = 0f;
    public float S_Exp_characteristic = 1f;
    List<float>[] S_expRequirements;
    // ���� 0 ~ 10
    // ������ �ʿ� ����ġ

    public PlayerSurvivalSkill_Level(float initialLevel, string skillname, string skillname_kr)
    {
        if (initialLevel >= S_Min_Level && initialLevel <= S_Max_Level)
        {
            S_SkillName = skillname;
            S_SkillName_kr = skillname_kr;
            S_Level = initialLevel;
            InitializeExpRequirements();

            if (S_SkillName == "Hunting")
            {

            }
            else if (S_SkillName == "Fishing")
            {

            }
            else if (S_SkillName == "Foraging")
            {

            }
            else if (S_SkillName == "Riding")
            {

            }

        }
    }

    void InitializeExpRequirements()
    {
        S_expRequirements = new List<float>[10];
        for (int i = 0; i < S_expRequirements.Length; i++)
        {
            S_expRequirements[i] = new List<float>();
        }

        // _TotalEXP�� ��
        S_expRequirements[0].Add(75f);  // Level 0 -> 1
        S_expRequirements[1].Add(150f);  // Level 1 -> 2
        S_expRequirements[2].Add(300f);  // Level 2 -> 3
        S_expRequirements[3].Add(750f);  // Level 3 -> 4
        S_expRequirements[4].Add(1500f);  // Level 4 -> 5
        S_expRequirements[5].Add(3000f);  // Level 5 -> 6
        S_expRequirements[6].Add(4500f);  // Level 6 -> 7
        S_expRequirements[7].Add(6000f);  // Level 7 -> 8
        S_expRequirements[8].Add(7500f);  // Level 8 -> 9
        S_expRequirements[9].Add(9000f);  // Level 9 -> 10
    }

    public void SetEXP(float exp)
    {
        S_EXP = S_EXP + (exp * S_Additional_points_through_Books * S_Exp_characteristic);
        if (S_Level < S_Max_Level && S_EXP >= S_expRequirements[(int)S_Level][0])
        {
            S_EXP -= S_expRequirements[(int)S_Level][0];
            S_Level++;

            if (S_SkillName == "Hunting")
            {

            }
            else if (S_SkillName == "Fishing")
            {

            }
            else if (S_SkillName == "Foraging")
            {

            }
            else if (S_SkillName == "Riding")
            {

            }


        }
    }

    public float Get_S_Level()
    {
        return S_Level;
    }

    public void Set_S_Level(float Start_Level)
    {
        S_Level = Start_Level;
    }

    public float Get_S_CurrentEXP()
    {
        return S_EXP;
    }

    public float Get_S_TotalEXP()
    {
        if (S_Level < 10)
            return S_expRequirements[(int)S_Level][0];
        else
            return S_expRequirements[(int)S_Level - 1][0];
    }

    public float Get_S_EXP()
    {
        return Get_S_CurrentEXP() / Get_S_TotalEXP();
    }

    public string Get_S_SkillName()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return S_SkillName_kr;
        }
        else
        {
            return S_SkillName;
        }
    }

    public float Get_S_Multiplier()
    {
        return S_Additional_points_through_Books;
    }

    public void Set_S_Books_Point(int Book_level)
    {
        if (Book_level > S_Level)
        {
            S_Additional_points_through_Books = 1f;
            Debug.Log("������� ���� ����");
            // å �� ����
        }
        else if (Book_level < S_Level)
        {
            S_Additional_points_through_Books = 1f;
            Debug.Log("�̹� �� �ƴ� ������");
            // å�� �б������� �ƹ� ��ȭ ����
        }
        else
        {
            switch (Book_level)
            {
                case 0:
                    break;
                case 1:
                    S_Additional_points_through_Books = 3f;
                    break;
                case 2:
                    S_Additional_points_through_Books = 5f;
                    break;
                case 3:
                    S_Additional_points_through_Books = 8f;
                    break;
                case 4:
                    S_Additional_points_through_Books = 12f;
                    break;
                case 5:
                    S_Additional_points_through_Books = 16f;
                    break;
                default: break;
            }
        }

    }
}