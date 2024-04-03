using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_State : MonoBehaviour, IPointerClickHandler
{
    public GameObject UI_window;
    public Sprite[] UI_window_Image;
    public UnityEngine.UI.Image Image;

    public static UI_State State_icon_main;
    public Sprite[] player_damage_SpriteArray;

    [SerializeField] GameObject icon_prefab;
    [SerializeField] GameObject[] icon_position;

    List<UI_detailwindow> Damagelist = new List<UI_detailwindow>();

    private void Start()
    {
        State_icon_main = this;
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



    public void icon_Ins(Damage_Pattern damagetype, body_point position)
    {
        GameObject tempObj = null;

        if (Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount() < 3)
        {
            tempObj = Instantiate(icon_prefab, icon_position[(int)position].transform);
            UI_detailwindow temp = tempObj.GetComponent<UI_detailwindow>();
            temp.SetImage(player_damage_SpriteArray[(int)damagetype], position);
            Player_main.player_main.playerState.Player_body_point[(int)position].Set_DamageCount(true);
            temp.position_Damage_Num = Player_main.player_main.playerState.Player_body_point[(int)position].Get_DamageCount();
            Damagelist.Add(temp);
        }

    }

    public void icon_Destroy(body_point position, int Damage_Num)
    {
        foreach(UI_detailwindow temp in Damagelist)
        {
            if(temp.position_Damage_Num == Damage_Num && temp.body_position == position)
            {
                Damagelist.Remove(temp);
                Destroy(temp.gameObject);
            }
        }
    }
}

