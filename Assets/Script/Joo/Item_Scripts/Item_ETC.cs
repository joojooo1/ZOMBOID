using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_ETC : ScriptableObject
{
    public Type type;
    public Using_Type Usingtype;
    public int ETC_ID; // �� ���⿡ ���� ����ID

    public string ETC_Name;
    public string ETC_Name_kr;
    public Sprite ETC_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public bool Is_Consumable;   // �Ҹ�ǰ�̸� true

    public float ETC_Weight;
    public int ETC_Capacity;
    // �Ҹ�ǰ: ��� ������ Ƚ��
    public float ETC_value;
    // �Ҹ�ǰ: ���� ����Ǵ� ��
    // repair ������) �����Ǵ� ������ ����
}
