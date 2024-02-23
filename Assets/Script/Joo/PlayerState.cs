using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Player_body_Location
{
    body_point _Body_Location_Code = new body_point();
    Zombie_Attack_Pattern _Body_Current_state;
    bool _Bandage = false;  // �ش� ���Ҵ��� ���η� hp ���̴� �ӵ� ����
    bool _disinfection = false;  // �ҵ� �ߴ��� ���η� ��ó ���� �ӵ� ����
    bool _Bleeding = false; // ����.. Moodles
     

    public Player_body_Location(body_point Body_Code)
    {
        _Body_Location_Code = Body_Code;
    }

    public void Set_Body_state(Zombie_Attack_Pattern Attack_Pattern, string Zom_Type, bool IsBack)  // ������ ��������, ������ ����
    {
        _Body_Current_state = Attack_Pattern;

        float Zombie_Attack_power = 5.0f;
        if (Zom_Type == "easy")
        {
            Zombie_Attack_power *= 0.7f;  // 3.5
        }
        else if(Zom_Type == "normal")
        {
            Zombie_Attack_power *= 1.0f;  // 5
        }
        else if(Zom_Type == "hard")
        {
            Zombie_Attack_power *= 1.5f;  // 7.5
        }

        System.Random rand = new System.Random();
        int rand_Block = rand.Next(100);

        bool Is_Block = false;
        if (!IsBack)  // ������ ��� Moodle_Endurance�� �������� ���Ȯ�� ������ �� ����
        {
            if (rand_Block / 100 > Player_main.player_main.playerSkill_ActivationProbability.Get_Block_chance() * Player_main.player_main.playerSkill_ActivationProbability.Get_Chance_of_Blocking_zombie_frontal_attack())
            {
                Is_Block = true;
            }
        }
        else
        {
            if (rand_Block / 100 > Player_main.player_main.playerSkill_ActivationProbability.Get_Block_chance())
            {
                Is_Block = true;
            }
        }

        if (!Is_Block)
        {
            System.Random Rerand = new System.Random();
            int rand_Evasion = rand.Next(100);

            if (rand_Evasion / 100 > Player_main.player_main.Get_Evasion())  // ȸ���� ���
            {
                switch (Attack_Pattern)
                {
                    case Zombie_Attack_Pattern.punches:
                        // Ÿ��(����o & ��óx) : �Ͻ������� Damage �߻�  // ���߸� â������ ����

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);

                        break;
                    case Zombie_Attack_Pattern.Scratches:
                        // ����  

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Calculating_Infection(7);  // 7% Ȯ���� ����

                        break;
                    case Zombie_Attack_Pattern.Lacerations:
                        // ����

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Calculating_Infection(25);  // 25% Ȯ���� ����

                        break;
                    case Zombie_Attack_Pattern.Bites:
                        // ����

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Set_Is_Infection(true);  // 100% Ȯ���� ����

                        break;
                    default:
                        break;
                }

            }
        }
        

        if (PlayerState.playerState.Get_Is_Infection())  // ������ ���
        {
            
        }
    }

    public Zombie_Attack_Pattern Get_Body_state()
    {
        return _Body_Current_state;
    }

    public void Set_Is_disinfection(bool Is_disinfection) { _disinfection = Is_disinfection; }
    public bool Get_Is_disinfection() { return _disinfection; }

    public void Set_Is_Bandage(bool Is_Bandage) 
    { 
        _Bandage = Is_Bandage;
        if (_disinfection == true)  // �ҵ��ϰ�
        {
            if (_Bandage)  // �ش븦 ���� ���
            {
                Set_Is_Bleeding(false);
            }
            else  // �ش븦 ���� ���� ���
            {
                Set_Is_Bleeding(true);
                PlayerState.playerState.Calculating_Infection(20);  // 20% Ȯ���� ����
            }
        }
        else if (_disinfection == false)  // �ҵ����� �ʰ�
        {
            if (_Bandage)  // �ش븦 ���� ���
            {
                Set_Is_Bleeding(false);
            }
            else  // �ش븦 ���� ���� ���
            {
                Set_Is_Bleeding(true);
                PlayerState.playerState.Calculating_Infection(30);  // 30% Ȯ���� ����
            }
        }
    }
    public bool Get_Is_Bandage() { return _Bandage; }

    public void Set_Is_Bleeding(bool Is_Bleeding) 
    { 
        _Bleeding = Is_Bleeding;
        PlayerState.playerState.Bleeding_Count_change();
    }
    public bool Get_Is_Bleeding() { return _Bleeding; }
}

public enum body_point
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

public class PlayerState : MonoBehaviour
{
    public static PlayerState playerState;

    // �޼�     ���ݹ��� Ȯ��(�⺻): 8%
    public Player_body_Location Left_hand;
    // ������     ���ݹ��� Ȯ��(�⺻): 8%
    public Player_body_Location Right_hand;
    // ���ȸ�     ���ݹ��� Ȯ��(�⺻): 12%
    public Player_body_Location Left_forearm;
    // �����ȸ�     ���ݹ��� Ȯ��(�⺻): 12%
    public Player_body_Location Right_forearm;
    // �� �ȶ�     ���ݹ��� Ȯ��(�⺻): 11%
    public Player_body_Location Left_upper_arm;
    // ���� �ȶ�     ���ݹ��� Ȯ��(�⺻): 11%
    public Player_body_Location Right_upper_arm;
    // ����     ���ݹ��� Ȯ��(�⺻): 6%
    public Player_body_Location upper_torso;
    // ����     ���ݹ��� Ȯ��(�⺻): 6%
    public Player_body_Location Lower_torso;
    // �Ӹ�     ���ݹ��� Ȯ��(�⺻): 4%
    public Player_body_Location Head;
    // ��     ���ݹ��� Ȯ��(�⺻): 7%
    public Player_body_Location Neck;
    // ��Ÿ����     ���ݹ��� Ȯ��(�⺻): 9%
    public Player_body_Location Groin;
    // �� �����     ���ݹ��� Ȯ��(�⺻): 1%
    public Player_body_Location Left_thigh;
    // ���� �����     ���ݹ��� Ȯ��(�⺻): 1%
    public Player_body_Location Right_thigh;
    // �� ������     ���ݹ��� Ȯ��(�⺻): 1%
    public Player_body_Location Left_shin;
    // ���� ������     ���ݹ��� Ȯ��(�⺻): 1%
    public Player_body_Location Right_shin;
    // �޹�     ���ݹ��� Ȯ��(�⺻): 1%
    public Player_body_Location Left_foot;
    // ������     ���ݹ��� Ȯ��(�⺻): 1%
    public Player_body_Location Right_foot;

    public List<Player_body_Location> Player_body_point= new List<Player_body_Location>();
    private void Awake()
    {
        playerState = this;

        Left_hand = new Player_body_Location(body_point.Left_hand);
        Right_hand = new Player_body_Location(body_point.Right_hand);
        Left_forearm = new Player_body_Location(body_point.Left_forearm);
        Right_forearm = new Player_body_Location(body_point.Right_forearm);
        Left_upper_arm = new Player_body_Location(body_point.Left_upper_arm);
        Right_upper_arm = new Player_body_Location(body_point.Right_upper_arm);
        upper_torso = new Player_body_Location(body_point.upper_torso);
        Lower_torso = new Player_body_Location(body_point.Lower_torso);
        Head = new Player_body_Location(body_point.Head);
        Neck = new Player_body_Location(body_point.Neck);
        Groin = new Player_body_Location(body_point.Groin);
        Left_thigh = new Player_body_Location(body_point.Left_thigh);
        Right_thigh = new Player_body_Location(body_point.Right_thigh);
        Left_shin = new Player_body_Location(body_point.Left_shin);
        Right_shin = new Player_body_Location(body_point.Right_shin);
        Left_foot = new Player_body_Location(body_point.Left_foot);
        Right_foot = new Player_body_Location(body_point.Right_foot);

        Player_body_point.Add(Left_hand);
        Player_body_point.Add(Right_hand);
        Player_body_point.Add(Left_forearm);
        Player_body_point.Add(Right_forearm);
        Player_body_point.Add(Left_upper_arm);
        Player_body_point.Add(Right_upper_arm);
        Player_body_point.Add(upper_torso);
        Player_body_point.Add(Lower_torso);
        Player_body_point.Add(Head);
        Player_body_point.Add(Neck);
        Player_body_point.Add(Groin);
        Player_body_point.Add(Left_thigh);
        Player_body_point.Add(Right_thigh);
        Player_body_point.Add(Left_shin);
        Player_body_point.Add(Right_shin);
        Player_body_point.Add(Left_foot);
        Player_body_point.Add(Right_foot);
    }

    private void Update()
    {
        
    }

    int Bleeding_total_count = 0;
    public void Bleeding_Count_change()  // ���� ���� ����� ȣ��
    {
        for (int i = 0; i < 17; i++)
        {
            if (Player_body_point[i].Get_Is_Bleeding())
                Bleeding_total_count++;
        }
        Player_main.player_main.playerMoodles.Moodle_Bleeding.Set_Moodles_state(Bleeding_total_count);  // ����
        Bleeding_total_count = 0;
    }

    [SerializeField] bool _Infection = false;  // ���� ���� Ȯ��
    [SerializeField] float _Endurance = 100f;  // ������

    public void Set_Is_Infection(bool Is_Infection) { _Infection = Is_Infection; }
    public bool Get_Is_Infection() { return _Infection; }

    public bool Calculating_Infection(float Infection_value)  // ������ Ȯ�� �޾Ƽ� ���� ���
    {
        System.Random rand = new System.Random();
        int rand_infection = rand.Next(100);

        if (rand_infection >= 0 && rand_infection < Infection_value) _Infection = true;
        else _Infection = false;

        return _Infection;
    }


}
