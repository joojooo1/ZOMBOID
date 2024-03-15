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
                break;
            case Item_Type.Medical:
                MedicalData = Item_DataBase.item_database.Get_Medicallist(ItemCode);
                Icon.sprite = MedicalData.Medical_Image;
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
}
