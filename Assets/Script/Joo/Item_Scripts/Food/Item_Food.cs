using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Food : ScriptableObject
{
    public Food_Type FoodType;
    public int Food_ID; // 각 음식에 대한 고유ID
    public Cooking_State FoodState;
    public float Cooking_time_to_NextStep;


    public string FoodName;
    public string FoodName_Kr;
    public float FoodWeight;
    public Sprite[] Food_Image;

    public bool Is_Perishable;  // false = 유통기한 없는 식품 ( 통조림 오픈시 true )
    public Freshness_Level Freshness;
    public float Preservation_period_for_freshness;  // 신선한 상태 유지기간(days)
    public float Preservation_period_for_stale;  // 신선하지 않은 상태 유지기간(days)

    public bool Is_freezing;

    public bool Is_Canned;
    public bool Is_Alcoholic;
    public bool Is_Spice;

    public float F_Calories;  // 칼로리
    public float F_Thirst;  // 갈증

    public float[] F_Satiety;  // 포만감
    public float F_Unhappiness;  // 불행
    /* [기본값] Fresh: 0, stale: +10, rotten: + 20  ( burned 일때는 모두 +20 ) 에 추가되는 값 */
    public float F_Boredom;  // 지루함
    /* [기본값] Fresh: 0, stale: +10, rotten: + 20  ( burned 일때는 모두 +20 ) 에 추가되는 값 */
    public float F_Fatigue;  // 피로

    // public bool[] Probability_of_poisoning;  
    // 식중독 일으킬 확률   true면 15% 상승 ( 임의 설정 )
    // Uncooked(state) || Burned(state) || Rotten(freshness) 이면 true


}
