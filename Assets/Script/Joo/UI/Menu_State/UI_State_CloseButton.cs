using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_CloseButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_State.State_icon_main.UI_window.SetActive(false);
        UI_State.State_icon_main.Image.sprite = UI_State.State_icon_main.UI_window_Image[0];
    }
}
