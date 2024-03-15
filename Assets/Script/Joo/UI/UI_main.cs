using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;

public class UI_main : MonoBehaviour
{
    public static UI_main ui_main;
    public UI_Player_State ui_player_state = new UI_Player_State();

    public bool player_Setting_Language_to_Korean = true;  // Korean 으로 시작
    [SerializeField]
    GameObject[] player_gender = new GameObject[2];
    public bool Is_Female = false;

    public GameObject Clock;
    [SerializeField]
    UnityEngine.UI.Text Time_text;
    [SerializeField]
    UnityEngine.UI.Text Temperature_text;
    [SerializeField]
    UnityEngine.UI.Text Day_text;

    void Awake()
    {
        ui_main = this;;
        GameObject myInstance = Instantiate(player_gender[0],transform);

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
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (player_Setting_Language_to_Korean)  // Korean -> English
            {
                player_Setting_Language_to_Korean = false;
            }
            else                                     // English -> Korean
            {
                player_Setting_Language_to_Korean = true;
            }
        }


    }
}
