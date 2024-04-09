using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_DataBase : MonoBehaviour
{
    public static Item_DataBase item_database;

    public enum Item_Type
    {
        empty = 0,
        Food_Ins = 1,
        Medical_Ins = 2,
        Weapons_Ins = 3,
        Literature_Ins = 4,
        Electronics_Ins = 5,
        Clothing_Ins = 6,
        Gardening_Ins = 7,
        Container_Ins = 8
    }

    private void Awake()
    {
        if (item_database == null)
        {
            item_database = this;
        }
    }

    public List<Item_Food> food_Ins;
    public List<Item_Medical> medical_Ins;
    public List<Item_Weapons> weapons_Ins;
    public List<Item_Literature> literature_Ins;
    public List<Item_Electronics> electronics_Ins;
    public List<Item_Clothing> clothing_Ins;
    public List<Item_Gardening> gardening_Ins;
    public List<Item_Container> Container_Ins;

    public void Requesting_Baisics(Item_Type item_Type, short ID)
    {
        //switch (item_Type)
        //{
        //    case Item_Type.Food_Ins:
        //        food_Ins[ID]
        //        break;
        //    case Item_Type.Medical_Ins:
        //        itemList = medical_Ins.Cast<object>().ToList();
        //        break;
            
        //    default:
        //        break;
        //}
    }
    public bool Requesting_Depth(Item_Type item_Type, short ID, short Now_Amount)
    {
        bool canbe = false;
        return canbe;
    }
    public Sprite Requesting_Image(short item_Type, short ID) // 이미지 현재 원본
    {
        switch (item_Type)
        {
            case 1:
                Sprite Img = food_Ins[ID].Food_Image[0];
                Debug.Log("IDB image send");
                return Img;
            default:
                Debug.Log("IDB image null");
                return null;
        }
    }
    public short Requesting_Size(Item_Type item_Type, short ID) // 크기 3자릿수
    {
        switch (item_Type)
        {
            case Item_Type.Food_Ins:
                short num = 0;
                num += (short)(food_Ins[ID].Width*100);
                num += (short)0;
                num += (short)(food_Ins[ID].Height);
                return num;
            default:
                Debug.Log("IDB image null");
                return 0;
        }
    }
    public short Requesting_Wei;
    Item_Ins DetailWindow;

    //public void OpenDetail(Item_Type type, int ItemCode)
    //{
    //    DetailWindow.SetItem(type, ItemCode);
    //    DetailWindow.gameObject.SetActive(true);
    //}

    public void CloseDetail()
    {
        DetailWindow.gameObject.SetActive(false);
    }
}
