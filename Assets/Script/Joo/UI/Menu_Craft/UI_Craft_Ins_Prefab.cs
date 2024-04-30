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

    RectTransform recrTr;

    public void Set_Info(Crafting_item item)
    {
        recrTr = GetComponent<RectTransform>();
        item_Image.sprite = item.item_Image;
        item_Info = item;
    }

    public void OnDrag(PointerEventData eventData)
    {
        background.SetActive(false);
        recrTr.anchoredPosition += (eventData.delta * 0.41f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 특정 위치에 놓으면 옯겨지고 아니면 다시 제자리로 돌아오도록 구현해야함
        background.SetActive(true);
        recrTr.localPosition = Vector3.zero;
    }
}
