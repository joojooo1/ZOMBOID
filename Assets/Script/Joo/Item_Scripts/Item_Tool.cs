using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Tool : ScriptableObject   // ����� ������ �ʴ� ����
{
    public Type type;
    public Using_Type[] Usingtype;

    public string Tool_Name;
    public string Tool_Name_Kr;
    public Sprite Tool_Image;
    public float Tool_Weight;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public bool Is_Equipping;  // ��� ����
    public bool Is_TwoHand;
    public body_point[] Equipping_Position;  // ��� ��ġ

    public bool Is_Weapon;

    public float Condition;  // ������


    // Using_Type �� Container �� ���
    public float Capacity_Water;
    public float Rain_factor;  // ���� ���� �ӵ�

    public bool Is_Empty;

    public bool Store_Water;
    public bool Store_Oil;
    public bool On_Fire;
    public bool On_Microwave;

}
