using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Craft : MonoBehaviour, IPointerClickHandler
{
    public static UI_Craft UI_Craft_main;

    public GameObject Craft_window;
    public Sprite[] Craft_Button_Image;
    public UnityEngine.UI.Image Craft_Button_current;

    private void Start()
    {
        UI_Craft_main = this;
        if (Craft_window.activeSelf) { Craft_Button_current.sprite = Craft_Button_Image[1]; }
        else { Craft_Button_current.sprite = Craft_Button_Image[0]; }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Craft_window.activeSelf)
        {
            Craft_window.SetActive(false);
            Craft_Button_current.sprite = Craft_Button_Image[0];
        }
        else
        {
            Craft_window.SetActive(true);
            Craft_Button_current.sprite = Craft_Button_Image[1];
        }
    }
}
