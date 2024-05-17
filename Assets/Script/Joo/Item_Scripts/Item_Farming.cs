using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Farming : ScriptableObject
{
    public Type type;
    public Using_Type Usingtype;
    public int Gardening_ID; // 고유ID

    public string Gardening_Name;
    public string Gardening_Name_kr;
    public Sprite Gardening_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public float Gardening_Weight;
    public float Sowed_Count;  // 한 번 뿌릴때 소모되는 씨앗 갯수
    public float Water_Count;  // 경작 시 필요한 물
    public float Grow_time;  // 수확까지 걸리는 시간(day 기준)  // 위키정보/2 정도로 조정

    public Food_Type Harvest_item_type;
    public string Harvest_item_name;


    // 심고나서 확인사항
      // 비료를 뿌렸는지
      // 수확될 갯수, 수확될 아이템
      // 농사 관련 skill 경험치 획득
}
