using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_Pin : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (UI_inventory_window.inven_detail_Window.Pin_fixed)
        {
            UI_inventory_window.inven_detail_Window.Pin_fixed = false;
        }
        else
        {
            UI_inventory_window.inven_detail_Window.Pin_fixed = true;
        }
        
    }
}
