using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Durability
{
    string _Body_Name = "";
    float _Body_Min_Durability = 0.0f;
    float _Body_Max_Durability = 100.0f;
    float _Body_Current_Durability = 0.0f;

    public Body_Durability(string Body_Name, float Body_current_Durability)  // 특성에 따라 기본 방어력 달라질 가능성 고려
    {
        _Body_Name = Body_Name;
        _Body_Current_Durability = Body_current_Durability;
    }

    enum Attack_from_Zombie
    {
        punches = 0,  // 타격(피해o & 상처x)
        Scratches = 1,  // 긁힘(7% 확률로 감염)
        Lacerations = 2,  // 찢김(25% 확률로 감염)
        Bites = 3  // 물림(100% 확률로 감염)
    }



}


public class PlayerState : MonoBehaviour
{
    // 왼손     공격받을 확률(기본): 8%
    Body_Durability Left_hand;
    // 오른손     공격받을 확률(기본): 8%
    Body_Durability Right_hand;
    // 왼팔목     공격받을 확률(기본): 12%
    Body_Durability Left_forearm;
    // 오른팔목     공격받을 확률(기본): 12%
    Body_Durability Right_forearm;
    // 왼 팔뚝     공격받을 확률(기본): 11%
    Body_Durability Left_upper_arm;
    // 오른 팔뚝     공격받을 확률(기본): 11%
    Body_Durability Right_upper_arm;
    // 가슴     공격받을 확률(기본): 6%
    Body_Durability upper_torso;
    // 복부     공격받을 확률(기본): 6%
    Body_Durability Lower_torso;
    // 머리     공격받을 확률(기본): 4%
    Body_Durability Head;
    // 목     공격받을 확률(기본): 7%
    Body_Durability Neck;
    // 사타구니     공격받을 확률(기본): 9%
    Body_Durability Groin;
    // 왼 허벅지     공격받을 확률(기본): 1%
    Body_Durability Left_thigh;
    // 오른 허벅지     공격받을 확률(기본): 1%
    Body_Durability Right_thigh;
    // 왼 정강이     공격받을 확률(기본): 1%
    Body_Durability Left_shin;
    // 오른 정강이     공격받을 확률(기본): 1%
    Body_Durability Right_shin;
    // 왼발     공격받을 확률(기본): 1%
    Body_Durability Left_foot;
    // 오른발     공격받을 확률(기본): 1%
    Body_Durability Right_foot;

    private void Start()
    {
        Left_hand = new Body_Durability("Left_hand", 0f);
        Right_hand = new Body_Durability("Right_hand", 0f);
        Left_forearm = new Body_Durability("Left_forearm", 0f);
        Right_forearm = new Body_Durability("Right_forearm", 0f);
        Left_upper_arm = new Body_Durability("Left_upper_arm", 0f);
        Right_upper_arm = new Body_Durability("Right_upper_arm", 0f);
        upper_torso = new Body_Durability("upper_torso", 0f);
        Lower_torso = new Body_Durability("Lower_torso", 0f);
        Head = new Body_Durability("Head", 0f);
        Neck = new Body_Durability("Neck", 0f);
        Groin = new Body_Durability("Groin", 0f);
        Left_thigh = new Body_Durability("Left_thigh", 0f);
        Right_thigh = new Body_Durability("Right_thigh", 0f);
        Left_shin = new Body_Durability("Left_shin", 0f);
        Right_shin = new Body_Durability("Right_shin", 0f);
        Left_foot = new Body_Durability("Left_foot", 0f);
        Right_foot = new Body_Durability("Right_foot", 0f);
    }


}
