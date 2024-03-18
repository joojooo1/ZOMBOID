using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Ins : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image Icon;
    [SerializeField]
    UnityEngine.UI.Text Item_Info;

    Item_Food FoodData;
    Item_Medical MedicalData;
    Item_Weapons WeaponsData;

    public int CurrentID;
    public Item_Type CurrentType;
    public void SetItem(Item_Type type, int ItemCode)
    {
        CurrentID = ItemCode;
        CurrentType = type;
        Icon.color = Color.white;
        switch (type)
        {
            case Item_Type.Food:
                FoodData = Item_DataBase.item_database.Get_Foodlist(ItemCode);
                Icon.sprite = FoodData.Food_Image[0];
                if(FoodData.FoodType != Food_Type.Drink)
                {
                    FoodData.Height = 1;
                    FoodData.Width = 1;
                }
                break;
            case Item_Type.Medical:
                MedicalData = Item_DataBase.item_database.Get_Medicallist(ItemCode);
                Icon.sprite = MedicalData.Medical_Image;
                MedicalData.Height = 1;
                MedicalData.Width = 1;
                break;
            case Item_Type.Weapons:
                WeaponsData = Item_DataBase.item_database.Get_Weaponslist(ItemCode);
                Icon.sprite = WeaponsData.ItemImage;
                break;
             default:
                Icon.sprite =null;
                Icon.color = new Color(0,0,0, 0.6679f);
                break;
        }

        
    }


    public void ShowSelectItem()
    {
        Item_DataBase.item_database.OpenDetail(CurrentType, CurrentID);
    }


    /*******  Food  *******/

    // 비어있는 오브젝트(선반 등)와 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_item(Location_Type location_Type)
    {
        List<Item_Food> food_List = new List<Item_Food>();  // 생성위치에 맞는 아이템 List
        for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
        {
            //if (food_Ins[i].Location == location_Type)
            //    food_List.Add(food_Ins[i]);
        }

        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~8개 생성

        GameObject obj = null;
        for (int i = 0; i < Count; i++)
        {
            System.Random rand_item = new System.Random();
            int item = rand_item.Next(0, food_List.Count);

        }

    }


    // Medical


    // Weapons


    // 
}
