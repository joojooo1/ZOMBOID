using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_main : MonoBehaviour
{
    public static Player_main player_main;

    PlayerInventory inven = new PlayerInventory();
    PlayerSkill Skill;

    /* --------------------------------------------------------------------------------- */
    // 직업특성 등 반영안된 기본 능력치 (임의로 설정)
    float Health_Player = 100.0f;  // 체력 ( Fitness_Level: 5 / Strength_Level: 5 )
    float Weight = 83.0f; // 체중
    float Endurance = 1.0f; // 스태미너(지구력)  0 - 1
    float fatigue = 0.0f; // 피로도 0 - 100
    float Hunger = 0.0f; // 배고픔 0 - 100
    float Calories = 50.0f; // 칼로리 0 - 100
    float Boredom = 0.0f; // 지루함 0 - 100
    float Unhappiness = 0.0f; // 불행함 0 - 100
    float Temperature = 50.0f; // 온도 0 - 100

    float Attack_Power = 8.0f; // 공격력
    float Evasion = 0.15f;  // 회피율
    bool Equipping_Weapons = false;  // 시작시 무기 착용 X
    /* --------------------------------------------------------------------------------- */

    public float Get_Endurance()
    {
        return Endurance;
    }

    void Start()
    {
        Skill = GetComponent<PlayerSkill>();
    }

    float Playermovement_speed = 1.0f;

    float Timer = 0.0f;
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > 3.0f)
        {
            // 3초마다 피로도 +3.0f * 피로도 생성 비율 (임의로 설정)
            fatigue += 3.0f * PlayerSkill_ActivationProbability.playerSkill_ActivationProbability.Get_Fatigue_Generation_Rate();  // * 피로도 생성 비율
            Timer = 0.0f;
        }

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


    // 공격 받으면 밀쳐낼 확률 계산 ( 밀쳐내지 못하면 밀쳐내지 못한 경우의 함수 호출 )
    void Calculate_HitForce(float Zombie_Attack_power)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if(((float)randomNumber/100) > PlayerSkill_ActivationProbability.playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculate_damage_from_Zombie(Zombie_Attack_power);
        }
    }

    // 밀쳐내지 못한 경우
    void Calculate_damage_from_Zombie(float Zombie_Attack_power)  // Zombie -> Player 공격
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

 2. Moodles
  - Hungry  // 배고픔, 배부름
  - Thirsty  // 목마름
  - Panic  // 긴장
  - Bored  // 지루함
  - Stressed  // 스트레스
  - Unhappy  // 불행함
  - Drunk  // 취함
  - Heavy_Load  // 무거움
  - Endurance  // 지침 ( 있음 )  
  - Tired  // 피곤함
  - Hyperthermia ( hot / cold )  // 더움, 추움
  - Windchill  // 찬 바람
  - Wet  // 젖음
  - Injured  // 부상
  - Pain  // 고통
  - Bleeding  // 출혈
  - Has_a_Cold  // 감기
  - Sick  // 질병
  - Dead  // 사망
  - Zombie  // 좀비화
  - Restricted_Movement  // 전력질주 할 수 없음
 




 */