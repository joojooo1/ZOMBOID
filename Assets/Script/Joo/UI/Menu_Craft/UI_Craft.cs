using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public enum Crafting_type
{
    Crafting_General = 0,
    Crafting_Tool = 1,
    Crafting_Cook = 2,
    Crafting_Medical = 3,
    Crafting_Furniture = 4
}

public class Crafting_item
{
    public Type item_DB_type;
    public int item_DB_ID;
    public Crafting_type item_type;
    public Sprite item_Image;
    public string name;
    public string name_kr;

    public float item_Calories;  // 칼로리
    public float item_Thirst;  // 갈증

    public List<float> item_Satiety = new List<float>();  // 포만감
    public List<float> item_Unhappiness = new List<float>();  // 불행
    public List<float> item_Boredom = new List<float>();  // 지루함
    public List<float> item_Fatigue = new List<float>();  // 피로
    public List<float> item_Stress = new List<float>();  // 스트레스

    public List<Crafting_Ingredients> Ingredients_list;

    public Crafting_item(Type item_DB_type, int item_DB_ID, Crafting_type item_type, Sprite item_Image, string name, string name_kr)
    {
        this.item_DB_type = item_DB_type;
        this.item_DB_ID = item_DB_ID;
        this.item_type = item_type;
        this.item_Image = item_Image;
        this.name = name;
        this.name_kr = name_kr;
        Ingredients_list = new List<Crafting_Ingredients>();

        switch (item_DB_type)
        {
            case Type.food:
                if (Item_DataBase.item_database.food_Ins[item_DB_ID].FoodType == Food_Type.Cooking)
                {
                    if(item_Satiety == null)
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            item_Satiety.Add(0);
                        }               
                    }

                    if(item_Unhappiness == null)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            item_Unhappiness.Add(0);
                        }
                    }

                    if(item_Boredom == null)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            item_Boredom.Add(0);
                        }                        
                    }

                    if(item_Fatigue == null)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            item_Fatigue.Add(0);
                        }                        
                    }

                    for (int j = 0; j < Ingredients_list.Count; j++)
                    {
                        item_Calories += (Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Calories * 1.05f);
                        item_Thirst += (Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Thirst * 1.05f);

                        for (int i = 0; i < 3; i++)
                        {
                            item_Satiety[i] += (Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Satiety[i] * 1.05f);
                            item_Unhappiness[i] += (Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Unhappiness[i] * 1.05f);
                            item_Boredom[i] += (Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Boredom[i] * 1.05f);
                            item_Fatigue[i] += (Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Fatigue[i] * 1.05f);
                        }
                    }
                }
                else
                {
                    item_Calories = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Calories;
                    item_Thirst = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Thirst;

                    for (int i = 0; i < 3; i++)
                    {
                        item_Satiety[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Satiety[i];
                        item_Unhappiness[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Unhappiness[i];
                        item_Boredom[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Boredom[i];
                        item_Fatigue[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Fatigue[i];
                    }
                }
                break;
            case Type.literature:
                if (Item_DataBase.item_database.literature_Ins[item_DB_ID].LiteratureType == Book_Type.Leisure)
                {
                    item_Unhappiness.Add(Item_DataBase.item_database.literature_Ins[item_DB_ID].L_Unhappiness);
                    item_Stress.Add(Item_DataBase.item_database.literature_Ins[item_DB_ID].L_Stress);
                    item_Boredom.Add(Item_DataBase.item_database.literature_Ins[item_DB_ID].L_Boredom);
                }
                break;
        }
        

    }

    public string Get_name()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return name_kr;
        }
        else
        {
            return name;
        }
    }

    public void Add_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Crafting_Ingredients Ingredients = new Crafting_Ingredients(_DB_type, _DB_ID, value);
        if(Ingredients_list.Count > 0)
        {
            for (int i = 0; i < Ingredients_list.Count; i++)
            {
                if (Ingredients_list[i].Ingredients_DB_type == _DB_type && Ingredients_list[i].Ingredients_DB_ID == _DB_ID)
                {
                    break;
                }
                else
                {
                    if (i == Ingredients_list.Count - 1)
                    {
                        Ingredients_list.Add(Ingredients);
                    }
                }
            }
        }
        else
        {
            Ingredients_list.Add(Ingredients);
        }

    }

    public Sprite Get_Ingredients_Image(int index)
    {
        return Ingredients_list[index].Ingredients_Image;
    }

    public string Get_Ingredients_name(int index)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            return Ingredients_list[index].Ingredients_name_kr;
        }
        else
        {
            return Ingredients_list[index].Ingredients_name;
        }        
    }

    public bool Get_Ingredients_required(int index, int currentValue)
    {
        if(Ingredients_list[index].Value <= currentValue)
        {
            Ingredients_list[index].fulfill = true;
        }

        return Ingredients_list[index].fulfill;
    }

    public int Get_Ingredients_value(int index)
    {
        return Ingredients_list[index].Value;
    }
}

public class Crafting_Ingredients
{
    public Type Ingredients_DB_type;
    public int Ingredients_DB_ID;
    public Sprite Ingredients_Image;
    public string Ingredients_name;
    public string Ingredients_name_kr;
    public int Value;  // 필요한 갯수
    public bool fulfill;

    public Crafting_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Ingredients_DB_type = _DB_type;
        Ingredients_DB_ID = _DB_ID;
        Value = value;
        fulfill = false;

        switch (_DB_type)
        {
            case Type.food:
                Ingredients_Image = Item_DataBase.item_database.food_Ins[Ingredients_DB_ID].Food_Image[0];
                Ingredients_name = Item_DataBase.item_database.food_Ins[Ingredients_DB_ID].FoodName;
                Ingredients_name_kr = Item_DataBase.item_database.food_Ins[Ingredients_DB_ID].FoodName_Kr;
                break;
            case Type.Medical:
                Ingredients_Image = Item_DataBase.item_database.medical_Ins[Ingredients_DB_ID].Medical_Image;
                Ingredients_name = Item_DataBase.item_database.medical_Ins[Ingredients_DB_ID].MedicalName;
                Ingredients_name_kr = Item_DataBase.item_database.medical_Ins[Ingredients_DB_ID].MedicalName_Kr;
                break;
            case Type.weapon:
                Ingredients_Image = Item_DataBase.item_database.weapons_Ins[Ingredients_DB_ID].ItemImage;
                Ingredients_name = Item_DataBase.item_database.weapons_Ins[Ingredients_DB_ID].WeaponName;
                Ingredients_name_kr = Item_DataBase.item_database.weapons_Ins[Ingredients_DB_ID].WeaponName_Kr;
                break;
            case Type.literature:
                Ingredients_Image = Item_DataBase.item_database.literature_Ins[Ingredients_DB_ID].Literature_Image;
                Ingredients_name = Item_DataBase.item_database.literature_Ins[Ingredients_DB_ID].LiteratureName;
                Ingredients_name_kr = Item_DataBase.item_database.literature_Ins[Ingredients_DB_ID].LiteratureName_Kr;
                break;
            case Type.Electronics:
                Ingredients_Image = Item_DataBase.item_database.electronics_Ins[Ingredients_DB_ID].Electronics_Image;
                Ingredients_name = Item_DataBase.item_database.electronics_Ins[Ingredients_DB_ID].ElectronicsName;
                Ingredients_name_kr = Item_DataBase.item_database.electronics_Ins[Ingredients_DB_ID].ElectronicsName_Kr;
                break;
            case Type.clothing:
                Ingredients_Image = Item_DataBase.item_database.clothing_Ins[Ingredients_DB_ID].ClothingImage;
                Ingredients_name = Item_DataBase.item_database.clothing_Ins[Ingredients_DB_ID].Clothing_Name;
                Ingredients_name_kr = Item_DataBase.item_database.clothing_Ins[Ingredients_DB_ID].Clothing_Name_kr;
                break;
            case Type.Farming:
                Ingredients_Image = Item_DataBase.item_database.Farming_Ins[Ingredients_DB_ID].Gardening_Image;
                Ingredients_name = Item_DataBase.item_database.Farming_Ins[Ingredients_DB_ID].Gardening_Name;
                Ingredients_name_kr = Item_DataBase.item_database.Farming_Ins[Ingredients_DB_ID].Gardening_Name_kr;
                break;
            case Type.Container:
                Ingredients_Image = Item_DataBase.item_database.Container_Ins[Ingredients_DB_ID].Container_Image;
                Ingredients_name = Item_DataBase.item_database.Container_Ins[Ingredients_DB_ID].ContainerName;
                Ingredients_name_kr = Item_DataBase.item_database.Container_Ins[Ingredients_DB_ID].ContainerName_Kr;
                break;
            case Type.Normal:
                Ingredients_Image = Item_DataBase.item_database.ETC_Ins[Ingredients_DB_ID].ETC_Image;
                Ingredients_name = Item_DataBase.item_database.ETC_Ins[Ingredients_DB_ID].ETC_Name;
                Ingredients_name_kr = Item_DataBase.item_database.ETC_Ins[Ingredients_DB_ID].ETC_Name_kr;
                break;
            case Type.Furniture:
                Ingredients_Image = Item_DataBase.item_database.furniture_Ins[Ingredients_DB_ID].Furniture_Image;
                Ingredients_name = Item_DataBase.item_database.furniture_Ins[Ingredients_DB_ID].Furniture_Name;
                Ingredients_name_kr = Item_DataBase.item_database.furniture_Ins[Ingredients_DB_ID].Furniture_Name_kr;
                break;
            default: break;
        }

    }
}

public class UI_Craft : MonoBehaviour, IPointerClickHandler
{
    public static UI_Craft UI_Craft_main;

    public GameObject Craft_window;
    public Sprite[] Craft_Button_Image;
    public UnityEngine.UI.Image Craft_Button_current;

    public List<Crafting_item> Crafting_General_list;
    public List<Crafting_item> Crafting_Tool_list;
    public List<Crafting_item> Crafting_Cook_list;
    public List<Crafting_item> Crafting_Medical_list;
    public List<Crafting_item> Crafting_Furniture_list;

    private void Start()
    {
        UI_Craft_main = this;
        if (Craft_window.activeSelf) { Craft_Button_current.sprite = Craft_Button_Image[1]; }
        else { Craft_Button_current.sprite = Craft_Button_Image[0]; }

        Crafting_General_list = new List<Crafting_item>();
        Crafting_Tool_list = new List<Crafting_item>();
        Crafting_Cook_list = new List<Crafting_item>();
        Crafting_Medical_list = new List<Crafting_item>();
        Crafting_Furniture_list = new List<Crafting_item>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Craft_window.activeSelf)
        {
            Craft_window.SetActive(false);
            Craft_Button_current.sprite = Craft_Button_Image[0];
        }
        else
        {
            Craft_window.SetActive(true);
            Craft_Button_current.sprite = Craft_Button_Image[1];
            Craft_window.transform.SetAsLastSibling();
        }
    }

    public void Add_Crafting_list(Type item_DB_type, int item_DB_ID, Crafting_type item_type, Sprite item_Image, string name, string name_kr)
    {
        Crafting_item item = new Crafting_item(item_DB_type, item_DB_ID, item_type, item_Image, name, name_kr);   // 만들려는 아이템만 만듦 ( 재료 추가 전 )
        switch (item_type)
        {
            case Crafting_type.Crafting_General:
                if(Crafting_General_list.Count > 0)  // 이미 리스트에 있는지 확인
                {
                    for (int i = 0; i < Crafting_General_list.Count; i++)
                    {
                        if (Crafting_General_list[i].item_DB_ID == item_DB_ID && Crafting_General_list[i].item_DB_type == item_DB_type)
                        {                            
                            break;
                        }
                        else
                        {
                            if (i == Crafting_General_list.Count - 1)
                            {
                                Crafting_General_list.Add(item);
                            }
                        }
                    }
                }
                else  // 리스트의 Count가 0개면 바로 추가 
                {
                    Crafting_General_list.Add(item);
                }            
                break;
            case Crafting_type.Crafting_Tool:
                if(Crafting_Tool_list.Count > 0)  // 이미 리스트에 있는지 확인
                {
                    for (int i = 0; i < Crafting_Tool_list.Count; i++)
                    {
                        if (Crafting_Tool_list[i].item_DB_ID == item_DB_ID && Crafting_Tool_list[i].item_DB_type == item_DB_type)
                        {
                            break;
                        }
                        else
                        {
                            if (i == Crafting_Tool_list.Count - 1)
                            {
                                Crafting_Tool_list.Add(item);
                            }
                        }
                    }
                }
                else  // 리스트의 Count가 0개면 바로 추가 
                {
                    Crafting_Tool_list.Add(item);
                }
                break;
            case Crafting_type.Crafting_Cook:  // 인벤토리에 조리도구 들어오면 추가, 없어지면 삭제
                if(Crafting_Cook_list.Count > 0)
                {
                    for (int i = 0; i < Crafting_Cook_list.Count; i++)
                    {
                        if (Crafting_Cook_list[i].item_DB_ID == item_DB_ID && Crafting_Cook_list[i].item_DB_type == item_DB_type)
                        {
                            break;
                        }
                        else
                        {
                            if (i == Crafting_Cook_list.Count - 1)
                            {
                                Crafting_Cook_list.Add(item);
                            }
                        }
                    }
                }
                else  // 리스트의 Count가 0개면 바로 추가 
                {
                    Crafting_Cook_list.Add(item);
                }
                break;
            case Crafting_type.Crafting_Medical:
                if(Crafting_Medical_list.Count > 0)  // 이미 리스트에 있는지 확인
                {
                    for (int i = 0; i < Crafting_Medical_list.Count; i++)
                    {
                        if (Crafting_Medical_list[i].item_DB_ID == item_DB_ID && Crafting_Medical_list[i].item_DB_type == item_DB_type)
                        {
                            break;
                        }
                        else
                        {
                            if (i == Crafting_Medical_list.Count - 1)
                            {
                                Crafting_Medical_list.Add(item);
                            }
                        }
                    }
                }
                else  // 리스트의 Count가 0개면 바로 추가 
                {
                    Crafting_Medical_list.Add(item);
                }
                break;
            case Crafting_type.Crafting_Furniture:
                if(Crafting_Furniture_list.Count > 0)  // 이미 리스트에 있는지 확인
                {
                    for (int i = 0; i < Crafting_Furniture_list.Count; i++)
                    {
                        if (Crafting_Furniture_list[i].item_DB_ID == item_DB_ID && Crafting_Furniture_list[i].item_DB_type == item_DB_type)
                        {
                            break;
                        }
                        else
                        {
                            if (i == Crafting_Furniture_list.Count - 1)
                            {
                                Crafting_Furniture_list.Add(item);
                            }
                        }
                    }
                }
                else  // 리스트의 Count가 0개면 바로 추가 
                {
                    Crafting_Furniture_list.Add(item);
                }
                break;
        }
    }

    public int Get_Crafting_list_index(Crafting_type item_type)
    {
        switch (item_type)
        {
            case Crafting_type.Crafting_General:
                return Crafting_General_list.Count;
            case Crafting_type.Crafting_Tool:
                return Crafting_Tool_list.Count;
            case Crafting_type.Crafting_Cook:
                return Crafting_Cook_list.Count;
            case Crafting_type.Crafting_Medical:
                return Crafting_Medical_list.Count;
            case Crafting_type.Crafting_Furniture:
                return Crafting_Furniture_list.Count;
            default: return 0;
        }
    }
}
