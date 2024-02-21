using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Player_body_Location
{
    string _Body_Location_Name = "";
    Zombie_Attack_Pattern _Body_Current_state;
    bool _Bandage = false;  // �ش� ���Ҵ��� ���η� hp ���̴� �ӵ� ����
    bool _disinfection = false;  // �ҵ� �ߴ��� ���η� ��ó ���� �ӵ� ����
    bool _Infection = false;  // ���� ���� Ȯ��
    float Persistent_Damage = 0.0f;  // ���� �� ���������� �𿩳��� Damage
    int Bleeding = 0; // ����.. Moodles

    public Player_body_Location(string Body_Name)
    {
        _Body_Location_Name = Body_Name;
    }

    public void Set_Body_state(Zombie_Attack_Pattern Attack_Pattern, string Zom_Type)  // ������ ��������, ������ ����
    {
        System.Random rand = new System.Random();
        int randomNum = rand.Next(100);

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

        switch(Attack_Pattern)
        {
            case Zombie_Attack_Pattern.punches:  // Ÿ��(����o & ��óx) : �Ͻ������� Damage
                Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                break;
            case Zombie_Attack_Pattern.Scratches:  // ����(7% Ȯ���� ����)
                // hp ���̴� �ӵ� ����
                Player_main.player_main.playerMoodles.Moodle_Bleeding.Set_Moodles_state(++Bleeding);
                if (_disinfection == true)
                {                    
                    if (_Bandage)
                    {
                        Player_main.player_main.playerMoodles.Moodle_Bleeding.Set_Moodles_state(--Bleeding);
                    }
                    else
                    {

                    }
                }
                else if (_disinfection == false)
                {
                    if (_Bandage)
                    {

                    }
                    else
                    {

                    }
                }
                break;
            case Zombie_Attack_Pattern.Lacerations:  // ����(25% Ȯ���� ����)
                break;
            case Zombie_Attack_Pattern.Bites:  // ����(100% Ȯ���� ����)
                break;
            default:
                break;
        }
    }

    public Zombie_Attack_Pattern Get_Body_state()
    {
        return _Body_Current_state;
    }

    public void Set_Is_disinfection(bool Is_disinfection)
    {
        if(Is_disinfection)
        {
            _disinfection = false;
        }
        else
        {
            _disinfection = true;
        }
    }

    public void Set_Is_Bandage(bool Is_Bandage)
    {
        if (Is_Bandage)
        {
            _Bandage = false;
        }
        else
        {
            _Bandage = true;
        }
    }
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

    private void Start()
    {
        playerState = this;

        Left_hand = new Player_body_Location("Left_hand");
        Right_hand = new Player_body_Location("Right_hand");
        Left_forearm = new Player_body_Location("Left_forearm");
        Right_forearm = new Player_body_Location("Right_forearm");
        Left_upper_arm = new Player_body_Location("Left_upper_arm");
        Right_upper_arm = new Player_body_Location("Right_upper_arm");
        upper_torso = new Player_body_Location("upper_torso");
        Lower_torso = new Player_body_Location("Lower_torso");
        Head = new Player_body_Location("Head");
        Neck = new Player_body_Location("Neck");
        Groin = new Player_body_Location("Groin");
        Left_thigh = new Player_body_Location("Left_thigh");
        Right_thigh = new Player_body_Location("Right_thigh");
        Left_shin = new Player_body_Location("Left_shin");
        Right_shin = new Player_body_Location("Right_shin");
        Left_foot = new Player_body_Location("Left_foot");
        Right_foot = new Player_body_Location("Right_foot");
    }


}
