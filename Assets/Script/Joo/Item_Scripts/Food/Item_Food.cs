using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item_Food : ScriptableObject
{
    public Food_Type FoodType;
    public int Food_ID; // �� ���Ŀ� ���� ����ID

    public string FoodName;


    public bool Is_Perishable;  // false = ������� ���� ��ǰ
    public Sprite[] fresh_stale_rotten;



}
