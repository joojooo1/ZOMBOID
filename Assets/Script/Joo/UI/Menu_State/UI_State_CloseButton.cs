using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_CloseButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        UI_main.ui_main.ui_player_state.UI_window.SetActive(false);
        UI_main.ui_main.ui_player_state.Image.sprite = UI_main.ui_main.ui_player_state.UI_window_Image[0];
    }
}
