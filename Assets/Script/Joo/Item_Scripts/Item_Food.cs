using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

[CreateAssetMenu]
public class Item_Food : ScriptableObject
{
    public Type type;
    public Food_Type FoodType;
    public int Food_ID; // �� ���Ŀ� ���� ����ID
    public Cooking_State FoodState;
    public float Cooking_time_to_NextStep;  // ���� �ܰ�� �Ѿ�µ� �ɸ��� �ð� ( ������ / 5 )

    public float Height;
    public float Width;
    public int Nesting_Depth;  // �ִ�� ��ø�Ǵ� ����

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
    public bool Is_Spice;  // true = �丮��� ������ ���� x
    public bool Usable_as_bottle;
    public bool Ingredients_Cooked;

    public float F_Calories;  // Į�θ�
    public float F_Thirst;  // ����

    public float[] F_Satiety;  // ������
    public float[] F_Unhappiness;  // ����
    public float[] F_Boredom;  // ������
    public float[] F_Fatigue;  // �Ƿ�

    public float Probability_of_poisoning;
    // ���ߵ� ����ų Ȯ��    10% ��� ( ���� ���� )
    // �Ϲ������� �ż����� Rotten�� ��� �߻� ( Fish �� Uncooked �� ���¿����� �߻� )
    public float Sterilize_Power;
    // ���ڿ��� ��� �ҵ��� �� �ִ� Ƚ��


    // ĵ ������ �����ϸ� Perishable ��  true �� �ٲ�ߵ�
}
