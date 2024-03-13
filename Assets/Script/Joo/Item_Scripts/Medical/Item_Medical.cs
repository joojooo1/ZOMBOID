using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Medical : ScriptableObject
{
    public Medical_Type MedicalType;

    public int Medical_ID;


    public string MedicalName;
    public string MedicalName_Kr;
    public float MedicalWeight;
    public Sprite Medical_Image;

    public bool Is_Disinfection;
    public bool Is_Clean;

    public float Power;
    /*
     Bandage_Power: 상처회복속도
     Disinfectant_Power: 소독할수있는 횟수
     Pharmaceutical_Power: 
        - Antibiotics : 상처감염확률 down
        - Antidepressants : 불행 down
        - Beta Blockers : 긴장 down
        - Cigarettes : 스트레스 down
        - Painkillers : 통증 down
        - Sleeping Tablets : 통증 down ( 잘수있게 )
        - Vitamins : 피로 down
     
     */


}
