using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_main : MonoBehaviour
{
    PlayerInventory inven = new PlayerInventory();
    PlayerSkill Skill;

    /* --------------------------------------------------------------------------------- */
    // 직업특성 등 반영안된 기본 능력치 (임의로 설정)
    float Health_Player = 100.0f;  // 체력 ( Fitness_Level: 5 / Strength_Level: 5 )
    float Weight = 83.0f; // 체중
    float Endurance = 100.0f; // 지구력  0 - 100
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


    // 밀쳐낸 경우 ( 밀쳐내지 못하면 밀쳐내지 않은 경우로 )


    // 밀쳐내지 않은 경우
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
        // 치명타 확률
        // 

    }
}
