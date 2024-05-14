using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public GameObject Option_Canvas;

    double Temperature = 36.0f;
    double Current_Temperature = 0f;

    float Timer = 0f;  // 8�ʸ��� ���ӽð� 10�� ���
    int Month = 7;
    int Day = 9;
    int Hour = 11;
    int Minute = 0;
    int Elapsed_time = 0;  // �����ϼ�
    [SerializeField] UnityEngine.UI.Text Elapsed_time_text;
    [SerializeField] UnityEngine.UI.Text Weight_text;
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

        Elapsed_time_text.text = Elapsed_time + "��";

        for(int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
        {
            int[] Kill_count = new int[2];
            Kill_count[0] = i;
            Kill_count[1] = 0;
            Weapon_ID_Count.Add(Kill_count);
        }

    }

    private void Update()
    {
        if (Option_Canvas.activeSelf)
            UI_main.ui_main.Playing = false;
        else
            UI_main.ui_main.Playing = true;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Option_Canvas.activeSelf)
                Option_Canvas.SetActive(true);
        }

        if (UI_main.ui_main.Playing)
        {
            Weight_text.text = Player_main.player_main.Get_Weight().ToString();

            Timer += Time.deltaTime;

            if (Timer > 8)
            {
                if (Minute >= 50)
                {
                    if (Hour < 23)
                    {
                        Hour += 1;
                    }
                    else
                    {
                        Hour = 0;
                        Elapsed_time++;
                        Elapsed_time_text.text = Elapsed_time + " ��";

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

                        Player_main.player_main.playerState.Set_Apparent_Temperature(Temp / 10);
                        Set_Windchill();

                        if (Elapsed_time == 7)  // �� 40���� 7������ ��, ���� ����
                        {
                            Is_Water = false;
                            Is_Electricity = false;
                        }
                    }

                    Minute = 0;
                }
                else
                    Minute += 10;

                if (UI_main.ui_main.Clock == enabled)
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

    }

    public float Clothing_Wind_resistance = 1f;
    void Set_Windchill()
    {
        System.Random rand = new System.Random();
        float Temp = rand.Next(0, 10);

        Player_main.player_main.playerMoodles.Moodle_Windchill.Set_Moodles_state(Temp * Clothing_Wind_resistance);
        
    }

    public float Get_Current_Temperature() { return (float)Current_Temperature; }

    // Info) óġ�� ���� ��, �� ��� ����, �����ϼ�
    int Zombies_killed_count = 0;
    [SerializeField] UnityEngine.UI.Text Zombies_killed_count_text;
    List<int[]> Weapon_ID_Count = new List<int[]>();   // ���� DB ������ ���� // �� ������ �迭�� [0]: ����index, [1]: óġ�� ���� ��
    [SerializeField] UnityEngine.UI.Text primary_Weapon_text;

    public void Set_Info_from_Server()
    {
        Zombies_killed_count++;
        Zombies_killed_count_text.text = Zombies_killed_count.ToString();

        int current_index = Player_main.player_main.Current_equipping_Weapon;
        Weapon_ID_Count[current_index][1]++;

        int target_index = -1;
        int current_kill_count = 0;
        for(int i = 0; i < Weapon_ID_Count.Count; i++)
        {
            if (Weapon_ID_Count[i][1] > current_kill_count)
            {
                current_kill_count = Weapon_ID_Count[i][1];
                target_index = i;
            }
        }
        primary_Weapon_text.text = Item_DataBase.item_database.weapons_Ins[target_index].WeaponName;
    }

    public int Get_Elapsed_time()
    {
        return Elapsed_time;
    }

    public int Get_killed_count()
    {
        return Zombies_killed_count;
    }
}