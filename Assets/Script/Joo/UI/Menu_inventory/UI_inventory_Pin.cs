using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_Pin : MonoBehaviour, IPointerClickHandler
{
    public Sprite[] UI_window_Image;
    public UnityEngine.UI.Image Image;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UI_inventory_window.inven_detail_Window.Pin_fixed)
        {
            Image.sprite = UI_window_Image[0];
            UI_inventory_window.inven_detail_Window.Pin_fixed = false;
            UI_inventory_Equip.inven_Equip_Window.Pin_fixed = false;
        }
        else
        {
            Image.sprite = UI_window_Image[1];
            UI_inventory_window.inven_detail_Window.Pin_fixed = true;
            UI_inventory_Equip.inven_Equip_Window.Pin_fixed = true;
        }
        
    }
}
