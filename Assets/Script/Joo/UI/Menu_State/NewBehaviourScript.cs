using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    RectTransform rectTransform;
    Vector3 mouse = new Vector3(0, 0, 0);
    Vector3 none = new Vector3(0, 0, 0);

    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (mouse == none)
        {
            mouse = Input.mousePosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (mouse != none && mouse != Input.mousePosition)
        {
            Vector2 dis = mouse - Input.mousePosition;
            rectTransform.anchoredPosition -= dis;
            rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, 100, 700), Mathf.Clamp(rectTransform.anchoredPosition.y, 4, 444));
            mouse = Input.mousePosition;
        }


    }
    public void OnEndDrag(PointerEventData eventData)
    {
        mouse = none;
    }

}
