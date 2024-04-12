using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using static Player_Characteristic;

public class UI_Title_Characteristic_prefab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] UnityEngine.UI.Image image;
    public Characteristic Prefab = null;


    public void SetCharacteristic(Characteristic _Prefab)
    {
        Prefab = _Prefab;
        image.sprite = _Prefab.Sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(Prefab.name_kr, Prefab.Explanation_for_Characteristic_kr, Prefab.Points);
        }
        else
        {
            UI_Title_Characteristic_text.Characteristic_text.Open_text(Prefab.name, Prefab.Explanation_for_Characteristic, Prefab.Points);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UI_Title_Characteristic_text.Characteristic_text.Close_text();
    }

    float clickTime = 0;

    void OnMouseDoubleClick()
    {
        if(Prefab.Choice == false)  // characteristics_list -> characteristics_Player
        {
            Prefab.Choice = true;
            for(int i = 0; i < Player_Characteristic.instance.characteristics_list.Count; i++)
            {
                if (Player_Characteristic.instance.characteristics_list[i].Prefab == Prefab)
                {
                    GameObject tempObj = null;
                    Player_Characteristic.instance.Set_Characteristic(Prefab.Characteristic_number, Prefab.Choice, tempObj);
                    Player_Characteristic.instance.Remove_Selected_list(Prefab.Characteristic_number, false);
                }
            }
            
        }
        else  // characteristics_Player -> characteristics_list
        {
            Prefab.Choice = false;



        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((Time.time - clickTime) < 0.3f)
        {
            OnMouseDoubleClick();
            clickTime = -1;
        }
        else
        {
            clickTime = Time.time;
        }
    }

}
