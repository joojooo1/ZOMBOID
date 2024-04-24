using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public List<Crafting_Ingredients> Ingredients_list = new List<Crafting_Ingredients>();

    public Crafting_item(Type item_DB_type, int item_DB_ID, Crafting_type item_type, Sprite item_Image, string name, string name_kr)
    {
        this.item_DB_type = item_DB_type;
        this.item_DB_ID = item_DB_ID;
        this.item_type = item_type;
        this.item_Image = item_Image;
        this.name = name;
        this.name_kr = name_kr;
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
    public void Add_Ingredients(Sprite image, string name, string name_kr)
    {
        Crafting_Ingredients Ingredients = new Crafting_Ingredients(image, name, name_kr);
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
}

public class Crafting_Ingredients
{
    public Sprite Ingredients_Image;
    public string Ingredients_name;
    public string Ingredients_name_kr;
    public int value;  // ÇÊ¿äÇÑ °¹¼ö

    public Crafting_Ingredients(Sprite ingredients_Image, string ingredients_name, string ingredients_name_kr)
    {
        Ingredients_Image = ingredients_Image;
        Ingredients_name = ingredients_name;
        Ingredients_name_kr = ingredients_name_kr;
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
            case Crafting_type.Crafting_Cook:
                Crafting_Cook_list.Add(item);
                break;
            case Crafting_type.Crafting_Medical:
                Crafting_Medical_list.Add(item);
                break;
            case Crafting_type.Crafting_Furniture:
                Crafting_Furniture_list.Add(item);
                break;
        }

        //UI_Craft_window.ui_Craft_Window.list_ins();
    }
}
