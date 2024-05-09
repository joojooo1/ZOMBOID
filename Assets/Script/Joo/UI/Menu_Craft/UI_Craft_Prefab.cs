using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Craft_Prefab : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEngine.UI.Image item_Image;
    public UnityEngine.UI.Text item_Value;
    public Transform item_Transform;
    public bool Choice;
    public bool Is_Ingredients;
    public int item_index;
    public int Ingredients_index;
    public Crafting_item item_Info;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Is_Ingredients)
        {
            Choice = true;
            UI_Craft_window.ui_Craft_Window.Choice_item(item_index);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Is_Ingredients)
        {
            if(item_Info != null)
            {
                UI_Craft_window.ui_Craft_Window.Open_name_window(item_Transform, item_Info.Get_Ingredients_name(Ingredients_index));
            }
            
        }
        else
        {
            UI_Craft_window.ui_Craft_Window.Open_name_window(item_Transform, item_Info.Get_name());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Craft_window.ui_Craft_Window.Close_name_window();
    }

    public void Set_item(Crafting_item item, int index)
    {
        Choice = false;
        Is_Ingredients = false;
        item_Image.sprite = item.item_Image;
        item_index = index;
        item_Info = item;
    }

    public void Set_Ingredients(Crafting_item item_info, int index)
    {
        Choice = false;
        Is_Ingredients = true;
        Ingredients_index = index;
        item_Image.sprite = item_info.Get_Ingredients_Image(index);
        item_Info = item_info;
        item_Value.text = item_info.Get_Ingredients_value(index).ToString();

        //0509 JY
        //Debug.Log("I Hope." + item_info.Request_Type(index) + item_info.Requesting_Value(index) + item_info.Request_ID(index));
        Inventory_Player_Shown.InvPS.Crafting_Resources((short)item_Info.Request_Type(index), (short)item_Info.Request_ID(index), (short)item_Info.Requesting_Value(index));
        //0509 JY
    }

    public void Set_Ingredients_Box(int index)
    {
        Choice = false;
        Is_Ingredients = true;
        Ingredients_index = index;
    }

}
