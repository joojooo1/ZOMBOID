using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Container : ScriptableObject
{
    public Type type;
    public Container_Type container_Type;
    public Using_Type Usingtype;
    public Area_Type[] areaType;   // �����Ǵ� �ǹ�
    public Location_Type Location;  // �����Ǵ� Container ��
    public CanBeEquipped_Bag Bag_EquipType;

    public int Container_ID;

    public string ContainerName;
    public string ContainerName_Kr;
    public float ContainergWeight;
    public Sprite Container_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public float WeightReduction;
    public float RunSpeedModifier;

    // ���� �� �ִ� ���� ���� x ( ĭ���� ���� )
    // UI : ���� ������ �ݿ��ؼ� ����ִ� �� ���� / ����ִ� ����
    // ü��, �ٷ� �� ���� �ɷ�ġ�� ����ִ� ���� ��� ( �� �̻� ��� ���� �߻� )

    /*  Water Container */
    public bool Store_Water;
    public bool Store_Oil;
    public bool On_Fire;
    public bool On_microwave;

    public float Capacity_Water;
    public float Rain_factor;

}
