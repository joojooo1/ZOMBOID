using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Craft_Prefab : MonoBehaviour, IPointerClickHandler
{
    Sprite item_Image;

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void Set_item(Sprite image)
    {
        item_Image = image;
    }

}
