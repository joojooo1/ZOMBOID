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

    public void OnEndDrag(PointerEventData eventData)  // �巡���ϸ� crafting_number �� 1�� �پ��.
    {
        //Ư�� ��ġ�� ������ �������� �ƴϸ� �ٽ� ���ڸ��� ���ƿ����� �����ؾ���
        //if (�κ��丮�� �巡���ϴ� ��� )
        //{
        //    item_crafting_number--;
        //    item_crafting_number_text.text = item_crafting_number.ToString();
        //    if (item_crafting_number > 0)
        //    {
        //        background.SetActive(true);
        //        recrTr.localPosition = Vector3.zero;
        //    }
        //    else
        //    {
        //        UI_Craft_window.ui_Craft_Window.Destroy_item();
        //    }
        //}
        //else
        //{
        //    background.SetActive(true);
        //    recrTr.localPosition = Vector3.zero;
        //}


        /* �� ���� ���� �� �ϴ��� ������ �� �ڵ�� ��ü */
        item_crafting_number--;
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
}
