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

    public List<Item_Clothing> clothing_Ins;
    public List<Item_Container> Container_Ins;
    public List<Item_Electronics> electronics_Ins;
    public List<Item_ETC> ETC_Ins;
    public List<Item_Farming> Farming_Ins;
    public List<Item_Food> food_Ins;
    public List<Item_Furniture> furniture_Ins;
    public List<Item_Literature> literature_Ins;
    public List<Item_Medical> medical_Ins;
    public List<Item_Tool> Tool_Ins;
    public List<Item_Weapons> weapons_Ins;

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
                Sprite Img1 = food_Ins[ID].Food_Image[0];
                //Debug.Log("IDB image send");
                return Img1;
            case 8:
                Sprite Img8 = Container_Ins[ID].Container_Image;
                //Debug.Log("IDB image send");
                return Img8;
            default:
                //Debug.Log("IDB image null");
                return null;
        }
    }
    public short Requesting_Size(short item_Type, short ID) // 크기 3자릿수
    {
        switch (item_Type)
        {
            case 1:
                short num1 = 0;
                num1 += (short)(food_Ins[ID].Width*100);
                num1 += (short)0;
                num1 += (short)(food_Ins[ID].Height);
                return num1;
            case 8: //※ 가방쪽 예외처리
                short num8 = 0;
                if (ID < 8)
                {
                    num8 += (short)(((int)((Container_Ins[ID].Width) / 2)) * 100);
                    num8 += (short)0;
                    num8 += (short)((int)((Container_Ins[ID].Height) / 2));
                }
                else
                {
                    num8 += (short)((Container_Ins[ID].Width) * 100);
                    num8 += (short)0;
                    num8 += (short)(Container_Ins[ID].Height);
                }
                return num8;
            default:
                return 0;
        }
    }
    public int Requesting_Original_Width(int Type, int ID)
    {
        int Width = 0;

        switch (Type)
        {
            case 1:
                Width = (int)food_Ins[ID].Width;
                break;
            case 8:
                Width = (int)Container_Ins[ID].Width;
                break;
        }
        return Width;
    }
    public int Requesting_Original_Height(int Type, int ID)
    {
        int Height = 0;

        switch (Type)
        {
            case 1:
                Height = (int)food_Ins[ID].Height;
                break;
            case 8:
                Height = (int)Container_Ins[ID].Height;
                break;
        }
        return Height;
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
