using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_main : MonoBehaviour
{
    PlayerInventory inven = new PlayerInventory();
    PlayerSkill Skill;

    /* --------------------------------------------------------------------------------- */
    // ����Ư�� �� �ݿ��ȵ� �⺻ �ɷ�ġ (���Ƿ� ����)
    float Health_Player = 100.0f;  // ü�� ( Fitness_Level: 5 / Strength_Level: 5 )
    float Weight = 83.0f; // ü��
    float Endurance = 100.0f; // ������  0 - 100
    float fatigue = 0.0f; // �Ƿε� 0 - 100
    float Hunger = 0.0f; // ����� 0 - 100
    float Calories = 50.0f; // Į�θ� 0 - 100
    float Boredom = 0.0f; // ������ 0 - 100
    float Unhappiness = 0.0f; // ������ 0 - 100
    float Temperature = 50.0f; // �µ� 0 - 100

    float Attack_Power = 8.0f; // ���ݷ�
    float Evasion = 0.15f;  // ȸ����
    bool Equipping_Weapons = false;  // ���۽� ���� ���� X
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
            // 3�ʸ��� �Ƿε� +3.0f * �Ƿε� ���� ���� (���Ƿ� ����)
            fatigue += 3.0f * PlayerSkill_ActivationProbability.playerSkill_ActivationProbability.Get_Fatigue_Generation_Rate();  // * �Ƿε� ���� ����
            Timer = 0.0f;
        }

        /*
        if ()  // ���⸦ �����ϴ� ���  ( ���� )
        {
            Equipping_Weapons = true;
            
        }
        */

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 pos = transform.position;
        pos += input * Time.deltaTime * Playermovement_speed;

        transform.position = pos;


    }


    // ���ĳ� ��� ( ���ĳ��� ���ϸ� ���ĳ��� ���� ���� )


    // ���ĳ��� ���� ���
    void Calculate_damage_from_Zombie(float Zombie_Attack_power)  // Zombie -> Player ����
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
        // ġ��Ÿ Ȯ��
        // 

    }
}
