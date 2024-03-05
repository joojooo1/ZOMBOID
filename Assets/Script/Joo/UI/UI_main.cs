using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class UI_main : MonoBehaviour
{
    public static UI_main ui_main;
    public UI_Player_State ui_player_state = new UI_Player_State();

    public bool player_Setting_Language_to_Korean = true;  // Korean 으로 시작
    [SerializeField]
    GameObject[] player_gender = new GameObject[2];

    void Awake()
    {
        ui_main = this;;
        GameObject myInstance = Instantiate(player_gender[0],transform);
    }

    public bool Get_Setting_Language_Type()
    {
        return player_Setting_Language_to_Korean;
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
