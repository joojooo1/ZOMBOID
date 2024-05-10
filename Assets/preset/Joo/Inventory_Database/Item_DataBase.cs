using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_DataBase : MonoBehaviour
{
    public static Item_DataBase item_database;

    //public enum Item_Type
    //{
    //    empty = 0,
    //    Food_Ins = 1,
    //    Medical_Ins = 2,
    //    Weapons_Ins = 3,
    //    Literature_Ins = 4,
    //    Electronics_Ins = 5,
    //    Clothing_Ins = 6,
    //    Gardening_Ins = 7,
    //    Container_Ins = 8,
    //    ETC_Ins = 9
    //}

    public enum Item_Type
    {
        Empty = 0,
        Farming = 1,
        food = 2,
        Normal = 3,
        literature = 4,
        Tool = 5,
        clothing = 6,
        Container = 7,
        Electronics = 8,
        Medical = 9,
        Furniture = 10,
        weapon = 11
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
            case 2:
                Sprite Img2 = food_Ins[ID].Food_Image[0];
                return Img2;
            case 3:
                Sprite Img3 = ETC_Ins[ID].ETC_Image;
                return Img3;
            case 4:
                Sprite Img4 = literature_Ins[ID].Literature_Image;
                return Img4;
            case 6:
                Sprite Img6 = clothing_Ins[ID].ClothingImage;
                return Img6;
            case 7:
                Sprite Img7 = Container_Ins[ID].Container_Image;
                return Img7;
            case 8:
                Sprite Img8 = electronics_Ins[ID].Electronics_Image;
                return Img8;
            case 9:
                Sprite Img9 = medical_Ins[ID].Medical_Image;
                return Img9;
            case 10:
                Sprite Img10 = furniture_Ins[ID].Furniture_Image;
                return Img10;
            default:
                return null;
        }
    }
    public short Requesting_Size(short item_Type, short ID) // 크기 3자릿수
    {
        switch (item_Type)
        {
            case 2:
                short num2 = 0;
                num2 += (short)(food_Ins[ID].Width * 100);
                num2 += (short)0;
                num2 += (short)(food_Ins[ID].Height);
                return num2;
            case 7: //※ 가방쪽 예외처리
                short num7 = 0;
                if (ID < 8)
                {
                    num7 += (short)(((int)((Container_Ins[ID].Width) / 2)) * 100);
                    num7 += (short)0;
                    num7 += (short)((int)((Container_Ins[ID].Height) / 2));
                }
                else
                {
                    num7 += (short)((Container_Ins[ID].Width) * 100);
                    num7 += (short)0;
                    num7 += (short)(Container_Ins[ID].Height);
                }
                return num7;
            case 9:
                short num9 = 0;
                num9 += (short)(medical_Ins[ID].Width * 100);
                num9 += (short)0;
                num9 += (short)(medical_Ins[ID].Height);
                return num9;
            default:
                return 0;
        }
    }
    public int Requesting_Original_Width(int Type, int ID)
    {
        int Width = 0;

        switch (Type)
        {
            case 2:
                Width = (int)food_Ins[ID].Width;
                break;
            case 9:
                Width = (int)medical_Ins[ID].Width;
                break;
            case 7:
                Width = (int)Container_Ins[ID].Width;
                break;
            case 3:
                Width = (int)ETC_Ins[ID].Width;
                break;
        }
        return Width;
    }
    public int Requesting_Original_Height(int Type, int ID)
    {
        int Height = 0;

        switch (Type)
        {
            case 2:
                Height = (int)food_Ins[ID].Height;
                break;
            case 9:
                Height = (int)medical_Ins[ID].Height;
                break;
            case 7:
                Height = (int)Container_Ins[ID].Height;
                break;
            case 3:
                Height = (int)ETC_Ins[ID].Height;
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
