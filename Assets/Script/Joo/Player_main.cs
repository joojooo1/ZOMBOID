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
    // 직업특성 등 반영안된 기본 능력치 (임의로 설정)
    float Player_Max_Health = 100.0f;  // 체력 ( Fitness_Level: 5 / Strength_Level: 5 )
    float Player_Min_Health = 0f;
    float Player_current_Health = 0f;
    float Weight = 83.0f; // 체중
    float Calories = 50.0f; // 칼로리 0 - 100
    float Temperature = 50.0f; // 온도 0 - 100

    float Attack_Power = 8.0f; // 공격력
    float Evasion = 0.15f;  // 회피율

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
        if (Is_Equipping_Weapons)  // 무기를 착용하는 경우 호출
        {
            //Set_Attack_Power_for_Equipping_Weapons(Weapon_type weapon, Is_Equipping_Weapons)
        }

        // test 함수 -------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Z))  // 무기 스킬 Level-up
        {
            Skill.Axe_Level.SetEXP(9000);

        }
        else if (Input.GetKeyDown(KeyCode.X))  // 무기 착용 시
        {
            Is_Equipping_Weapons = true;
            Set_Attack_Power_for_Equipping_Weapons(Weapon_type.Axe, Is_Equipping_Weapons);
        }
        else if (Input.GetKeyDown(KeyCode.C))  // 무기 해제 시
        {
            Is_Equipping_Weapons = false;
            Set_Attack_Power_for_Equipping_Weapons(Weapon_type.Axe, Is_Equipping_Weapons);
        }
        // ------------------------------------------------------------- test 함수 


        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * Playermovement_speed;

        transform.position = pos;


    }


    public PlayerSkill_ActivationProbability playerSkill_ActivationProbability = new PlayerSkill_ActivationProbability();
    // test 함수 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
    // -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- test 함수 

    public void Set_Is_Equipping_Weapons()
    {
        if (Is_Equipping_Weapons)
            Is_Equipping_Weapons = false;
        else
            Is_Equipping_Weapons = true;
    }

    void Set_Attack_Power_for_Equipping_Weapons(Weapon_type weapon, bool Is_Equipping_Weapons)  // 무기를 끼면 함수 호출
    {
        // 무기 Script 구현사항
        // 무기별 타입
        // 무기별 공격력
        // 무기별 내구도

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


    // 공격받을 때 순서
    // 1. 공격 받으면 밀쳐낼 확률 계산
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
            // 밀쳐낸 애니메이션
        }
    }

    // 못 밀쳐냈을때
    // 2. 공격받을 신체 위치 확률 계산
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

    // 2. 좀비의 공격 패턴 확률 계산
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
                // 타격(피해o & 상처x)

                //Zombie_Attack_power * Attack_point

                break;
            case Zombie_Attack_Pattern.Scratches:
                // 긁힘(7% 확률로 감염)
                break;
            case Zombie_Attack_Pattern.Lacerations:
                // 찢김(25% 확률로 감염)
                break;
            case Zombie_Attack_Pattern.Bites:
                // 물림(100% 확률로 감염)
                break;
            default:
                break;

        }
    }


    void Calculate_damage_from_Zombie(string Attack_point, float Zombie_Attack_power)  // Zombie -> Player 공격
    {
        // Zombie
        // 공격력


        // player
        // 방어력
        // 막을 확률
        // 못막았을때 회피할 확률
        // 
    }

    void Calculate_damage_to_Zombie()  // Player -> Zombie 공격
    {
        // player
        // 기본 공격력
        // 무기 착용 시 추가되는 공격력
        // + 근접 무기일 경우 근접 공격력
        // + 총기 사용시 조준 등 반영
        // 치명타 확률

        /* 참고사항

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
 아직 미구현 사항

 1. 각 스킬마다 경험치 오르는 조건




 */