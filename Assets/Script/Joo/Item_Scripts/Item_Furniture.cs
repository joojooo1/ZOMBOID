using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Furniture : ScriptableObject
{
    public Type type;
    public int Furniture_ID; // 고유ID

    public string Furniture_Name;
    public string Furniture_Name_kr;
    public Sprite Furniture_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public float Furniture_Weight;




}
