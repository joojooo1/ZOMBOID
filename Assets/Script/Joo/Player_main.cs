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
    // ����Ư�� �� �ݿ��ȵ� �⺻ �ɷ�ġ (���Ƿ� ����)
    float Health_Player = 100.0f;  // ü�� ( Fitness_Level: 5 / Strength_Level: 5 )
    float Weight = 83.0f; // ü��
    float Endurance = 1.0f; // ���¹̳�(������)  0 - 1
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


    // ���� ������ ���ĳ� Ȯ�� ��� ( ���ĳ��� ���ϸ� ���ĳ��� ���� ����� �Լ� ȣ�� )
    void Calculate_HitForce(float Zombie_Attack_power)
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

 2. Moodles
  - Hungry  // �����, ��θ�
  - Thirsty  // �񸶸�
  - Panic  // ����
  - Bored  // ������
  - Stressed  // ��Ʈ����
  - Unhappy  // ������
  - Drunk  // ����
  - Heavy_Load  // ���ſ�
  - Endurance  // ��ħ ( ���� )  
  - Tired  // �ǰ���
  - Hyperthermia ( hot / cold )  // ����, �߿�
  - Windchill  // �� �ٶ�
  - Wet  // ����
  - Injured  // �λ�
  - Pain  // ����
  - Bleeding  // ����
  - Has_a_Cold  // ����
  - Sick  // ����
  - Dead  // ���
  - Zombie  // ����ȭ
  - Restricted_Movement  // �������� �� �� ����
 




 */