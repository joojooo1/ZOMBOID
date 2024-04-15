using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Characteristic_Value_type
{
    Fitness = 0,
    Strength = 1,
    Fishing = 2,
    Burglar = 3,
    Veteran = 4
}

public class UI_Title : MonoBehaviour
{
    public static UI_Title ui_title;

    public Button[] Button_Job;

    public Transform Window_value;
    [SerializeField] GameObject Value_Prefab;
    List<UI_Title_Characteristic_value_prefab> value_List = new List<UI_Title_Characteristic_value_prefab>();

    void Awake()
    {
        ui_title = this;
    }

    private void OnEnable()
    {
        for(int i = 0; i < 2; i++)
        {
            GameObject Totalvalue = Instantiate(Value_Prefab, Window_value);
            value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
        }
        value_List[0].Create_Totalvalue("Fitness", Characteristic_Value_type.Fitness);
        value_List[0].Set_Characteristic_T_value(Characteristic_Value_type.Fitness, 5);
        value_List[1].Create_Totalvalue("Strength", Characteristic_Value_type.Strength);
        value_List[1].Set_Characteristic_T_value(Characteristic_Value_type.Strength, 5);
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
    }

    public void Job_fisher()
    {
        Debug.Log("Job_fisher");
        for (int i = 0; i < value_List.Count; i++)
        {
            if (value_List[i]._type == Characteristic_Value_type.Burglar
                || value_List[i]._type == Characteristic_Value_type.Veteran)
            {
                value_List.Remove(value_List[i]);
            }
        }
        GameObject Totalvalue = null;
        Totalvalue = Instantiate(Value_Prefab, Window_value);
        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Fishing", Characteristic_Value_type.Fishing);
        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Fishing ,3);
        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
    }

    public void Job_Burglar()
    {
        Debug.Log("Job_burglar");
        for (int i = 0; i < value_List.Count; i++)
        {
            if (value_List[i]._type == Characteristic_Value_type.Fishing
                || value_List[i]._type == Characteristic_Value_type.Veteran)
            {
                value_List.Remove(value_List[i]);
            }
        }
        GameObject Totalvalue = null;
        Totalvalue = Instantiate(Value_Prefab, Window_value);
        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Burglar", Characteristic_Value_type.Burglar);
        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Burglar, 3);
        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
    }

    public void Job_Veteran()
    {
        Debug.Log("Job_veteran");
        for (int i = 0; i < value_List.Count; i++)
        {
            if (value_List[i]._type == Characteristic_Value_type.Fishing
                || value_List[i]._type == Characteristic_Value_type.Burglar)
            {
                value_List.Remove(value_List[i]);
            }
        }
        GameObject Totalvalue = null;
        Totalvalue = Instantiate(Value_Prefab, Window_value);
        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Create_Totalvalue("Veteran", Characteristic_Value_type.Veteran);
        Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>().Set_Characteristic_T_value(Characteristic_Value_type.Veteran ,3);
        value_List.Add(Totalvalue.GetComponent<UI_Title_Characteristic_value_prefab>());
    }

}
