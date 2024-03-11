using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Ins : MonoBehaviour
{
    [SerializeField]
    private List<Item_Food> food_Ins;
    [SerializeField]
    private GameObject Food_Prefab;

    private void Start()
    {
           // test
    }


    // 비어있는 오브젝트(선반 등)와 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_item(Location_Type location_Type)
    {        
        System.Random rand = new System.Random();
        int Count = rand.Next(0, 6);

        for (int i = 0; i < Count; i++)
        {
            System.Random rand_item = new System.Random();
            int item_number = rand.Next(0, 6);
        }

    }

    public Food Instan(Item_Food food)
    {
        Food newFood = Instantiate(Food_Prefab).GetComponent<Food>();
        newFood.foodData = food;
        return newFood;
    }
}
