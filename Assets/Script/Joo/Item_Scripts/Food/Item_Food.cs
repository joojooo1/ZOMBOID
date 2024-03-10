using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Food : ScriptableObject
{
    public Food_Type FoodType;
    public int Food_ID; // �� ���Ŀ� ���� ����ID
    public Cooking_State FoodState;
    public float Cooking_time_to_NextStep;


    public string FoodName;
    public string FoodName_Kr;
    public float FoodWeight;
    public Sprite[] Food_Image;

    public bool Is_Perishable;  // false = ������� ���� ��ǰ ( ������ ���½� true )
    public Freshness_Level Freshness;
    public float Preservation_period_for_freshness;  // �ż��� ���� �����Ⱓ(days)
    public float Preservation_period_for_stale;  // �ż����� ���� ���� �����Ⱓ(days)

    public bool Is_freezing;

    public bool Is_Canned;
    public bool Is_Alcoholic;
    public bool Is_Spice;

    public float F_Calories;  // Į�θ�
    public float F_Thirst;  // ����

    public float[] F_Satiety;  // ������
    public float F_Unhappiness;  // ����
    /* [�⺻��] Fresh: 0, stale: +10, rotten: + 20  ( burned �϶��� ��� +20 ) �� �߰��Ǵ� �� */
    public float F_Boredom;  // ������
    /* [�⺻��] Fresh: 0, stale: +10, rotten: + 20  ( burned �϶��� ��� +20 ) �� �߰��Ǵ� �� */
    public float F_Fatigue;  // �Ƿ�

    // public bool[] Probability_of_poisoning;  
    // ���ߵ� ����ų Ȯ��   true�� 15% ��� ( ���� ���� )
    // Uncooked(state) || Burned(state) || Rotten(freshness) �̸� true


}
