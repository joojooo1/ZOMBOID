using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_Durability
{
    string _Body_Name = "";
    float _Body_Min_Durability = 0.0f;
    float _Body_Max_Durability = 100.0f;
    float _Body_Current_Durability = 0.0f;

    public Body_Durability(string Body_Name, float Body_current_Durability)  // Ư���� ���� �⺻ ���� �޶��� ���ɼ� ���
    {
        _Body_Name = Body_Name;
        _Body_Current_Durability = Body_current_Durability;
    }

    enum Attack_from_Zombie
    {
        punches = 0,  // Ÿ��(����o & ��óx)
        Scratches = 1,  // ����(7% Ȯ���� ����)
        Lacerations = 2,  // ����(25% Ȯ���� ����)
        Bites = 3  // ����(100% Ȯ���� ����)
    }



}


public class PlayerState : MonoBehaviour
{
    // �޼�     ���ݹ��� Ȯ��(�⺻): 8%
    Body_Durability Left_hand;
    // ������     ���ݹ��� Ȯ��(�⺻): 8%
    Body_Durability Right_hand;
    // ���ȸ�     ���ݹ��� Ȯ��(�⺻): 12%
    Body_Durability Left_forearm;
    // �����ȸ�     ���ݹ��� Ȯ��(�⺻): 12%
    Body_Durability Right_forearm;
    // �� �ȶ�     ���ݹ��� Ȯ��(�⺻): 11%
    Body_Durability Left_upper_arm;
    // ���� �ȶ�     ���ݹ��� Ȯ��(�⺻): 11%
    Body_Durability Right_upper_arm;
    // ����     ���ݹ��� Ȯ��(�⺻): 6%
    Body_Durability upper_torso;
    // ����     ���ݹ��� Ȯ��(�⺻): 6%
    Body_Durability Lower_torso;
    // �Ӹ�     ���ݹ��� Ȯ��(�⺻): 4%
    Body_Durability Head;
    // ��     ���ݹ��� Ȯ��(�⺻): 7%
    Body_Durability Neck;
    // ��Ÿ����     ���ݹ��� Ȯ��(�⺻): 9%
    Body_Durability Groin;
    // �� �����     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Durability Left_thigh;
    // ���� �����     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Durability Right_thigh;
    // �� ������     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Durability Left_shin;
    // ���� ������     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Durability Right_shin;
    // �޹�     ���ݹ��� Ȯ��(�⺻): 1%
    Body_Durability Left_foot;
    // ������     ���ݹ��� Ȯ��(�⺻): 1%
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
