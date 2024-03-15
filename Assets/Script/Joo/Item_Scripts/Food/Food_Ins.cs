using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Food> food_Ins;
    [SerializeField]
    private GameObject Food_Prefab;
    [SerializeField]
    UnityEngine.UI.Text FoodCount;
    private void Start()
    {
           // test
    }


    // 비어있는 오브젝트(선반 등)와 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_item(Location_Type location_Type)
    {        
        List<Item_Food> food_List = new List<Item_Food>();  // 생성위치에 맞는 아이템 List
        for(int i = 0; i < food_Ins.Count; i++)
        {
            if (food_Ins[i].Location == location_Type)
                food_List.Add(food_Ins[i]);
        }

        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~8개 생성

        GameObject obj = null;
        for (int i = 0; i < Count; i++)
        {
            System.Random rand_item = new System.Random();
            int item = rand_item.Next(0, food_List.Count);

            Instan(food_List[item]);
        }

    }

    public Food Instan(Item_Food food)
    {

        Food newFood = Instantiate(Food_Prefab).GetComponent<Food>();
        return newFood;
    }
}
