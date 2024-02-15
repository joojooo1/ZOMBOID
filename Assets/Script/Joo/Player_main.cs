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
    // ����Ư�� �� �ݿ��ȵ� �⺻ �ɷ�ġ (���Ƿ� ����)
    float Health_Player = 100.0f;  // ü�� ( Fitness_Level: 5 / Strength_Level: 5 )
    float Weight = 83.0f; // ü��
    float Calories = 50.0f; // Į�θ� 0 - 100
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

    void Update()
    {
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


    // ���ĳ��� ���� ���� ������ �ؾ� ��
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


    }


    // ���� ������ ���ĳ� Ȯ�� ��� ( ���ĳ��� ���ϸ� ���ĳ��� ���� ����� �Լ� ȣ�� )
    void Calculate_HitForce(string Attack_point, float Zombie_Attack_power)
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(100);

        if(((float)randomNumber/100) > PlayerSkill_ActivationProbability.playerSkill_ActivationProbability.Get_HitForce())
        {
            Calculate_damage_from_Zombie(Zombie_Attack_power);
        }
    }

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