using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

[CreateAssetMenu]
public class Item_Food : ScriptableObject
{
    public Type type;
    public Food_Type FoodType;
    public int Food_ID; // 각 음식에 대한 고유ID
    public Cooking_State FoodState;
    public float Cooking_time_to_NextStep;  // 다음 단계로 넘어가는데 걸리는 시간 ( 기존값 / 5 )

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

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
    public bool Is_Spice;  // true = 요리재료 갯수에 포함 x
    public bool Usable_as_bottle;
    public bool Ingredients_Cooked;

    public float F_Calories;  // 칼로리
    public float F_Thirst;  // 갈증

    public float[] F_Satiety;  // 포만감
    public float[] F_Unhappiness;  // 불행
    public float[] F_Boredom;  // 지루함
    public float[] F_Fatigue;  // 피로

    public float Probability_of_poisoning;
    // 식중독 일으킬 확률    10% 상승 ( 임의 설정 )
    // 일반적으로 신선도가 Rotten일 경우 발생 ( Fish 는 Uncooked 인 상태에서도 발생 )
    public float Sterilize_Power;
    // 알코올일 경우 소독할 수 있는 횟수


    // 캔 음식은 오픈하면 Perishable 을  true 로 바꿔야됨
}
