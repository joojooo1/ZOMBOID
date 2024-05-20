using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Electronics : ScriptableObject
{
    public Type type;
    public Using_Type usingtype;
    public Electronic_usingType electronic_usingType;
    public PowerSources_Type Power_type;  // ������ or �����ϴ� ������ Ÿ��
    public PowerSources_Type UsingPower_type;  // ����ϴ� ������ Ÿ��
    public body_point[] Equipping_Position;
    public int Electronics_ID;
    public animType animType;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public string ElectronicsName;
    public string ElectronicsName_Kr;
    public float ElectronicsWeight;
    public Sprite Electronics_Image;

    public bool On;
    public GameObject PowerSources_Item;

    public int Capacity;  // PowerSources Ÿ�Կ��� ����
                          // ���� ���� ����� PowerSources�� �뷮�� �پ��

    public float Range;  // �������� ���� ���� 20
                         // ����: �����ִ� ����

    public float Condition;  // ������ 4% + (0.5 * ����level)%�� ����


}
