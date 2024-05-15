using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Container : ScriptableObject
{
    public Type type;
    public Container_Type container_Type;
    public Using_Type Usingtype;
    public CanBeEquipped_Bag Bag_EquipType;
    public Bag_Type bag_Type;
    public Clothing_Type ClothingType;

    public int Container_ID;

    public string ContainerName;
    public string ContainerName_Kr;
    public float ContainergWeight;
    public Sprite Container_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public float WeightReduction;

    // 넣을 수 있는 무게 제한 x ( 칸으로 제한 )
    // UI : 무게 감소율 반영해서 들고있는 총 무게 / 들수있는 무게
    // 체력, 근력 등 유저 능력치로 들수있는 무게 계산 ( 그 이상 들면 무들 발생 )

    /*  Water Container */
    public bool Store_Water;
    public bool Store_Oil;
    public bool On_Fire;
    public bool On_Microwave;

    public bool Is_Empty;

    public float Capacity;  // 물
    public float Rain_factor;  // 빗물 차는 속도
    public int Item_Index;

}
