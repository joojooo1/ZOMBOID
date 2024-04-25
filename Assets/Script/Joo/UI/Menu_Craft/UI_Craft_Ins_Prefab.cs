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
        recrTr.anchoredPosition += (eventData.delta * 0.4f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        background.SetActive(true);
        recrTr.localPosition = Vector3.zero;
    }
}
