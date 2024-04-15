using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Title_Characteristic_text : MonoBehaviour
{
    public static UI_Title_Characteristic_text Characteristic_text;
    public GameObject Characteristic_info_Window;
    public UnityEngine.UI.Text Characteristic_name;
    public UnityEngine.UI.Text Characteristic_info;
    public UnityEngine.UI.Text Characteristic_point;

    private void Awake()
    {
        Characteristic_text = this;
    }

    public void Open_text(string name, string Explanation_for_Characteristic, int Points)
    {
        Characteristic_info_Window.SetActive(true);
        Characteristic_name.text = name;
        Characteristic_info.text = Explanation_for_Characteristic;
        if(Points > 0)
        {
            Characteristic_point.text = "+" + Points.ToString();
            Characteristic_point.color = Color.red;
        }
        else
        {
            Characteristic_point.text = Points.ToString();
            Characteristic_point.color = Color.green;
        }        
    }

    public void Close_text()
    {
        Characteristic_info_Window.SetActive(false);
    }

}
