using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Player_body_Location
{
    string _Body_Location_Name = "";
    Zombie_Attack_Pattern _Body_Current_state;
    bool _Bandage = false;  // 붕대 감았는지 여부로 hp 깎이는 속도 조절
    bool _disinfection = false;  // 소독 했는지 여부로 상처 낫는 속도 조절
    bool _Infection = false;  // 감염 여부 확인
    float Persistent_Damage = 0.0f;  // 출혈 시 지속적으로 깎여나갈 Damage
    int Bleeding = 0; // 출혈.. Moodles

    public Player_body_Location(string Body_Name)
    {
        _Body_Location_Name = Body_Name;
    }

    public void Set_Body_state(Zombie_Attack_Pattern Attack_Pattern, string Zom_Type)  // 좀비의 공격패턴, 좀비의 강도
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
            case Zombie_Attack_Pattern.punches:  // 타격(피해o & 상처x) : 일시적으로 Damage
                Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                break;
            case Zombie_Attack_Pattern.Scratches:  // 긁힘(7% 확률로 감염)
                // hp 깎이는 속도 조절
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
            case Zombie_Attack_Pattern.Lacerations:  // 찢김(25% 확률로 감염)
                break;
            case Zombie_Attack_Pattern.Bites:  // 물림(100% 확률로 감염)
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

    // 왼손     공격받을 확률(기본): 8%
    public Player_body_Location Left_hand;
    // 오른손     공격받을 확률(기본): 8%
    public Player_body_Location Right_hand;
    // 왼팔목     공격받을 확률(기본): 12%
    public Player_body_Location Left_forearm;
    // 오른팔목     공격받을 확률(기본): 12%
    public Player_body_Location Right_forearm;
    // 왼 팔뚝     공격받을 확률(기본): 11%
    public Player_body_Location Left_upper_arm;
    // 오른 팔뚝     공격받을 확률(기본): 11%
    public Player_body_Location Right_upper_arm;
    // 가슴     공격받을 확률(기본): 6%
    public Player_body_Location upper_torso;
    // 복부     공격받을 확률(기본): 6%
    public Player_body_Location Lower_torso;
    // 머리     공격받을 확률(기본): 4%
    public Player_body_Location Head;
    // 목     공격받을 확률(기본): 7%
    public Player_body_Location Neck;
    // 사타구니     공격받을 확률(기본): 9%
    public Player_body_Location Groin;
    // 왼 허벅지     공격받을 확률(기본): 1%
    public Player_body_Location Left_thigh;
    // 오른 허벅지     공격받을 확률(기본): 1%
    public Player_body_Location Right_thigh;
    // 왼 정강이     공격받을 확률(기본): 1%
    public Player_body_Location Left_shin;
    // 오른 정강이     공격받을 확률(기본): 1%
    public Player_body_Location Right_shin;
    // 왼발     공격받을 확률(기본): 1%
    public Player_body_Location Left_foot;
    // 오른발     공격받을 확률(기본): 1%
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
