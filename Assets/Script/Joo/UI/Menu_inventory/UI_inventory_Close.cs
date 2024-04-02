using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory_Close : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_inventory.Inventory_UI_main.UI_window.SetActive(false);
        UI_inventory.Inventory_UI_main.Image.sprite = UI_inventory.Inventory_UI_main.UI_window_Image[0];
    }



}
