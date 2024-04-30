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
    public body_point Equipping_Position;  // 장비 위치

    public float ClothingWeight;




}
