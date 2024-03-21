using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Medical : ScriptableObject
{
    public Type type;
    public Medical_Type MedicalType;
    public Using_Type Usingtype;
    public PowerSources_Type Power_type;
    public bool created;

    public int Medical_ID;

    public string MedicalName;
    public string MedicalName_Kr;
    public float MedicalWeight;
    public Sprite Medical_Image;

    public float Height;
    public float Width;
    public int Nesting_Depth;  // 최대로 중첩되는 갯수

    public bool Is_Disinfection;
    public bool Is_Clean;
    public bool Is_Ins;

    public int Capacity;
    public float Power;
    /*
     Bandage_Power: 상처회복속도
     Disinfectant_Power: 소독할수있는 횟수
     Herb_BlackSage: 통증 완화
     Herb_Poultice: 상처회복속도
     Pharmaceutical_Power: 
        - Antibiotics : 상처감염확률 50% down
        - Antidepressants : 불행 지속적으로 down
        - Beta Blockers : 긴장감소속도 1.5배 up
        - Cigarettes : 스트레스 5 down
        - Painkillers : 통증 10 down
        - Sleeping Tablets : 통증 down ( 잘수있게 )
        - Vitamins : 피로 20 down
     
     */


}
