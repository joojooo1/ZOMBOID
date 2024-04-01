using FreeNet;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Player_body_Location
{
    body_point _Body_Location_Code = new body_point();
    Damage_Pattern _Body_Current_state;
    bool _Bandage = false;  // 붕대 감았는지 여부로 hp 깎이는 속도 조절
    bool _disinfection = false;  // 소독 했는지 여부로 상처 낫는 속도 조절
    bool _Bleeding = false; // 출혈.. Moodles

     

    public Player_body_Location(body_point Body_Code)
    {
        _Body_Location_Code = Body_Code;

    }

    public void Set_Body_state(Damage_Pattern Attack_Pattern, string Zom_Type, bool IsBack)  // 좀비의 공격패턴, 좀비의 강도
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
            if (rand_Block / 100 < (Player_main.player_main.playerSkill_ActivationProbability.Get_Block_chance() * Player_main.player_main.playerSkill_ActivationProbability.Get_Chance_of_Blocking_zombie_frontal_attack()))
            {
                Is_Block = true;
            }
        }
        else
        {
            if (rand_Block / 100 < Player_main.player_main.playerSkill_ActivationProbability.Get_Block_chance())
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
                    case Damage_Pattern.Scratches:
                        // 긁힘  

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Calculating_Infection(7);  // 7% 확률로 감염

                        break;
                    case Damage_Pattern.Lacerations:
                        // 찢김

                        Player_main.player_main.player_HP.Set_Player_HP_for_Damage(Zombie_Attack_power);
                        Set_Is_Bleeding(true);
                        PlayerState.playerState.Calculating_Infection(25);  // 25% 확률로 감염

                        break;
                    case Damage_Pattern.Bites:
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

    public Damage_Pattern Get_Body_state()
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
    Left_lowerarm = 2,
    Right_lowerarm = 3,
    Left_upperarm = 4,
    Right_upperarm = 5,
    Chest = 6,
    Abdomen = 7,
    Head = 8,
    Neck = 9,
    Groin = 10,
    Left_upperleg = 11,
    Right_upperleg = 12,
    Left_lowerleg = 13,
    Right_lowerleg = 14,
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
    public Player_body_Location Left_lowerarm;
    // 오른팔목     공격받을 확률(기본): 12%
    public Player_body_Location Right_lowerarm;
    // 왼 팔뚝     공격받을 확률(기본): 11%
    public Player_body_Location Left_upperarm;
    // 오른 팔뚝     공격받을 확률(기본): 11%
    public Player_body_Location Right_upperarm;
    // 가슴     공격받을 확률(기본): 6%
    public Player_body_Location Chest;
    // 복부     공격받을 확률(기본): 6%
    public Player_body_Location Abdomen;
    // 머리     공격받을 확률(기본): 4%
    public Player_body_Location Head;
    // 목     공격받을 확률(기본): 7%
    public Player_body_Location Neck;
    // 사타구니     공격받을 확률(기본): 9%
    public Player_body_Location Groin;
    // 왼 허벅지     공격받을 확률(기본): 1%
    public Player_body_Location Left_upperleg;
    // 오른 허벅지     공격받을 확률(기본): 1%
    public Player_body_Location Right_upperleg;
    // 왼 정강이     공격받을 확률(기본): 1%
    public Player_body_Location Left_lowerleg;
    // 오른 정강이     공격받을 확률(기본): 1%
    public Player_body_Location Right_lowerleg;
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
        Left_lowerarm = new Player_body_Location(body_point.Left_lowerarm);
        Right_lowerarm = new Player_body_Location(body_point.Right_lowerarm);
        Left_upperarm = new Player_body_Location(body_point.Left_upperarm);
        Right_upperarm = new Player_body_Location(body_point.Right_upperarm);
        Chest = new Player_body_Location(body_point.Chest);
        Abdomen = new Player_body_Location(body_point.Abdomen);
        Head = new Player_body_Location(body_point.Head);
        Neck = new Player_body_Location(body_point.Neck);
        Groin = new Player_body_Location(body_point.Groin);
        Left_upperleg = new Player_body_Location(body_point.Left_upperleg);
        Right_upperleg = new Player_body_Location(body_point.Right_upperleg);
        Left_lowerleg = new Player_body_Location(body_point.Left_lowerleg);
        Right_lowerleg = new Player_body_Location(body_point.Right_lowerleg);
        Left_foot = new Player_body_Location(body_point.Left_foot);
        Right_foot = new Player_body_Location(body_point.Right_foot);

        Player_body_point.Add(Left_hand);
        Player_body_point.Add(Right_hand);
        Player_body_point.Add(Left_lowerarm);
        Player_body_point.Add(Right_lowerarm);
        Player_body_point.Add(Left_upperarm);
        Player_body_point.Add(Right_upperarm);
        Player_body_point.Add(Chest);
        Player_body_point.Add(Abdomen);
        Player_body_point.Add(Head);
        Player_body_point.Add(Neck);
        Player_body_point.Add(Groin);
        Player_body_point.Add(Left_upperleg);
        Player_body_point.Add(Right_upperleg);
        Player_body_point.Add(Left_lowerleg);
        Player_body_point.Add(Right_lowerleg);
        Player_body_point.Add(Left_foot);
        Player_body_point.Add(Right_foot);
    }

    float Endurance_Timer = 0.0f;
    float Thirsty_Timer = 0.0f;
    float Unhappy_Timer = 0.0f;
    float Tired_Timer = 0.0f;
    float Is_Cold_Timer = 0.0f;
    float Has_a_Cold_Timer = 0.0f;
    float Drunk_Timer = 0.0f;

    private void Update()
    {

        /****************** Player_Has_a_Cold ******************/
        if (Player_main.player_main.Is_Cold == false)
        {
            Is_Cold_Timer += Time.deltaTime;
            if (Is_Cold_Timer > 30f)   // 30초마다 감기걸렸는지 확인
            {
                System.Random rand = new System.Random();
                int temp = rand.Next(0, 100);

                if (Get_Probability_of_Catching_a_cold() * 100 > temp)
                {
                    Player_main.player_main.playerMoodles.Moodle_Has_a_Cold.Set_Moodles_state(0.1f);
                }
                Is_Cold_Timer = 0;
            }
        }

        /****************** Player_Endurance ******************/
        if (Player_main.player_main.Is_Running)
        {
            Endurance_Timer += Time.deltaTime;
            if(Endurance_Timer > 0.3f)
            {
                float Temp = 2.0f * Player_main.player_main.playerSkill_ActivationProbability.Get_Endurance_Depletion_Rate();
                Player_main.player_main.Set_Endurance(-Temp);
                Endurance_Timer = 0.0f;
            }
        }
        else
        {
            Endurance_Timer = 0.0f;
            if(Player_main.player_main.playerMoodles.Moodle_Tired.Get_Moodle_current_step() < 4)
            {
                Endurance_Timer += Time.deltaTime;
                if (Endurance_Timer > 0.5f)
                {
                    float Temp = 3.0f * Player_main.player_main.playerSkill_ActivationProbability.Get_Endurance_Recovery_Rate();
                    Player_main.player_main.Set_Endurance(Temp);
                    Endurance_Timer = 0.0f;
                }
            }


        }

        /****************** Player_Thirsty ******************/
        Thirsty_Timer += Time.deltaTime;
        if(Thirsty_Timer > 1f)
        {
            switch (Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_Moodle_current_step())
            {
                case 0:
                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(0.01f);
                    break;
                case 1:
                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(0.011f);
                    break;
                case 2:
                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(0.013f);
                    break;
                case 3:
                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(0.02f);
                    break;
                case 4:
                    Player_main.player_main.playerMoodles.Moodle_Thirsty.Set_Moodles_state(0.04f);
                    break;
            }
            Thirsty_Timer = 0;
        }

        /****************** Player_Stressed (Unhappy) ******************/
        if (Player_main.player_main.playerMoodles.Moodle_Stressed.Get_Moodle_current_step() > 2)
        {
            Unhappy_Timer += Time.deltaTime;
            if(Unhappy_Timer > 3f)
            {
                Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(0.015f);
            }
        }

        /****************** Player_Tired ******************/
        if(Player_main.player_main.Is_Sleeping == false)
        {
            Tired_Timer += Time.deltaTime;
            if (Tired_Timer > 3f)
            {
                int Endurance_level;  // 지구력 상태에 비례해서 오름
                if (Player_main.player_main.playerMoodles.Moodle_Endurance.Get_Moodle_current_step() > 2)
                {
                    Endurance_level = Player_main.player_main.playerMoodles.Moodle_Endurance.Get_Moodle_current_step() - 1;
                }
                else
                {
                    Endurance_level = 1;
                }

                float intoxication = 1f;  // 취한 상태에 비례해서 오름
                switch (Player_main.player_main.playerMoodles.Moodle_Drunk.Get_Moodle_current_step())
                {
                    case 0:
                        intoxication = 1;
                        break;
                    case 1:
                        intoxication = 1.05f;
                        break;
                    case 2:
                        intoxication = 1.25f;
                        break;
                    case 3:
                        intoxication = 1.5f;
                        break;
                    case 4:
                        intoxication = 1.75f; 
                        break;

                }

                switch (Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_Moodle_current_step())
                {
                    case 0:
                        Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(0.01f * Endurance_level * intoxication);
                        break;
                    case 1:
                        Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(0.01f * Endurance_level * intoxication);
                        break;
                    case 2:
                        Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(0.012f * Endurance_level * intoxication);
                        break;
                    case 3:
                        Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(0.015f * Endurance_level * intoxication);
                        break;
                    case 4:
                        Player_main.player_main.playerMoodles.Moodle_Tired.Set_Moodles_state(0.04f * Endurance_level * intoxication);
                        break;
                }

                Tired_Timer = 0;
            }
        }

        /************************************* Player_Hot/Cold **************************************/
        if (Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_Moodle_current_value() < 0)
        {
            float temp = Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Get_Moodle_current_value();
            Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Set_Moodles_state(-temp);  // Hot -> Cold 로 무들 변경
            Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Set_Moodles_state(-temp);  // Hot의 current_value 0으로 초기화
        }

        if (Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Get_Moodle_current_value() < 0)
        {
            float temp = Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Get_Moodle_current_value();
            Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Set_Moodles_state(-temp);  // Cold -> Hot 로 무들 변경
            Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Set_Moodles_state(-temp);  // Cold의 current_value 0으로 초기화
        }

        /****************** Player_Has_a_Cold ******************/
        if(Player_main.player_main.playerMoodles.Moodle_Has_a_Cold.Get_Moodle_current_value() > 0)
        {
            if (Player_main.player_main.playerMoodles.Moodle_Has_a_Cold.Get_Moodle_current_value() <= 1)
            {
                Has_a_Cold_Timer += Time.deltaTime;
                if (Has_a_Cold_Timer > 5f)
                {
                    Player_main.player_main.playerMoodles.Moodle_Has_a_Cold.Set_Moodles_state(0.05f);
                    Has_a_Cold_Timer = 0;
                }
            }
        }
        else
        {
            Has_a_Cold_Timer = 0;
        }

        /****************** Player_Drunk (Unhappy) ******************/
        if(Player_main.player_main.playerMoodles.Moodle_Drunk.Get_Moodle_current_step() > 0)
        {
            Drunk_Timer += Time.deltaTime;
            if(Drunk_Timer > 1.5f)
            {
                Player_main.player_main.playerMoodles.Moodle_Unhappy.Set_Moodles_state(-0.05f);
                Drunk_Timer = 0;
            }
        }
        else
        {
            Drunk_Timer = 0;
        }

        
    }

    public int Bleeding_total_count = 0;
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

    // 감기에 걸릴 확률 ( 기본 3% )
    [SerializeField] float _Probability_of_Catching_a_cold = 0.03f;
    float _Probability_of_Catching_a_cold_forMoodle = 1f;
    float _Probability_of_Catching_a_cold_for_Hyperthermia_Cold = 0f;
    float _Probability_of_Catching_a_cold_for_Wet = 0f;

    public void Set_Probability_of_Catching_a_cold(Moodles_private_code _Moodle_Code, float value)  // Moodle_Hyperthermia_Cold, Wet
    {
        switch (_Moodle_Code)
        {
            case Moodles_private_code.Hyperthermia_Cold:
                _Probability_of_Catching_a_cold_for_Hyperthermia_Cold = value;
                break;
            case Moodles_private_code.Wet:
                _Probability_of_Catching_a_cold_for_Wet = value;
                break;
        }

        _Probability_of_Catching_a_cold_forMoodle = _Probability_of_Catching_a_cold_for_Hyperthermia_Cold + _Probability_of_Catching_a_cold_for_Wet;
        if(_Probability_of_Catching_a_cold_forMoodle > 1) { _Probability_of_Catching_a_cold_forMoodle = 1; }
    }

    public float Get_Probability_of_Catching_a_cold()
    {
        return _Probability_of_Catching_a_cold + _Probability_of_Catching_a_cold_forMoodle;
    }


    [SerializeField] float Apparent_Temperature = 0.0f;  // 체감 온도
    // 옷으로 오르는 최고온도, 찬바람으로 내려가는 최저온도 조절  ( 20 ~ 50 )
    // Hot = 옷, Cold = 찬바람
    float Apparent_Temperature_forMoodle = 0f;

    public float Get_Apparent_Temperature()
    {
        return Apparent_Temperature + Apparent_Temperature_forMoodle;
    }

    public void Set_Apparent_Temperature(float value)
    {
        Apparent_Temperature = value;
        if((Get_Apparent_Temperature() + value) >= 36f)
        {
            Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Hot.Set_Moodles_state(Apparent_Temperature);
        }
        else
        {
            Player_main.player_main.playerMoodles.Moodle_Hyperthermia_Cold.Set_Moodles_state(Apparent_Temperature);
        }
    }

    public void Set_Apparent_Temperature_forMoodle(float value)
    {
        Apparent_Temperature_forMoodle = value;
    }

    [SerializeField] int Frequency_of_Coughing = 0;
    public void Set_Frequency_of_Coughing(int value)
    {
        Frequency_of_Coughing = value;
    }

    public int Get_Frequency_of_Coughing() { return  Frequency_of_Coughing; }
}
