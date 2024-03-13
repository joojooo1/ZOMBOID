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
     Bandage_Power: ��óȸ���ӵ�
     Disinfectant_Power: �ҵ��Ҽ��ִ� Ƚ��
     Pharmaceutical_Power: 
        - Antibiotics : ��ó����Ȯ�� down
        - Antidepressants : ���� down
        - Beta Blockers : ���� down
        - Cigarettes : ��Ʈ���� down
        - Painkillers : ���� down
        - Sleeping Tablets : ���� down ( �߼��ְ� )
        - Vitamins : �Ƿ� down
     
     */


}
