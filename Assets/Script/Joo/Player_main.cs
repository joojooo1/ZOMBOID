using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

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
    bool Equipping_Weapons = false;  // 시작시 무기 착용 X
    /* --------------------------------------------------------------------------------- */

    public UnityEngine.UI.Text textText;

    void Start()
    {
        Skill = GetComponent<PlayerSkill>();
        Player_current_Health = Player_Max_Health;
    }

    float Playermovement_speed = 1.0f;

    void Update()
    {
        /*
        if ()  // 무기를 착용하는 경우  ( 미정 )
        {
            Equipping_Weapons = true;
            
        }
        */

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * Playermovement_speed;

        transform.position = pos;


    }

    // test 함수
    private void OnCollisionEnter(Collision collision)
    {
        Skill.Fitness_Level.SetEXP(2000);
    }
    public void Set_testText(float Level)
    {
        textText.text = Level.ToString();
    }

    // 공격받을 때 순서
    // 1. 공격 받으면 밀쳐낼 확률 계산
    void Calculate_HitForce(string Attack_point, float Zombie_Attack_power)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if (((float)randomNumber / 100) > PlayerSkill_ActivationProbability.playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculating_Probability_of_Injury_Location(Zombie_Attack_power);
        }
    }

    // 못 밀쳐냈을때
    // 2. 공격받을 신체 위치 확률 계산
    void Calculating_Probability_of_Injury_Location(float Zombie_Attack_power)
    {
        string Attack_point = "";
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if(randomNumber >= 0 && randomNumber < 8)  // 8%
        {
            Attack_point = "Left_hand";
        }
        else if (randomNumber >= 8 && randomNumber < 16)  // 8%
        {
            Attack_point = "Right_hand";
        }
        else if (randomNumber >= 16 && randomNumber < 28)  // 12%
        {
            Attack_point = "Left_forearm";
        }
        else if (randomNumber >= 28 && randomNumber < 40)  // 12%
        {
            Attack_point = "Right_forearm";
        }
        else if (randomNumber >= 40 && randomNumber < 51)  // 11%
        {
            Attack_point = "Left_upper_arm";
        }
        else if (randomNumber >= 51 && randomNumber < 62)  // 11%
        {
            Attack_point = "Right_upper_arm";
        }
        else if (randomNumber >= 62 && randomNumber < 68)  // 6%
        {
            Attack_point = "upper_torso";
        }
        else if (randomNumber >= 68 && randomNumber < 74)  // 6%
        {
            Attack_point = "Lower_torso";
        }
        else if (randomNumber >= 74 && randomNumber < 78)  // 4%
        {
            Attack_point = "Head";
        }
        else if (randomNumber >= 78 && randomNumber < 85)  // 7%
        {
            Attack_point = "Neck";
        }
        else if (randomNumber >= 85 && randomNumber < 94)  // 9%
        {
            Attack_point = "Groin";
        }
        else if (randomNumber >= 94 && randomNumber < 95)  // 1%
        {
            Attack_point = "Left_thigh";
        }
        else if (randomNumber >= 95 && randomNumber < 96)  // 1%
        {
            Attack_point = "Right_thigh";
        }
        else if (randomNumber >= 96 && randomNumber < 97)  // 1%
        {
            Attack_point = "Left_shin";
        }
        else if (randomNumber >= 97 && randomNumber < 98)  // 1%
        {
            Attack_point = "Right_shin";
        }
        else if (randomNumber >= 98 && randomNumber < 99)  // 1%
        {
            Attack_point = "Left_foot";
        }
        else if (randomNumber >= 99 && randomNumber < 100)  // 1%
        {
            Attack_point = "Right_foot";
        }

        Calculating_the_Probability_of_Zombie_Attack_Pattern(Attack_point, Zombie_Attack_power);
    }

    // 2. 좀비의 공격 패턴 확률 계산
    enum Zombie_Attack_Pattern
    {
        punches = 0,
        Scratches = 1,
        Lacerations = 2,  
        Bites = 3  
    }

    void Calculating_the_Probability_of_Zombie_Attack_Pattern(string Attack_point, float Zombie_Attack_power)
    {
        System.Random rand = new System.Random();
        Zombie_Attack_Pattern Rand_pattern = (Zombie_Attack_Pattern)rand.Next(4);

        switch (Rand_pattern)
        {
            case Zombie_Attack_Pattern.punches:
                // 타격(피해o & 상처x)


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