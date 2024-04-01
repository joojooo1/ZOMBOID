using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_State : MonoBehaviour
{
    public static UI_State State_icon_main;
    public Sprite[] player_damage_SpriteArray;

    [SerializeField] GameObject icon_prefab;
    [SerializeField] GameObject[] icon_position;

    List<UI_detailwindow> Damagelist = new List<UI_detailwindow>();

    private void OnEnable()
    {
        State_icon_main = this;
    }


    public void icon_Ins(Damage_Pattern damagetype, body_point position)
    {
        GameObject tempObj = null;

        for(int i = 0; i < Damagelist.Count; i++)
        {
            if (Damagelist != null)
            {
                if (Damagelist[i].GetPosition() == position)
                {
                    tempObj = Instantiate(icon_prefab, icon_position[(int)position].transform);
                    UI_detailwindow temp = tempObj.GetComponent<UI_detailwindow>();
                    temp.SetObject(player_damage_SpriteArray[(int)damagetype], position);
                    Damagelist.Add(temp);
                }
            }
            else
            {
                tempObj = Instantiate(icon_prefab, icon_position[(int)position].transform);
                UI_detailwindow temp = tempObj.GetComponent<UI_detailwindow>();
                temp.SetObject(player_damage_SpriteArray[(int)damagetype], position);
                Damagelist.Add(temp);
            }
        }
        

    }
}

