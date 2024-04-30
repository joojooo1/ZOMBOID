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

    public float F_Calories;  // 칼로리
    public float F_Thirst;  // 갈증

    public float[] F_Satiety;  // 포만감
    public float[] F_Unhappiness;  // 불행
    public float[] F_Boredom;  // 지루함
    public float[] F_Fatigue;  // 피로

    public List<Crafting_Ingredients> Ingredients_list = new List<Crafting_Ingredients>();

    public Crafting_item(Type item_DB_type, int item_DB_ID, Crafting_type item_type, Sprite item_Image, string name, string name_kr)
    {
        this.item_DB_type = item_DB_type;
        this.item_DB_ID = item_DB_ID;
        this.item_type = item_type;
        this.item_Image = item_Image;
        this.name = name;
        this.name_kr = name_kr;

        if(item_DB_type == Type.food)
        {
            if(Item_DataBase.item_database.food_Ins[item_DB_ID].FoodType == Food_Type.Cooking)
            {
                for(int j = 0; j < Ingredients_list.Count; j++)
                {
                    F_Calories += Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Calories;
                    F_Thirst += Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Thirst;

                    for (int i = 0; i < 3; i++)
                    {
                        F_Satiety[i] += Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Satiety[i];
                        F_Unhappiness[i] += Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Unhappiness[i];
                        F_Boredom[i] += Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Boredom[i];
                        F_Fatigue[i] += Item_DataBase.item_database.food_Ins[Ingredients_list[j].Ingredients_DB_ID].F_Fatigue[i];
                    }
                }
            }
            else
            {
                F_Calories = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Calories;
                F_Thirst = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Thirst;

                for (int i = 0; i < 3; i++)
                {
                    F_Satiety[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Satiety[i];
                    F_Unhappiness[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Unhappiness[i];
                    F_Boredom[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Boredom[i];
                    F_Fatigue[i] = Item_DataBase.item_database.food_Ins[item_DB_ID].F_Fatigue[i];
                }
            }
        }
        else
        {
            F_Calories = 0;
            F_Thirst = 0;

            for(int i = 0; i < 3; i++)
            {
                F_Satiety[i] = 0;
                F_Unhappiness[i] = 0;
                F_Boredom[i] = 0;
                F_Fatigue[i] = 0;
            }

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
    public void Add_Ingredients(Type _DB_type, int _DB_ID, Sprite image, string name, string name_kr, int value)
    {
        Crafting_Ingredients Ingredients = new Crafting_Ingredients(_DB_type, _DB_ID, image, name, name_kr, value);
        Ingredients_list.Add(Ingredients);
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

    public Crafting_Ingredients(Type _DB_type, int _DB_ID, Sprite ingredients_Image, string ingredients_name, string ingredients_name_kr, int value)
    {
        Ingredients_DB_type = _DB_type;
        Ingredients_DB_ID = _DB_ID;
        Ingredients_Image = ingredients_Image;
        Ingredients_name = ingredients_name;
        Ingredients_name_kr = ingredients_name_kr;
        Value = value;
        fulfill = false;
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
        }
    }

    public void Add_Crafting_list(Type item_DB_type, int item_DB_ID, Crafting_type item_type, Sprite item_Image, string name, string name_kr)
    {
        Crafting_item item = new Crafting_item(item_DB_type, item_DB_ID, item_type, item_Image, name, name_kr);
        switch (item_type)
        {
            case Crafting_type.Crafting_General:
                Crafting_General_list.Add(item);
                break;
            case Crafting_type.Crafting_Tool:
                Crafting_Tool_list.Add(item);
                break;
            case Crafting_type.Crafting_Cook:  // 인벤토리에 조리도구 들어오면 추가, 없어지면 삭제
                Crafting_Cook_list.Add(item);
                break;
            case Crafting_type.Crafting_Medical:
                Crafting_Medical_list.Add(item);
                break;
            case Crafting_type.Crafting_Furniture:
                Crafting_Furniture_list.Add(item);
                break;
        }
    }

    public int Get_Crafting_list_index(Crafting_type item_type)
    {
        switch (item_type)
        {
            case Crafting_type.Crafting_General:
                return Crafting_General_list.Count - 1;
            case Crafting_type.Crafting_Tool:
                return Crafting_Tool_list.Count - 1;
            case Crafting_type.Crafting_Cook:
                return Crafting_Cook_list.Count - 1;
            case Crafting_type.Crafting_Medical:
                return Crafting_Medical_list.Count - 1;
            case Crafting_type.Crafting_Furniture:
                return Crafting_Furniture_list.Count - 1;
            default: return 0;
        }
    }
}
