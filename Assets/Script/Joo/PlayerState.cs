using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Defensive_Power
{
    string _Body_Name = "";
    float _Body_Min_Durability = 0.0f;
    float _Body_Max_Durability = 100.0f;
    float _Body_Current_Durability = 0.0f;

    public Body_Defensive_Power(string Body_Name, float Body_current_Durability)  // 특성에 따라 기본 방어력 달라질 가능성 고려 ( 기본 0f )
    {
        _Body_Name = Body_Name;
        _Body_Current_Durability = Body_current_Durability;
    }


}


public class PlayerState : MonoBehaviour
{
    // 왼손     공격받을 확률(기본): 8%
    Body_Defensive_Power Left_hand;
    // 오른손     공격받을 확률(기본): 8%
    Body_Defensive_Power Right_hand;
    // 왼팔목     공격받을 확률(기본): 12%
    Body_Defensive_Power Left_forearm;
    // 오른팔목     공격받을 확률(기본): 12%
    Body_Defensive_Power Right_forearm;
    // 왼 팔뚝     공격받을 확률(기본): 11%
    Body_Defensive_Power Left_upper_arm;
    // 오른 팔뚝     공격받을 확률(기본): 11%
    Body_Defensive_Power Right_upper_arm;
    // 가슴     공격받을 확률(기본): 6%
    Body_Defensive_Power upper_torso;
    // 복부     공격받을 확률(기본): 6%
    Body_Defensive_Power Lower_torso;
    // 머리     공격받을 확률(기본): 4%
    Body_Defensive_Power Head;
    // 목     공격받을 확률(기본): 7%
    Body_Defensive_Power Neck;
    // 사타구니     공격받을 확률(기본): 9%
    Body_Defensive_Power Groin;
    // 왼 허벅지     공격받을 확률(기본): 1%
    Body_Defensive_Power Left_thigh;
    // 오른 허벅지     공격받을 확률(기본): 1%
    Body_Defensive_Power Right_thigh;
    // 왼 정강이     공격받을 확률(기본): 1%
    Body_Defensive_Power Left_shin;
    // 오른 정강이     공격받을 확률(기본): 1%
    Body_Defensive_Power Right_shin;
    // 왼발     공격받을 확률(기본): 1%
    Body_Defensive_Power Left_foot;
    // 오른발     공격받을 확률(기본): 1%
    Body_Defensive_Power Right_foot;

    private void Start()
    {
        Left_hand = new Body_Defensive_Power("Left_hand", 0f);
        Right_hand = new Body_Defensive_Power("Right_hand", 0f);
        Left_forearm = new Body_Defensive_Power("Left_forearm", 0f);
        Right_forearm = new Body_Defensive_Power("Right_forearm", 0f);
        Left_upper_arm = new Body_Defensive_Power("Left_upper_arm", 0f);
        Right_upper_arm = new Body_Defensive_Power("Right_upper_arm", 0f);
        upper_torso = new Body_Defensive_Power("upper_torso", 0f);
        Lower_torso = new Body_Defensive_Power("Lower_torso", 0f);
        Head = new Body_Defensive_Power("Head", 0f);
        Neck = new Body_Defensive_Power("Neck", 0f);
        Groin = new Body_Defensive_Power("Groin", 0f);
        Left_thigh = new Body_Defensive_Power("Left_thigh", 0f);
        Right_thigh = new Body_Defensive_Power("Right_thigh", 0f);
        Left_shin = new Body_Defensive_Power("Left_shin", 0f);
        Right_shin = new Body_Defensive_Power("Right_shin", 0f);
        Left_foot = new Body_Defensive_Power("Left_foot", 0f);
        Right_foot = new Body_Defensive_Power("Right_foot", 0f);
    }


}
