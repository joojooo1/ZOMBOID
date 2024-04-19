using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Starting : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text text;
    [SerializeField] GameObject start_button;

    float Timer = 20f;
    int i = 0;
    Animator anim;

    public bool Map_Setting_complete = false;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Map_Setting_complete)
        {
            UI_main.ui_main.Playing = true;
        }

        if (i < 4)
            Timer += Time.deltaTime;

        if(Timer > 13f)
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
            else
            {
                i++;
                if (Map_Setting_complete && !start_button.activeSelf)
                {
                    start_button.SetActive(true);
                    text.text = Set_Start_Text(3);
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
                    return "������ �ð��̴�.";
                case 1:
                    return "��Ƴ��´ٴ� ����� ������.";
                case 2:
                    return "�̰��� ����� ������ ���� �̾߱��̴�.";
                case 3:
                    return "������ �����ϱ�";
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
