using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Title_Characteristic_value_prefab : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text value_name;
    [SerializeField] UnityEngine.UI.Text value_totalvalue;
    public Player_Job Job_type;
    public Characteristic_Value_type _type;
    string _name;
    string _name_kr;
    string Job_name;
    string Job_name_kr;
    float _level;
    float _add_value;

    public void Create_Totalvalue(string name, string name_kr, float level, Player_Job Job, Characteristic_Value_type type)
    {
        switch (Job)
        {
            case Player_Job.None:
                break;
            case Player_Job.fisher:
                Job_name = "Angler";
                Job_name_kr = "³¬½Ã²Û";
                break;
            case Player_Job.Burglar:
                Job_name = "Burglar";
                Job_name_kr = "Á»µµµÏ";
                break;
            case Player_Job.Veteran:
                Job_name = "veteran";
                Job_name_kr = "Åð¿ª ±ºÀÎ";
                break;
            default: break;
        }
        _name = name;
        _name_kr = name_kr;
        _level = level;
        _type = type;
        Job_type = Job;
        _add_value = 0;
    }


    public void Set_Characteristic_T_value(Characteristic_Value_type type, float value)
    {
        switch (type)
        {
            case Characteristic_Value_type.Fitness:
                _add_value += value;
                break;
            case Characteristic_Value_type.Strength:
                _add_value += value;
                break;
            case Characteristic_Value_type.Fishing:
                _add_value += value;
                break;
            case Characteristic_Value_type.Foraging:
                _add_value += value;
                break;
            case Characteristic_Value_type.Lightfooted:
                _add_value += value;
                break;
            case Characteristic_Value_type.Nimble:
                _add_value += value;
                break;
            case Characteristic_Value_type.Sneaking:
                _add_value += value;
                break;
            case Characteristic_Value_type.Insensitivity:
                _add_value += value;
                break;
            case Characteristic_Value_type.Aiming:
                _add_value += value;
                break;
            case Characteristic_Value_type.Reloading:
                _add_value += value;
                break;
            default: break;
        }

        Set_Language();
        if (_add_value >= 0)
        {
            if (type == Characteristic_Value_type.Insensitivity)
                value_totalvalue.text = "";
            else
            {
                if(_level > 0)
                {
                    if (_add_value > 0)
                        value_totalvalue.text = "Lv." + _level.ToString() + "(+" + _add_value.ToString() + "%)";
                    else
                        value_totalvalue.text = "Lv." + _level.ToString();
                }
                else
                {
                    if (_add_value > 0)
                        value_totalvalue.text = _add_value.ToString() + "%";
                    else
                        value_totalvalue.text = "";
                }

            }
            value_name.color = Color.green;
            value_totalvalue.color = Color.green;
        }
        else
        {
            value_totalvalue.text = "- " + _add_value.ToString();
            value_name.color = Color.red;
            value_totalvalue.color = Color.red;
        }

    }

    public float Get_Level()
    {
        return _level;
    }

    public float Get_totalvalue()
    {
        return _add_value;
    }

    public void Set_Language()
    {
        if (UI_main.ui_main.player_Setting_Language_to_Korean)
        {
            value_name.text = _name_kr;
        }
        else
        {
            value_name.text = _name;
        }
    }

}
