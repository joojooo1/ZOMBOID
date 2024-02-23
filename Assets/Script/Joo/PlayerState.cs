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
    bool _Bandage = false;  // 붕대 감았는지 여부로 hp 깎이는 속도 조절
    bool _disinfection = false;  // 소독 했는지 여부로 상처 낫는 속도 조절
    bool _Bleeding = false; // 출혈.. Moodles
     

    public Player_body_Location(body_point Body_Code)
    {
        _Body_Location_Code = Body_Code;
    }

    public void Set_Body_state(Zombie_Attack_Pattern Attack_Pattern, string Zom_Type, bool IsBack)  // 좀비의 공격패턴, 좀비의 강도
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
        if (!IsBack)  // 정면일 경우 Moodle_Endurance의 영향으로 방어확률 감소할 수 있음
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

            if (rand_Evasion / 100 > Player_main.player_main.Get_Evasion())  // 회피율 계산
            {
                switch (Attack_Pattern)
                {
                    case Zombie_Attack_Pattern.punches:
                        // 타격(피해o & 상처x) : 일시적으로 Damage 발생  // 깨뜨린 창문에도 생김

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);

                        break;
                    case Zombie_Attack_Pattern.Scratches:
                        // 긁힘  

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Calculating_Infection(7);  // 7% 확률로 감염

                        break;
                    case Zombie_Attack_Pattern.Lacerations:
                        // 찢김

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Calculating_Infection(25);  // 25% 확률로 감염

                        break;
                    case Zombie_Attack_Pattern.Bites:
                        // 물림

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Set_Is_Infection(true);  // 100% 확률로 감염

                        break;
                    default:
                        break;
                }

            }
        }
        

        if (PlayerState.playerState.Get_Is_Infection())  // 감염된 경우
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
        if (_disinfection == true)  // 소독하고
        {
            if (_Bandage)  // 붕대를 감은 경우
            {
                Set_Is_Bleeding(false);
            }
            else  // 붕대를 감지 않은 경우
            {
                Set_Is_Bleeding(true);
                PlayerState.playerState.Calculating_Infection(20);  // 20% 확률로 감염
            }
        }
        else if (_disinfection == false)  // 소독하지 않고
        {
            if (_Bandage)  // 붕대를 감은 경우
            {
                Set_Is_Bleeding(false);
            }
            else  // 붕대를 감지 않은 경우
            {
                Set_Is_Bleeding(true);
                PlayerState.playerState.Calculating_Infection(30);  // 30% 확률로 감염
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
    public void Bleeding_Count_change()  // 출혈 갯수 변경시 호출
    {
        for (int i = 0; i < 17; i++)
        {
            if (Player_body_point[i].Get_Is_Bleeding())
                Bleeding_total_count++;
        }
        Player_main.player_main.playerMoodles.Moodle_Bleeding.Set_Moodles_state(Bleeding_total_count);  // 출혈
        Bleeding_total_count = 0;
    }

    [SerializeField] bool _Infection = false;  // 감염 여부 확인
    [SerializeField] float _Endurance = 100f;  // 지구력

    public void Set_Is_Infection(bool Is_Infection) { _Infection = Is_Infection; }
    public bool Get_Is_Infection() { return _Infection; }

    public bool Calculating_Infection(float Infection_value)  // 감염될 확률 받아서 랜덤 계산
    {
        System.Random rand = new System.Random();
        int rand_infection = rand.Next(100);

        if (rand_infection >= 0 && rand_infection < Infection_value) _Infection = true;
        else _Infection = false;

        return _Infection;
    }


}
