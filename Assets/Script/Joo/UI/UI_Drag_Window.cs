using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UI_Drag_Window : MonoBehaviour, IDragHandler, IEndDragHandler
{
    RectTransform recrTr;

    public void OnDrag(PointerEventData eventData)
    {
        recrTr = GetComponent<RectTransform>();
        recrTr.anchoredPosition += (eventData.delta * 0.41f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        recrTr.localPosition = this.transform.localPosition;
    }




}
