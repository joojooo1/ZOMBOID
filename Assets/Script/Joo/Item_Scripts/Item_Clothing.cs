using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Clothing : ScriptableObject
{
    public Type type;
    public Clothing_Type ClothingType;
    public int Clothing_ID; // 각 무기에 대한 고유ID

    public string Clothing_Name;
    public string Clothing_Name_kr;
    public Sprite ClothingImage;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public bool Is_Equipping;
    //public body_point Equipping_Position;  // 장비 위치
    public float Defense;  // 각 공격에 대한 방어의 평균값으로 적용
    public float Neck_Defense;  // 목 부위만 별도로 계산
    public float Insulation;  // 단열
    public float Wind_resistance;  // 찬바람 저항

    public bool Is_Cotton; // 찢어진 천 생성 가능

    public float ClothingWeight;
    public int Item_index;



}
