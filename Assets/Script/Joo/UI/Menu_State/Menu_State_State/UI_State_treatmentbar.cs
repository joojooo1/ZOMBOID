using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_treatmentbar : MonoBehaviour, IPointerExitHandler
{
    public GameObject Treatment_bar;

    public void OnPointerExit(PointerEventData eventData)
    {
        Treatment_bar.SetActive(false);
        UI_main.ui_main.ui_player_state.Choice_Damage(body_point.None, -1);
    }
}
