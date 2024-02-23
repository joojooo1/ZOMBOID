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

public enum Zombie_Attack_Pattern
{
    punches = 0,
    Scratches = 1,
    Lacerations = 2,
    Bites = 3
}

public class Player_main : MonoBehaviour
{
    public static Player_main player_main;

    public PlayerInventory_Weight inven = new PlayerInventory_Weight();
    PlayerSkill Skill;

    public PlayerSkill_ActivationProbability playerSkill_ActivationProbability = new PlayerSkill_ActivationProbability();
    public PlayerState playerState = new PlayerState();
    public Player_HP player_HP = new Player_HP();
    public Player_Moodles playerMoodles = new Player_Moodles();

    /* --------------------------------------------------------------------------------- */
    // ����Ư�� �� �ݿ��ȵ� �⺻ �ɷ�ġ (���Ƿ� ����)
    [SerializeField] float Weight = 83.0f; // ü��
    [SerializeField] float Calories = 50.0f; // Į�θ� 0 - 100
    [SerializeField] float Temperature = 50.0f; // �µ� 0 - 100

    [SerializeField] float Attack_Power = 8.0f; // ���ݷ�
    [SerializeField] float Evasion = 0.15f;  // ȸ����
    [SerializeField] float Moving_Speed = 3f;  // �̵��ӵ�

    public bool Is_Equipping_Weapons = false;
    public bool Is_Aiming = false;
    /* --------------------------------------------------------------------------------- */

    void Awake()
    {
        player_main = this;

        Skill = GetComponent<PlayerSkill>();
        
    }

    void Update()
    {
        Set_testText(playerMoodles.Moodle_Endurance.Get_Moodle_current_step());
        if (Is_Equipping_Weapons)  // ���⸦ �����ϴ� ��� ȣ��
        {
            //Set_Attack_Power_for_Equipping_Weapons(Weapon_type weapon, Is_Equipping_Weapons)
        }

        // test �Լ� -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))  // �������� ���ݴ��Ҷ�
        {
            playerMoodles.Moodle_Endurance.Set_Moodles_state(20f);
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
        pos += input * Time.deltaTime * Get_Moving_Speed();

        transform.position = pos;

        //if (Timer > 3.0f)
        //{
        //    // 3�ʸ��� �Ƿε� +3.0f * �Ƿε� ���� ���� (���Ƿ� ����)
        //    // Moodle_Tired.Set_Moodles_state();
        //    Timer = 0.0f;
        //}
    }

    // test �Լ� --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public UnityEngine.UI.Text[] textText;
    public void Set_testText(float Level)
    {
        textText[0].text = "Melee_Attack_Power_Ratio: " + playerSkill_ActivationProbability.Get_Melee_Attack_Power_Ratio().ToString();
        textText[1].text = "Attack_Speed: " + playerSkill_ActivationProbability.Get_Attack_Speed().ToString();
        textText[2].text = "Moving_Speed: " + Get_Moving_Speed().ToString();
        textText[3].text = "Probability_of_Falling: " + playerSkill_ActivationProbability.Get_Probability_of_Falling().ToString();
        textText[4].text = "Probability_of_Crossing_a_High_Wall: " + playerSkill_ActivationProbability.Get_Probability_of_Crossing_a_High_Wall().ToString();
        textText[5].text = "Chance_of_Blocking_zombie_frontal_attack: " + playerSkill_ActivationProbability.Get_Chance_of_Blocking_zombie_frontal_attack().ToString();
        textText[6].text = playerMoodles.Moodle_Endurance.Get_current_state_to_string();
        textText[7].text = playerMoodles.Moodle_Endurance.Get_current_detail_state_to_string();
    }
    // -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- test �Լ� 

    public float Get_Moving_Speed()
    {
        if (Is_Aiming)
            return Moving_Speed * playerSkill_ActivationProbability.Get_Movement_Speed_while_Aiming();
        else
            return Moving_Speed;
    }

    public void Set_Moving_Speed_forMoodle(float Speed_rate)
    {
        Moving_Speed = Moving_Speed * ( 1 - Speed_rate );
    }

    public float Get_Evasion()
    {
        return Evasion + playerSkill_ActivationProbability.Get_Injury_chance();
    }

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
    public void Calculate_HitForce(bool Zombie_Attack, string Zom_Type, bool IsBack, bool IsDown)  // ���� -> �÷��̾�: ������ ���� ��������, ������ ����, �Ĺ� ����, ����� ����
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) > playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculating_Probability_of_Injury_Location(Zom_Type, IsBack, IsDown);
        }
        else
        {
            Debug.Log("Miss !!");
            // ���ĳ� �ִϸ��̼�
        }
    }

    // �� ���ĳ�����
    // 2. ���ݹ��� ��ü ��ġ Ȯ�� ���

    void Calculating_Probability_of_Injury_Location(string Zom_Type, bool IsBack, bool IsDown)  // ���� -> �÷��̾�: ������ ����, �Ĺ� ����
    {
        Player_body_Location Attack_point  = new Player_body_Location(0);
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (!IsBack && !IsDown)  // ���ִ� �������� ���鿡�� ���� ���ϴ� ���
        {
            if (randomNumber >= 0 && randomNumber < 12)  // 12%
            {
                Attack_point = playerState.Left_forearm;
            }
            else if (randomNumber >= 12 && randomNumber < 24)  // 12%
            {
                Attack_point = playerState.Right_forearm;
            }
            else if (randomNumber >= 24 && randomNumber < 35)  // 11%
            {
                Attack_point = playerState.Left_upper_arm;
            }
            else if (randomNumber >= 35 && randomNumber < 46)  // 11%
            {
                Attack_point = playerState.Right_upper_arm;
            }
            else if (randomNumber >= 46 && randomNumber < 55)  // 9%
            {
                Attack_point = playerState.Groin;
            }
            else if (randomNumber >= 55 && randomNumber < 63)  // 8%
            {
                Attack_point = playerState.Left_hand;
            }
            else if (randomNumber >= 63 && randomNumber < 71)  // 8%
            {
                Attack_point = playerState.Right_hand;
            }
            else if (randomNumber >= 71 && randomNumber < 78)  // 7%
            {
                Attack_point = playerState.Neck;
            }
            else if (randomNumber >= 78 && randomNumber < 84)  // 6%
            {
                Attack_point = playerState.upper_torso;
            }
            else if (randomNumber >= 84 && randomNumber < 90)  // 6%
            {
                Attack_point = playerState.Lower_torso;
            }
            else if (randomNumber >= 90 && randomNumber < 94)  // 4%
            {
                Attack_point = playerState.Head;
            }
            else if (randomNumber >= 94 && randomNumber < 95)  // 1%
            {
                Attack_point = playerState.Left_thigh;
            }
            else if (randomNumber >= 95 && randomNumber < 96)  // 1%
            {
                Attack_point = playerState.Right_thigh;
            }
            else if (randomNumber >= 96 && randomNumber < 97)  // 1%
            {
                Attack_point = playerState.Left_shin;
            }
            else if (randomNumber >= 97 && randomNumber < 98)  // 1%
            {
                Attack_point = playerState.Right_shin;
            }
            else if (randomNumber >= 98 && randomNumber < 99)  // 1%
            {
                Attack_point = playerState.Left_foot;
            }
            else if (randomNumber >= 99 && randomNumber < 100)  // 1%
            {
                Attack_point = playerState.Right_foot;
            }
        }
        else if (IsBack && !IsDown) // ���ִ� �������� �Ĺ濡�� ���� ���ϴ� ���
        {
            if (randomNumber >= 0 && randomNumber < 50)  // 7% -> 50%
            {
                Attack_point = playerState.Neck;
            }
            else if (randomNumber >= 50 && randomNumber < 90)  // 4% -> 40%
            {
                Attack_point = playerState.Head;
            }
            else if (randomNumber >= 90 && randomNumber < 92)  // 6% -> 2%
            {
                Attack_point = playerState.upper_torso;
            }
            else if (randomNumber >= 92 && randomNumber < 94)  // 6% -> 2%
            {
                Attack_point = playerState.Lower_torso;
            }
            else if (randomNumber >= 94 && randomNumber < 95)  // 8% -> 1%
            {
                Attack_point = playerState.Left_hand;
            }
            else if (randomNumber >= 95 && randomNumber < 96)  // 8% -> 1%
            {
                Attack_point = playerState.Right_hand;
            }
            else if (randomNumber >= 96 && randomNumber < 97)  // 11% -> 1%
            {
                Attack_point = playerState.Left_upper_arm;
            }
            else if (randomNumber >= 97 && randomNumber < 98)  // 11% -> 1%
            {
                Attack_point = playerState.Right_upper_arm;
            }
            else if (randomNumber >= 98 && randomNumber < 99)  // 12% -> 1%
            {
                Attack_point = playerState.Left_forearm;
            }
            else if (randomNumber >= 99 && randomNumber < 100)  // 12% -> 1%
            {
                Attack_point = playerState.Right_forearm;
            }
        }
        else  // ���ٴϴ� �������� ���� ���ϴ� ���
        {
            if (randomNumber >= 0 && randomNumber < 17)  // 1% -> 17%
            {
                Attack_point = playerState.Left_foot;
            }
            else if (randomNumber >= 17 && randomNumber < 34)  // 1% -> 17%
            {
                Attack_point = playerState.Right_foot;
            }
            else if (randomNumber >= 34 && randomNumber < 49)  // 1% -> 15%
            {
                Attack_point = playerState.Left_shin;
            }
            else if (randomNumber >= 49 && randomNumber < 64)  // 1% -> 15%
            {
                Attack_point = playerState.Right_shin;
            }
            else if (randomNumber >= 64 && randomNumber < 77)  // 1% -> 13%
            {
                Attack_point = playerState.Left_thigh;
            }
            else if (randomNumber >= 77 && randomNumber < 90)  // 1% -> 13%
            {
                Attack_point = playerState.Right_thigh;
            }
            else if (randomNumber >= 90 && randomNumber < 100)  // 10%
            {
                Attack_point = playerState.Groin;
            }
        }
        
        Calculating_the_Probability_of_Zombie_Attack_Pattern(Attack_point, Zom_Type, IsBack);
    }

    // 3. ������ ���� ���� Ȯ�� ���

    void Calculating_the_Probability_of_Zombie_Attack_Pattern(Player_body_Location Attack_point, string Zom_Type, bool IsBack)  // ���� -> �÷��̾�: ���� ���ϴ� ��ġ, ������ ����, �Ĺ� ����
    {
        System.Random rand = new System.Random();
        int Rand_pattern = rand.Next(100);


        if (!IsBack)  // �տ��� ���� ���ϴ� ���
        {
            if (Rand_pattern >= 0 && Rand_pattern < 25)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.punches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 25 && Rand_pattern < 50)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Scratches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 50 && Rand_pattern < 75)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Lacerations, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 75 && Rand_pattern < 100)  // 25%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Bites, Zom_Type, IsBack);
            }
        }
        else  // �ڿ��� ���� ���ϴ� ���
        {
            if (Rand_pattern >= 0 && Rand_pattern < 70)  // 70%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Bites, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 70 && Rand_pattern < 80)  // 10%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.punches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 80 && Rand_pattern < 90)  // 10%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Scratches, Zom_Type, IsBack);
            }
            else if (Rand_pattern >= 90 && Rand_pattern < 100)  // 10%
            {
                Attack_point.Set_Body_state(Zombie_Attack_Pattern.Lacerations, Zom_Type, IsBack);
            }
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