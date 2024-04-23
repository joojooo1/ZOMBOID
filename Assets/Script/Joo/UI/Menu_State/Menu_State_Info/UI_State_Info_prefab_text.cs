using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State_Info_prefab_text : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Characteristic;
    public UI_Title_Characteristic_prefab Prefab;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            UI_State_Info.Instance.Open_text(Prefab.Prefab.name_kr, Characteristic.transform);
        }
        else
        {
            UI_State_Info.Instance.Open_text(Prefab.Prefab.name, Characteristic.transform);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_State_Info.Instance.Close_text();
    }



}
