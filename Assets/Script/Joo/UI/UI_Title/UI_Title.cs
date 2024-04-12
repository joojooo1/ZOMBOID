using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title : MonoBehaviour
{
    public static UI_Title ui_title;

    public Button[] Button_Job;

    void Awake()
    {
        ui_title = this;
    }

    public void On_Button(int index)
    {
        ColorBlock col_0 = Button_Job[0].colors;
        ColorBlock col_1 = Button_Job[1].colors;
        ColorBlock col_2 = Button_Job[2].colors;

        if (index == 0)
        {
            Button_Job[0].onClick.AddListener(Job_fisher);
            Button_Job[1].onClick.RemoveListener(Job_burglar);
            Button_Job[2].onClick.RemoveListener(Job_veteran);

            col_0.normalColor = new Color32(96, 96, 96, 153);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[2].colors = col_2;

            for (int i = 0; i < Player_Characteristic.instance.characteristics_Player.Count; i++)
            {
                if (Player_Characteristic.instance.characteristics_Player[i].Prefab.type == Characteristic_type.Occupation)
                {
                    Player_Characteristic.instance.Remove_Selected_list(i, true);
                }
            }

            GameObject tempObj = null;
            Player_Characteristic.instance.Set_Characteristic(54, true, tempObj);
        }
        else if(index == 1)
        {
            Button_Job[0].onClick.RemoveListener(Job_fisher);
            Button_Job[1].onClick.AddListener(Job_burglar);
            Button_Job[2].onClick.RemoveListener(Job_veteran);

            col_0.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(96, 96, 96, 153);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[2].colors = col_2;

            for (int i = 0; i < Player_Characteristic.instance.characteristics_Player.Count; i++)
            {
                if (Player_Characteristic.instance.characteristics_Player[i].Prefab.type == Characteristic_type.Occupation)
                {
                    Player_Characteristic.instance.Remove_Selected_list(i, true);
                }
            }

            GameObject tempObj = null;
            Player_Characteristic.instance.Set_Characteristic(52, true, tempObj);
        }
        else if(index == 2)
        {
            Button_Job[0].onClick.RemoveListener(Job_fisher);
            Button_Job[1].onClick.RemoveListener(Job_burglar);
            Button_Job[2].onClick.AddListener(Job_veteran);

            col_0.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[0].colors = col_0;
            col_1.normalColor = new Color32(0, 0, 0, 26);
            Button_Job[1].colors = col_1;
            col_2.normalColor = new Color32(96, 96, 96, 153);
            Button_Job[2].colors = col_2;

            for (int i = 0; i < Player_Characteristic.instance.characteristics_Player.Count; i++)
            {
                if (Player_Characteristic.instance.characteristics_Player[i].Prefab.type == Characteristic_type.Occupation)
                {
                    Player_Characteristic.instance.Remove_Selected_list(i, true);
                }
            }

            GameObject tempObj = null;
            Player_Characteristic.instance.Set_Characteristic(53, true, tempObj);
        }
    }

    public void Job_fisher()
    {
        Debug.Log("Job_fisher");
    }

    public void Job_burglar()
    {
        Debug.Log("Job_burglar");
    }

    public void Job_veteran()
    {
        Debug.Log("Job_veteran");
    }

}
