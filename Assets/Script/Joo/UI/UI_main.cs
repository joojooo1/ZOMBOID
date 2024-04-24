using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;
//using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class UI_main : MonoBehaviour
{
    public static UI_main ui_main;
    public UI_State ui_player_state;

    public bool Playing = false;

    public bool player_Setting_Language_to_Korean = true;  // Korean 으로 시작

    public bool Is_Female = true;
    public Sprite[] player_gender;
    public GameObject UI_Damage;
    public UnityEngine.UI.Image UI_DamageImage;
    public UnityEngine.UI.Image UI_DamageImage_base;

    public GameObject Clock;
    [SerializeField]
    UnityEngine.UI.Text Time_text;
    [SerializeField]
    UnityEngine.UI.Text Temperature_text;
    [SerializeField]
    UnityEngine.UI.Text Day_text;

    void Awake()
    {
        ui_main = this;
    }

    public void Set_Playing() 
    {
        if (Playing)
        {
            Playing = false;
        }
        else
        {
            Playing = true;
        }
    }

    public void Set_Gender(int value)
    {
        if(value == 0)
        {
            Is_Female = false;
        }
        else
        {
            Is_Female = true;
        }
    }

    private void OnEnable()
    {
        if (Is_Female)
        {
            UI_DamageImage.sprite = player_gender[2];
            UI_DamageImage_base.sprite = player_gender[0];
        }
        else
        {
            UI_DamageImage.sprite = player_gender[3];
            UI_DamageImage_base.sprite = player_gender[1];
        }
        UI_Damage.SetActive(false);
    }

    public bool Get_Setting_Language_Type()
    {
        return player_Setting_Language_to_Korean;
    }

    public void Set_Clock(string Hour, string Minute, int Month, int Day, double current_Temperature)
    {
        if (Hour == "0") Hour = "00";
        if (Minute == "0") Minute = "00";

        Time_text.text = Hour + " : " + Minute;
        
        if(Month < 10 && Day < 10)
            Day_text.text = "0" + Month + " / " + "0" + Day;
        else if(Month < 10 && Day >= 10)
            Day_text.text = "0" + Month + " / " + Day;
        else if(Month >= 10 && Day < 10)
            Day_text.text = Month + " / " + "0" + Day;
        else
            Day_text.text = Month + " / " + Day;

        Temperature_text.text = current_Temperature.ToString("F1") + " °C";
    }

    void Update()
    {
        
        Player_main.player_main.playerMoodles.Set_Player_Language(player_Setting_Language_to_Korean);

    }

    public void Set_UIDamage()
    {
       
    }
}
