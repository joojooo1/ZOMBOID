using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_CloseButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory_Player_Shown.InvPS.SetAnim(false);
        UI_inventory.Inventory_UI_main.Image.sprite = UI_inventory.Inventory_UI_main.UI_window_Image[0];
    }




}
