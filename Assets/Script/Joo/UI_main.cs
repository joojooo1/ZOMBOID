using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_main : MonoBehaviour
{
    public static UI_main ui_main;

    bool player_Setting_Language_to_Korean = true;  // Korean 으로 시작
    void Start()
    {
        ui_main = this;;
    }

    public bool Get_Setting_Language_Type()
    {
        return player_Setting_Language_to_Korean;
    }
    void Update()
    {
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
