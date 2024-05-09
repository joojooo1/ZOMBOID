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

    public void OnEndDrag(PointerEventData eventData)  // 드래그하면 crafting_number 가 1씩 줄어듦.
    {
        //특정 위치에 놓으면 옯겨지고 아니면 다시 제자리로 돌아오도록 구현해야함
        //if (인벤토리로 드래그하는 경우 )
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


        /* 위 사항 구현 후 하단의 내용을 위 코드로 대체 */
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
