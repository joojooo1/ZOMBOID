using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public enum Characteristic_Value_type
{
    Fitness = 0,
    Strength = 1,
    Fishing = 2,
    Foraging = 3,
    Lightfooted = 4,
    Nimble = 5,
    Sneaking = 6,
    Insensitivity = 7,
    Aiming = 8,
    Reloading = 9
}

public class UI_Title : MonoBehaviour
{
    public static UI_Title ui_title;

    public UnityEngine.UI.Button[] Button_Job;

    public Transform Window_value;
    [SerializeField] GameObject Value_Prefab;
    public List<UI_Title_Characteristic_value_prefab> value_List = new List<UI_Title_Characteristic_value_prefab>();

    [SerializeField] UnityEngine.UI.Text Total_Point_Window;
    int Total_Point;
    [SerializeField] GameObject Nextbutton;

    public Sprite[] job_image;

    void Awake()
    {
        ui_title = this;
    }

    private void OnEnable()
    {
        Total_Point = 8;
        Total_Point_Window.text = Total_Point.ToString();
        Total_Point_Window.color = Color.green;

        for (int i = 0; i < 2; i++)
        {
            GameObject Totalvalue = Instantiate(Value_Prefab, Window_value);
            value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
        }
        value_List[0].Create_Totalvalue("Fitness", "체력", Player_Job.None, Characteristic_Value_type.Fitness);
        value_List[0].Set_Characteristic_T_value(Characteristic_Value_type.Fitness, 5, 0);
        value_List[1].Create_Totalvalue("Strength", "근력", Player_Job.None, Characteristic_Value_type.Strength);
        value_List[1].Set_Characteristic_T_value(Characteristic_Value_type.Strength, 5, 0);
    }

    private void Update()
    {
        for(int i = 0;i<value_List.Count;i++)
        {
            value_List[i].Set_Language();
        }
    }

    public void Set_TotalPoint_text(int point)
    {
        Total_Point += point;

        Total_Point_Window.text = Total_Point.ToString();
        if(Total_Point >= 0)
        {
            Total_Point_Window.color = Color.green;
            Nextbutton.SetActive(true);
        }
        else
        {
            Total_Point_Window.color = Color.red;
            Nextbutton.SetActive(false);
        }
    }

    public void On_Button(int index)
    {
        ColorBlock col_0 = Button_Job[0].colors;
        ColorBlock col_1 = Button_Job[1].colors;
        ColorBlock col_2 = Button_Job[2].colors;

        if (index == 0)
        {
            Button_Job[0].onClick.AddListener(Job_fisher);
            Button_Job[1].onClick.RemoveListener(Job_Burglar);
            Button_Job[2].onClick.RemoveListener(Job_Veteran);

            col_0.normalColor = new Color32(96, 96, 96, 153);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[2].colors = col_2;
        }
        else if(index == 1)
        {
            Button_Job[0].onClick.RemoveListener(Job_fisher);
            Button_Job[1].onClick.AddListener(Job_Burglar);
            Button_Job[2].onClick.RemoveListener(Job_Veteran);

            col_0.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(96, 96, 96, 153);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[2].colors = col_2;
        }
        else if(index == 2)
        {
            Button_Job[0].onClick.RemoveListener(Job_fisher);
            Button_Job[1].onClick.RemoveListener(Job_Burglar);
            Button_Job[2].onClick.AddListener(Job_Veteran);

            col_0.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(96, 96, 96, 153);
            Button_Job[2].colors = col_2;
        }
        else if (index == 3)
        {
            Button_Job[0].onClick.RemoveListener(Job_fisher);
            Button_Job[1].onClick.RemoveListener(Job_Burglar);
            Button_Job[2].onClick.RemoveListener(Job_Veteran);

            col_0.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[2].colors = col_2;

            UI_main.ui_main.ui_player_state.Reset_Job();
            if (Player_Characteristic.current.player_Job == Player_Job.Burglar)
            {
                Set_TotalPoint_text(6);
            }
            else if (Player_Characteristic.current.player_Job == Player_Job.Veteran)
            {
                Set_TotalPoint_text(8);
            }
            else if(Player_Characteristic.current.player_Job == Player_Job.fisher)
            {
                Set_TotalPoint_text(4);
            }

            for (int i = 0; i < value_List.Count;)
            {
                Destroy(value_List[i].gameObject);
                value_List.RemoveAt(i);
            }

            foreach (Transform child in Window_value)
            {
                Destroy(child.gameObject);
            }

            value_List.Clear();
        }
    }

    public void Job_fisher()
    {
        if(Player_Characteristic.current.player_Job != Player_Job.fisher)
        {
            if (Player_Characteristic.current.player_Job == Player_Job.Burglar)
            {
                Set_TotalPoint_text(6);
            }
            else if (Player_Characteristic.current.player_Job == Player_Job.Veteran)
            {
                Set_TotalPoint_text(8);
            }
            Player_Characteristic.current.player_Job = Player_Job.fisher;
            Set_TotalPoint_text(-4);

            for (int i = 0; i < value_List.Count;)
            {
                if (value_List[i].Job_type == Player_Job.Burglar
                    || value_List[i].Job_type == Player_Job.Veteran)
                {
                    Destroy(value_List[i].gameObject);
                    value_List.RemoveAt(i);
                }
                else
                    i++;
            }


            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Fishing)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Fishing", "낚시", Player_Job.fisher, Characteristic_Value_type.Fishing);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Fishing, 3, 125);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }
        }

        UI_main.ui_main.ui_player_state.Set_Job("Angler", "낚시꾼", job_image[0]);
    }

    public void Job_Burglar()
    {
        if (Player_Characteristic.current.player_Job != Player_Job.Burglar)
        {
            if (Player_Characteristic.current.player_Job == Player_Job.fisher)
            {
                Set_TotalPoint_text(4);
            }
            else if (Player_Characteristic.current.player_Job == Player_Job.Veteran)
            {
                Set_TotalPoint_text(8);
            }
            Player_Characteristic.current.player_Job = Player_Job.Burglar;
            Set_TotalPoint_text(-6);

            for (int i = 0; i < value_List.Count;)
            {
                if (value_List[i].Job_type == Player_Job.fisher
                    || value_List[i].Job_type == Player_Job.Veteran)
                {
                    Destroy(value_List[i].gameObject);
                    value_List.RemoveAt(i);
                }
                else
                    i++;
            }


            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Lightfooted)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Lightfooted", "조용한 발걸음", Player_Job.Burglar, Characteristic_Value_type.Lightfooted);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Lightfooted, 2, 100);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }
            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Nimble)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Nimble", "조준시 발걸음", Player_Job.Burglar, Characteristic_Value_type.Nimble);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Nimble, 2, 100);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }
            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Sneaking)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Sneaking", "은밀한 움직임", Player_Job.Burglar, Characteristic_Value_type.Sneaking);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Sneaking, 2, 100);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }

        }        
    }

    public void Job_Veteran()
    {
        if (Player_Characteristic.current.player_Job != Player_Job.Veteran)
        {
            if (Player_Characteristic.current.player_Job == Player_Job.fisher)
            {
                Set_TotalPoint_text(4);
            }
            else if (Player_Characteristic.current.player_Job == Player_Job.Burglar)
            {
                Set_TotalPoint_text(6);
            }
            Player_Characteristic.current.player_Job = Player_Job.Veteran;
            Set_TotalPoint_text(-8);

            for (int i = 0; i < value_List.Count;)
            {
                if (value_List[i].Job_type == Player_Job.fisher
                    || value_List[i].Job_type == Player_Job.Burglar)
                {
                    Destroy(value_List[i].gameObject);
                    value_List.RemoveAt(i);
                }
                else
                    i++;
            }


            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Insensitivity)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Insensitivity", "둔감함", Player_Job.Veteran, Characteristic_Value_type.Insensitivity);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Insensitivity, 1, 0);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }
            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Aiming)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Aiming", "조준", Player_Job.Veteran, Characteristic_Value_type.Aiming);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Aiming, 2, 100);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }
            for (int i = 0; i < value_List.Count; i++)
            {
                if (value_List[i]._type == Characteristic_Value_type.Reloading)
                    break;
                else
                {
                    if (i == value_List.Count - 1)
                    {
                        GameObject Totalvalue = null;
                        Totalvalue = Instantiate(Value_Prefab, Window_value);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Reloading", "재장전", Player_Job.Veteran, Characteristic_Value_type.Reloading);
                        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Reloading, 2, 100);
                        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
                    }
                }
            }

        }

        UI_main.ui_main.ui_player_state.Set_Job("Burglar", "좀도둑", job_image[1]);
    }

    public void Add_value_list(string name, string name_kr, float level, float add_value, Player_Job Job, Characteristic_Value_type type)
    {
        for(int i = 0; i < value_List.Count; i++)
        {
            if (value_List[i].Job_type == Job && value_List[i]._type == type)
            {
                if (level != 0)
                {
                    value_List[i].Set_Characteristic_T_value(type, level, 0);
                }
                if (add_value != 0)
                {
                    value_List[i].Set_Characteristic_T_value(type, 0, add_value);
                }
                break;
            }
            
            if(i == value_List.Count -1 && value_List[i].Job_type != Job && value_List[i]._type != type)
            {
                GameObject Totalvalue = null;
                Totalvalue = Instantiate(Value_Prefab, Window_value);
                Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue(name, name_kr, Job, type);
                Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(type, level, add_value);
                value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
            }
        }

    }

    public void Remove_value_list(Player_Job Job, Characteristic_Value_type type, string name)
    {
        for(int i = 0; i < value_List.Count; i++)
        {
            if (value_List[i].Job_type == Job && value_List[i]._type == type && value_List[i].name == name)
            {
                if (value_List[i].Get_Level() <= 0 && value_List[i].Get_totalvalue() <= 0)
                {
                    Destroy(value_List[i].gameObject);
                    value_List.RemoveAt(i);
                }
            }
        }
    }


    public void Set_Player_Setting_Job()  // [ 다음 ] 버튼 누르면 호출
    {
        for(int i = 0; i < value_List.Count; i++)
        {
            switch(value_List[i]._type)
            {
                case Characteristic_Value_type.Fitness:
                    Player_main.player_main.Skill.Fitness_Level.Set_P_Start_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Strength:
                    Player_main.player_main.Skill.Fitness_Level.Set_P_Start_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Fishing:
                    Player_main.player_main.Skill.Fishing_Level.Set_S_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Lightfooted:
                    Player_main.player_main.Skill.Lightfooted_Level.Set_G_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Nimble:
                    Player_main.player_main.Skill.Nimble_Level.Set_G_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Sneaking:
                    Player_main.player_main.Skill.Sneaking_Level.Set_G_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Insensitivity:
                    
                    break;
                case Characteristic_Value_type.Aiming:
                    Player_main.player_main.Skill.Aiming_Level.Set_Gun_Level(value_List[i].Get_Level());
                    break;
                case Characteristic_Value_type.Reloading:
                    Player_main.player_main.Skill.Reloading_Level.Set_Gun_Level(value_List[i].Get_Level());
                    break;
                default: break;
            }
        }

        UI_main.ui_main.ui_player_state.Set_Job("Veteran", "퇴역 군인", job_image[2]);
    }
}
