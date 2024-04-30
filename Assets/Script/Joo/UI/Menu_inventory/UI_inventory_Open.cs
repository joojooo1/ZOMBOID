using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_Open : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        UI_inventory_window.inven_detail_Window.SetAnim(true);
        UI_inventory_window2.inven_detail_Window2.SetAnim(true);
        UI_inventory_Equip.inven_Equip_Window.SetAnim(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (UI_inventory_window.inven_detail_Window.Pin_fixed)
        {
            UI_inventory_window.inven_detail_Window.SetAnim(true);
            UI_inventory_Equip.inven_Equip_Window.SetAnim(true);
        }
        else
        {
            UI_inventory_window.inven_detail_Window.SetAnim(false);
            UI_inventory_Equip.inven_Equip_Window.SetAnim(false);
        }

        if (UI_inventory_window2.inven_detail_Window2.Pin_fixed)
        {
            UI_inventory_window2.inven_detail_Window2.SetAnim(true);
        }
        else
        {
            UI_inventory_window2.inven_detail_Window2.SetAnim(false);
            UI_inventory_Equip.inven_Equip_Window.SetAnim(false);
        }
       
    }



}
