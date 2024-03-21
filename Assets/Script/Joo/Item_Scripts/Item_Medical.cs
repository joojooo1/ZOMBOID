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
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

    public bool Is_Disinfection;
    public bool Is_Clean;
    public bool Is_Ins;

    public int Capacity;
    public float Power;
    /*
     Bandage_Power: ��óȸ���ӵ�
     Disinfectant_Power: �ҵ��Ҽ��ִ� Ƚ��
     Herb_BlackSage: ���� ��ȭ
     Herb_Poultice: ��óȸ���ӵ�
     Pharmaceutical_Power: 
        - Antibiotics : ��ó����Ȯ�� 50% down
        - Antidepressants : ���� ���������� down
        - Beta Blockers : ���尨�Ҽӵ� 1.5�� up
        - Cigarettes : ��Ʈ���� 5 down
        - Painkillers : ���� 10 down
        - Sleeping Tablets : ���� down ( �߼��ְ� )
        - Vitamins : �Ƿ� 20 down
     
     */


}
