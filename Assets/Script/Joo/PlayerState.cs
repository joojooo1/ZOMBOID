using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Defensive_Power
{
    string _Body_Name = "";
    float _Body_Min_Durability = 0.0f;
    float _Body_Max_Durability = 100.0f;
    float _Body_Current_Durability = 0.0f;

    public Body_Defensive_Power(string Body_Name, float Body_current_Durability)  // Ư���� ���� �⺻ ���� �޶��� ���ɼ� ��� ( �⺻ 0f )
    {
        _Body_Name = Body_Name;
        _Body_Current_Durability = Body_current_Durability;
    }


}


public class PlayerState : MonoBehaviour
{
    // �޼�     ���ݹ��� Ȯ��(�⺻): 8%
    Body_Defensive_Power Left_hand;
    // ������     ���ݹ��� Ȯ��(�⺻): 8%
    Body_Defensive_Power Right_hand;
    // ���ȸ�     ���ݹ��� Ȯ��(�⺻): 12%
    Body_Defensive_Power Left_forearm;
    // �����ȸ�     ���ݹ��� Ȯ��(�⺻): 12%
    Body_Defensive_Power Right_forearm;
    // �� �ȶ�     ���ݹ��� Ȯ��(�⺻): 11%
    Body_Defensive_Power Left_upper_arm;
    // ���� �ȶ�     ���ݹ��� Ȯ��(�⺻): 11%
    Body_Defensive_Power Right_upper_arm;
    // ����     ���ݹ��� Ȯ��(�⺻): 6%
    Body_Defensive_Power upper_torso;
    // ����     ���ݹ��� Ȯ��(�⺻): 6%
    Body_Defensive_Power Lower_torso;
    // �Ӹ�     ���ݹ��� Ȯ��(�⺻): 4%
    Body_Defensive_Power Head;
    // ��     ���ݹ��� Ȯ��(�⺻): 7%
    Body_Defensive_Power Neck;
    // ��Ÿ����     ���ݹ��� Ȯ��(�⺻): 9%
    Body_Defensive_Power Groin;
    // �� �����     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Defensive_Power Left_thigh;
    // ���� �����     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Defensive_Power Right_thigh;
    // �� ������     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Defensive_Power Left_shin;
    // ���� ������     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Defensive_Power Right_shin;
    // �޹�     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Defensive_Power Left_foot;
    // ������     ���ݹ��� Ȯ��(�⺻): 1%
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
