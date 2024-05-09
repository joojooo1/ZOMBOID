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
    Item_Literature LiteratureData;
    Item_Electronics ElectronicsData;
    Item_Clothing ClothingData;
    Item_Farming GardeningData;
    Item_Container ContainerData;

    public int CurrentID;
    //public Item_Type CurrentType;
    //public void SetItem(Item_Type type, int ItemCode)
    //{
    //    CurrentID = ItemCode;
    //    CurrentType = type;
    //    Icon.color = Color.white;
    //    switch (type)
    //    {
    //        case Item_Type.Food:
    //            FoodData = Item_DataBase.item_database.food_Ins[ItemCode];
    //            Icon.sprite = FoodData.Food_Image[0];
    //            break;
    //        case Item_Type.Medical:
    //            MedicalData = Item_DataBase.item_database.medical_Ins[ItemCode];
    //            Icon.sprite = MedicalData.Medical_Image;
    //            break;
    //        case Item_Type.Weapons:
    //            WeaponsData = Item_DataBase.item_database.weapons_Ins[ItemCode];
    //            Icon.sprite = WeaponsData.ItemImage;
    //            break;
    //        case Item_Type.Literature:
    //            LiteratureData = Item_DataBase.item_database.literature_Ins[ItemCode];
    //            Icon.sprite = LiteratureData.Literature_Image;
    //            break;
    //        case Item_Type.Electronics: 

    //            break;
    //        case Item_Type.Clothing: 
    //            break;
    //        case Item_Type.Gardening: 
    //            break;
    //        case Item_Type.Container:
    //            ContainerData = Item_DataBase.item_database.Container_Ins[ItemCode];
    //            Icon.sprite = ContainerData.Container_Image;
    //            break;
    //         default:
    //            Icon.sprite =null;
    //            Icon.color = new Color(0,0,0, 0.6679f);
    //            break;
    //    }

        
    //}


    //public void ShowSelectItem()
    //{
    //    Item_DataBase.item_database.OpenDetail(CurrentType, CurrentID);
    //}


    
}
