using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Tool : ScriptableObject   // 무기로 쓰이지 않는 도구
{
    public Type type;
    public Using_Type[] Usingtype;

    public string Tool_Name;
    public string Tool_Name_Kr;
    public Sprite Tool_Image;
    public float Tool_Weight;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public bool Is_Equipping;  // 장비 여부
    public bool Is_TwoHand;
    public body_point[] Equipping_Position;  // 장비 위치

    public bool Is_Weapon;

    public float Condition;  // 내구도


    // Using_Type 이 Container 인 경우
    public float Capacity_Water;
    public float Rain_factor;  // 빗물 차는 속도

    public bool Is_Empty;

    public bool Store_Water;
    public bool Store_Oil;
    public bool On_Fire;
    public bool On_Microwave;

}
