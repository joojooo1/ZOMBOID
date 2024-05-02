using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Starting : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text text;
    [SerializeField] GameObject text_Object;
    [SerializeField] GameObject start_button;

    float Timer = 20f;
    int i = 0;
    Animator anim;

    public bool Map_Setting_complete = false;
    bool Canvas_finish = false;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    Vector3 pos = new Vector3(0, -192, 0);
    void Update()
    {
        if (i < 4)
            Timer += Time.deltaTime;

        if(Timer > 9f)
        {
            if(i == 0)
            {
                Player_Characteristic.current.Start_Setting();
            }

            if (i < 3)
            {
                text.text = Set_Start_Text(i);
                anim.SetTrigger("next");
                i++;
                Timer = 0;
            }
            else if(Timer > 10f)
            {
                i++;
                if (Map_Setting_complete && !start_button.activeSelf)
                {
                    start_button.SetActive(true);
                    text.text = Set_Start_Text(3);

                    text_Object.transform.localPosition += pos;
                    anim.SetBool("start", true);
                    Timer = 0;
                }
            }

        }

    }

    public string Set_Start_Text(int num)
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            switch (num)
            {
                case 0:
                    return "최후의 시간이다.";
                case 1:
                    return "살아남는다는 희망도 없었다.";
                case 2:
                    return "이것은 당신의 죽음에 관한 이야기이다.";
                case 3:
                    return "눌러서 시작하기";
                default: return "";
            }
        }
        else
        {
            switch (num)
            {
                case 0:
                    return "THESE ARE THE END-TIMES";
                case 1:
                    return "THERE WAS NO HOPE OF SURVIVAL";
                case 2:
                    return "THIS IS HOW YOU DIED";
                case 3:
                    return "Click to Start";
                default: return "";
            }
        }
    }
}
