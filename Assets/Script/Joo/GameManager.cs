using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    double Temperature = 36.0f;
    double Current_Temperature = 0f;

    float Timer = 0f;  // 8�ʸ��� ���ӽð� 10�� ���
    int Month = 7;
    int Day = 9;
    int Hour = 11;
    int Minute = 0;
    int Elapsed_time = 0;

    public bool Is_Water = true;
    public bool Is_Electricity = true;

    private void Start()
    {
        gameManager = this;

        Current_Temperature = Temperature;
        Player_main.player_main.playerState.Set_Apparent_Temperature((float)Current_Temperature);
        if (UI_main.ui_main.Clock == enabled)
        {
            UI_main.ui_main.Set_Clock(Hour.ToString(), Minute.ToString(), Month, Day, Current_Temperature);
        }

    }

    private void Update()
    {
        Timer += Time.deltaTime;        

        if(Timer > 8)
        {
            if (Minute >= 50)
            {
                if (Hour < 23)
                    Hour += 1;          
                else
                {
                    Hour = 0;
                    Elapsed_time++;

                    if (Day < 31)
                        Day += 1;
                    else
                    {
                        Month += 1;
                        Day = 1;
                    }

                    System.Random rand = new System.Random();
                    float Temp = rand.Next(-50, 50);
                    Current_Temperature = Temperature + (Temp / 10);

                    Set_Windchill();

                    if(Elapsed_time == 7)  // �� 40���� 7������ ��, ���� ����
                    {
                        Is_Water = false;
                        Is_Electricity = false;
                    }
                }

                Minute = 0;
            }
            else
                Minute += 10;

            if(UI_main.ui_main.Clock == enabled)
            {
                UI_main.ui_main.Set_Clock(Hour.ToString(), Minute.ToString(), Month, Day, Current_Temperature);
            }

            Timer = 0;
        }

        if (Hour == 23)  // ���� 11�ÿ� Į�θ� üũ�ؼ� ü�� ����
        {
            if (Player_main.player_main.Get_Calories() < 0)
            {
                Player_main.player_main.Set_Weight(2);
            }
            else if (Player_main.player_main.Get_Calories() > 1600)
            {
                Player_main.player_main.Set_Weight(-1);
            }
        }

    }


    void Set_Windchill()
    {
        System.Random rand = new System.Random();
        float Temp = rand.Next(0, 10);

        Player_main.player_main.playerMoodles.Moodle_Windchill.Set_Moodles_state(Temp);
        Player_main.player_main.playerState.Set_Apparent_Temperature(Player_main.player_main.playerState.Get_Apparent_Temperature());
    }

    public float Get_Current_Temperature() { return (float)Current_Temperature; }


}




/*
 ����
 ����
 ����
 ��������
 ����
 ȭ��
 ���հ���
 �Ϲݻ�ó
 
1. ����, ��������, �Ϲݻ�ó
2. ����, ���հ���
3. ����, ����, ȭ��
 
 
 */