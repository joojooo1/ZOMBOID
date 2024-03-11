using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public bool Is_AM = false;
    public bool Is_PM = false;

    public float Temperature = 36.0f;
    float AM_Temperature = 0f;
    float PM_Temperature = 0f;

    private void Start()
    {
        gameManager = this;

        Player_main.player_main.playerState.Set_Apparent_Temperature(Temperature);
    }

    float Timer = 1800f;
    float Windchill_TImer = 0f;
    private void Update()
    {
        Timer += Time.deltaTime;

        if (Is_PM == true && Timer > 1650)  // ���� 11�ÿ� Į�θ� üũ�ؼ� ü�� ����
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

        if (Timer > 1800f)  // 30�и��� �ٲ�
        {
            System.Random rand = new System.Random();
            float Temp = rand.Next(0, 10);

            if (Is_AM) // ���� -> ����
            {
                Is_AM = false;
                Is_PM = true;
                PM_Temperature = Temp;
                Set_Temperature(-(AM_Temperature + PM_Temperature));
            }
            else  // ���� -> ����
            {
                Is_AM = true;
                Is_PM = false;
                AM_Temperature = Temp;
                Set_Temperature(AM_Temperature + PM_Temperature);
            }
            Timer = 0f;
        }

        Windchill_TImer += Time.deltaTime;
        if(Windchill_TImer > 3600f)  // 60��(�Ϸ�)���� �ٲ�
        {
            System.Random rand = new System.Random();
            float Temp = rand.Next(0, 10);
            Player_main.player_main.playerMoodles.Moodle_Windchill.Set_Moodles_state(Temp);
            Windchill_TImer = 0;
        }

    }


    public void Set_Temperature(float value)
    {
        Temperature += value;
        Player_main.player_main.playerState.Set_Apparent_Temperature(value);
    }

    public float Get_Temperature() { return Temperature; }
}
