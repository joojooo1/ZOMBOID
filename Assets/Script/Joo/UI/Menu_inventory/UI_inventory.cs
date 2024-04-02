using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_inventory : MonoBehaviour, IPointerClickHandler
{
    public static UI_inventory Inventory_UI_main;

    public GameObject UI_window;
    public Sprite[] UI_window_Image;
    public UnityEngine.UI.Image Image;

    void Start()
    {
        Inventory_UI_main = this;
        if (UI_window.activeSelf) { Image.sprite = UI_window_Image[1]; }
        else { Image.sprite = UI_window_Image[0]; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (UI_window.activeSelf)
        {
            UI_window.SetActive(false);
            Image.sprite = UI_window_Image[0];
        }
        else
        {
            UI_window.SetActive(true);
            Image.sprite = UI_window_Image[1];
        }
    }
}
