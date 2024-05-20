using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UI_Craft_Ins_Prefab : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public UnityEngine.UI.Image item_Image;
    public GameObject background;
    public Crafting_item item_Info;
    public UnityEngine.UI.Text item_crafting_number_text;
    int item_crafting_number;

    RectTransform recrTr;

    public void Set_Info(Crafting_item item)
    {
        recrTr = GetComponent<RectTransform>();
        item_Info = item;
        item_Image.sprite = item_Info.item_Image;
        item_crafting_number = item_Info.if_Crafting_number;
        item_crafting_number_text.text = item_crafting_number.ToString();
    }

    public void OnDrag(PointerEventData eventData)  
    {
        background.SetActive(false);
        recrTr.anchoredPosition += (eventData.delta * 0.41f);
    }

    public void OnEndDrag(PointerEventData eventData)  // �巡���ϸ� crafting_number �� Capacity��ŭ�� �پ��.
    {        
        if (true)   //Ư�� ��ġ�� ������ �������� �ƴϸ� �ٽ� ���ڸ��� ���ƿ����� �����ؾ���
        {
            int Depth = 1;
            switch (item_Info.item_DB_type)
            {
                case Type.food:
                    Depth = Item_DataBase.item_database.food_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.Medical:
                    Depth = Item_DataBase.item_database.medical_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.weapon:
                    Depth = Item_DataBase.item_database.weapons_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.Electronics:
                    Depth = Item_DataBase.item_database.electronics_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.Farming:
                    Depth = Item_DataBase.item_database.Farming_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.Container:
                    Depth = Item_DataBase.item_database.Container_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.Normal:
                    Depth = Item_DataBase.item_database.ETC_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.Tool:
                    Depth = Item_DataBase.item_database.Tool_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                case Type.clothing:
                    Depth = Item_DataBase.item_database.clothing_Ins[item_Info.item_DB_ID].Nesting_Depth;
                    break;
                default: break;
            }

            item_crafting_number -= Depth;

            item_crafting_number_text.text = item_crafting_number.ToString();
            if (item_crafting_number > 0)
            {
                background.SetActive(true);
                recrTr.localPosition = Vector3.zero;
            }
            else
            {
                UI_Craft_window.ui_Craft_Window.Destroy_item();
            }
        }
        else
        {
            background.SetActive(true);
            recrTr.localPosition = Vector3.zero;
        }


    }
}
