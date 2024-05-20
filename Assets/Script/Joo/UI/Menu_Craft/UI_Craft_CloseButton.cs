using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Craft_CloseButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.SoundManager.System_Open();
        UI_Craft.UI_Craft_main.Craft_window.SetActive(false);
        UI_Craft.UI_Craft_main.Craft_Button_current.sprite = UI_Craft.UI_Craft_main.Craft_Button_Image[0];
    }
}