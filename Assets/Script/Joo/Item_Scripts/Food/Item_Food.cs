using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Food : ScriptableObject
{
    public Food_Type FoodType;
    public int Food_ID; // 각 음식에 대한 고유ID

    public string FoodName;


    public bool Is_Perishable;  // false = 유통기한 없는 식품
    public Sprite[] fresh_stale_rotten;
    public bool Is_freezing;
    public bool Is_Cooking;  // false = 단독으로 조리 불가. 요리 재료로 첨가는 가능










}
