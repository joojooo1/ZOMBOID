using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;


public enum Weapon_type
{
    Axe = 0,
    LongBlunt = 1,
    ShortBlunt = 2,
    LongBlade = 3,
    ShortBlade = 4,
    Spear = 5,
    Gun = 6
}

public enum Player_body_Location
{
    Left_hand = 0,
    Right_hand = 1,
    Left_forearm = 2,
    Right_forearm = 3,
    Left_upper_arm = 4,
    Right_upper_arm = 5,
    upper_torso = 6,
    Lower_torso = 7,
    Head = 8,
    Neck = 9,
    Groin = 10,
    Left_thigh = 11,
    Right_thigh = 12,
    Left_shin = 13,
    Right_shin = 14,
    Left_foot = 15,
    Right_foot = 16
}

public class Player_main : MonoBehaviour
{
    public static Player_main player_main;

    PlayerInventory inven = new PlayerInventory();
    PlayerSkill Skill;

    /* --------------------------------------------------------------------------------- */
    // ����Ư�� �� �ݿ��ȵ� �⺻ �ɷ�ġ (���Ƿ� ����)
    float Player_Max_Health = 100.0f;  // ü�� ( Fitness_Level: 5 / Strength_Level: 5 )
    float Player_Min_Health = 0f;
    float Player_current_Health = 0f;
    float Weight = 83.0f; // ü��
    float Calories = 50.0f; // Į�θ� 0 - 100
    float Temperature = 50.0f; // �µ� 0 - 100

    float Attack_Power = 8.0f; // ���ݷ�
    float Evasion = 0.15f;  // ȸ����

    public bool Is_Equipping_Weapons = false;
    /* --------------------------------------------------------------------------------- */

    void Awake()
    {
        player_main = this;

        Skill = GetComponent<PlayerSkill>();
        Player_current_Health = Player_Max_Health;
    }

    float Playermovement_speed = 1.0f;

    void Update()
    {
        if (Is_Equipping_Weapons)  // ���⸦ �����ϴ� ��� ȣ��
        {
            //Set_Attack_Power_for_Equipping_Weapons(Weapon_type weapon, Is_Equipping_Weapons)
        }

        // test �Լ� -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))  // ���� ��ų Level-up
        {
            Skill.Axe_Level.SetEXP(9000);

        }
        else if (Input.GetKeyDown(KeyCode.X))  // ���� ���� ��
        {
            Is_Equipping_Weapons = true;
            Set_Attack_Power_for_Equipping_Weapons(Weapon_type.Axe, Is_Equipping_Weapons);
        }
        else if (Input.GetKeyDown(KeyCode.C))  // ���� ���� ��
        {
            Is_Equipping_Weapons = false;
            Set_Attack_Power_for_Equipping_Weapons(Weapon_type.Axe, Is_Equipping_Weapons);
        }
        // ------------------------------------------------------------- test �Լ� 


        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * Playermovement_speed;

        transform.position = pos;


    }


    public PlayerSkill_ActivationProbability playerSkill_ActivationProbability = new PlayerSkill_ActivationProbability();
    // test �Լ� --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public UnityEngine.UI.Text[] textText;
    public void Set_testText(float Level)
    {
        textText[0].text = "Level: " + Level.ToString();
        textText[1].text = "Increase_in_Attack_Power: " + playerSkill_ActivationProbability.Get_Increase_in_Attack_Power().ToString();
        textText[2].text = "Attack_Speed: " + playerSkill_ActivationProbability.Get_Attack_Speed().ToString();
        textText[3].text = "Critical_Hit_Chance: " + playerSkill_ActivationProbability.Get_Critical_Hit_Chance().ToString();
        textText[4].text = "Block_chance: " + playerSkill_ActivationProbability.Get_Block_chance().ToString();
        textText[5].text = "Injury_chance: " + playerSkill_ActivationProbability.Get_Injury_chance().ToString();
        //textText[6].text = "Block_chance: " + playerSkill_ActivationProbability.Get_Block_chance().ToString();
        //textText[7].text = "Probability_of_Crossing_a_High_Wall: " + playerSkill_ActivationProbability.Get_Probability_of_Crossing_a_High_Wall().ToString();
    }
    // -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- test �Լ� 

    public void Set_Is_Equipping_Weapons()
    {
        if (Is_Equipping_Weapons)
            Is_Equipping_Weapons = false;
        else
            Is_Equipping_Weapons = true;
    }

    void Set_Attack_Power_for_Equipping_Weapons(Weapon_type weapon, bool Is_Equipping_Weapons)  // ���⸦ ���� �Լ� ȣ��
    {
        // ���� Script ��������
        // ���⺰ Ÿ��
        // ���⺰ ���ݷ�
        // ���⺰ ������

        switch (weapon)
        {
            case Weapon_type.Axe:
                Skill.Axe_Level.Set_Weapon_Equipping_Effect(Is_Equipping_Weapons);
                break;
            case Weapon_type.LongBlunt:
                Skill.LongBlunt_Level.Set_Weapon_Equipping_Effect(Is_Equipping_Weapons);
                break;
            case Weapon_type.ShortBlunt:
                Skill.ShortBlunt_Level.Set_Weapon_Equipping_Effect(Is_Equipping_Weapons);
                break;
            case Weapon_type.LongBlade:
                Skill.LongBlade_Level.Set_Weapon_Equipping_Effect(Is_Equipping_Weapons);
                break;
            case Weapon_type.ShortBlade:
                Skill.ShortBlade_Level.Set_Weapon_Equipping_Effect(Is_Equipping_Weapons);
                break;
            case Weapon_type.Spear:
                Skill.Spear_Level.Set_Weapon_Equipping_Effect(Is_Equipping_Weapons);
                break;
            default:
                break;
        }

    }


    // ���ݹ��� �� ����
    // 1. ���� ������ ���ĳ� Ȯ�� ���
    void Calculate_HitForce(bool Zombie_Attack)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) > playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculating_Probability_of_Injury_Location();
        }
        else
        {
            // ���ĳ� �ִϸ��̼�
        }
    }

    // �� ���ĳ�����
    // 2. ���ݹ��� ��ü ��ġ Ȯ�� ���
    void Calculating_Probability_of_Injury_Location()
    {
        Player_body_Location Attack_point = 0;
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if(randomNumber >= 0 && randomNumber < 8)  // 8%
        {
            Attack_point = Player_body_Location.Left_hand;
        }
        else if (randomNumber >= 8 && randomNumber < 16)  // 8%
        {
            Attack_point = Player_body_Location.Right_hand;
        }
        else if (randomNumber >= 16 && randomNumber < 28)  // 12%
        {
            Attack_point = Player_body_Location.Left_forearm;
        }
        else if (randomNumber >= 28 && randomNumber < 40)  // 12%
        {
            Attack_point = Player_body_Location.Right_forearm;
        }
        else if (randomNumber >= 40 && randomNumber < 51)  // 11%
        {
            Attack_point = Player_body_Location.Left_upper_arm;
        }
        else if (randomNumber >= 51 && randomNumber < 62)  // 11%
        {
            Attack_point = Player_body_Location.Right_upper_arm;
        }
        else if (randomNumber >= 62 && randomNumber < 68)  // 6%
        {
            Attack_point = Player_body_Location.upper_torso;
        }
        else if (randomNumber >= 68 && randomNumber < 74)  // 6%
        {
            Attack_point = Player_body_Location.Lower_torso;
        }
        else if (randomNumber >= 74 && randomNumber < 78)  // 4%
        {
            Attack_point = Player_body_Location.Head;
        }
        else if (randomNumber >= 78 && randomNumber < 85)  // 7%
        {
            Attack_point = Player_body_Location.Neck;
        }
        else if (randomNumber >= 85 && randomNumber < 94)  // 9%
        {
            Attack_point = Player_body_Location.Groin;
        }
        else if (randomNumber >= 94 && randomNumber < 95)  // 1%
        {
            Attack_point = Player_body_Location.Left_thigh;
        }
        else if (randomNumber >= 95 && randomNumber < 96)  // 1%
        {
            Attack_point = Player_body_Location.Right_thigh;
        }
        else if (randomNumber >= 96 && randomNumber < 97)  // 1%
        {
            Attack_point = Player_body_Location.Left_shin;
        }
        else if (randomNumber >= 97 && randomNumber < 98)  // 1%
        {
            Attack_point = Player_body_Location.Right_shin;
        }
        else if (randomNumber >= 98 && randomNumber < 99)  // 1%
        {
            Attack_point = Player_body_Location.Left_foot;
        }
        else if (randomNumber >= 99 && randomNumber < 100)  // 1%
        {
            Attack_point = Player_body_Location.Right_foot;
        }

        Calculating_the_Probability_of_Zombie_Attack_Pattern(Attack_point);
    }

    // 2. ������ ���� ���� Ȯ�� ���
    enum Zombie_Attack_Pattern
    {
        punches = 0,
        Scratches = 1,
        Lacerations = 2,  
        Bites = 3  
    }

    void Calculating_the_Probability_of_Zombie_Attack_Pattern(Player_body_Location Attack_point)
    {
        System.Random rand = new System.Random();
        Zombie_Attack_Pattern Rand_pattern = (Zombie_Attack_Pattern)rand.Next(4);

        float Zombie_Attack_power = 0.0f;

        switch (Rand_pattern)
        {
            case Zombie_Attack_Pattern.punches:
                // Ÿ��(����o & ��óx)

                //Zombie_Attack_power * Attack_point

                break;
            case Zombie_Attack_Pattern.Scratches:
                // ����(7% Ȯ���� ����)
                break;
            case Zombie_Attack_Pattern.Lacerations:
                // ����(25% Ȯ���� ����)
                break;
            case Zombie_Attack_Pattern.Bites:
                // ����(100% Ȯ���� ����)
                break;
            default:
                break;

        }
    }


    void Calculate_damage_from_Zombie(string Attack_point, float Zombie_Attack_power)  // Zombie -> Player ����
    {
        // Zombie
        // ���ݷ�


        // player
        // ����
        // ���� Ȯ��
        // ���������� ȸ���� Ȯ��
        // 
    }

    void Calculate_damage_to_Zombie()  // Player -> Zombie ����
    {
        // player
        // �⺻ ���ݷ�
        // ���� ���� �� �߰��Ǵ� ���ݷ�
        // + ���� ������ ��� ���� ���ݷ�
        // + �ѱ� ���� ���� �� �ݿ�
        // ġ��Ÿ Ȯ��

        /* �������

          1. Get damage from weapon/wielder.
          2. If damage is more than 0.7, reduce to 0.7 (unarmed).
          3. damage *= 0.3+AxeLevel*0.1
          4. damage *= 0.3+BluntLevel*0.1
          5. critical chance = weapon.critchance + weapon.AimingPerkCritModifier * (AimingLevel/2)
          6. damage = damage*2 (Axe)
 
         */

    }
}

/*
 ���� �̱��� ����

 1. �� ��ų���� ����ġ ������ ����




 */