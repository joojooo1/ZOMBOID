using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Title_Characteristic_value_prefab : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text value_name;
    [SerializeField] UnityEngine.UI.Text value_totalvalue;
    public Characteristic_Value_type _type;
    string _name;
    float _totalValue;

    public void Create_Totalvalue(string name, Characteristic_Value_type type)
    {
        _name = name;
        _totalValue = 0;
        _type = type;
    }


    public void Set_Characteristic_T_value(Characteristic_Value_type type, float value)
    {
        switch (type)
        {
            case Characteristic_Value_type.Fitness:
                _totalValue += value;
                break;
            case Characteristic_Value_type.Strength:
                _totalValue += value;
                break;
            case Characteristic_Value_type.Fishing:
                _totalValue += value;
                break;
            case Characteristic_Value_type.Burglar:

                break;
            case Characteristic_Value_type.Veteran:

                break;
            default: break;
        }

        value_name.text = _name;
        if(_totalValue > 0)
        {
            value_totalvalue.text = "+ " + _totalValue.ToString();
            value_name.color = Color.green;
            value_totalvalue.color = Color.green;
        }
        else
        {
            value_totalvalue.text = "- " + _totalValue.ToString();
            value_name.color = Color.red;
            value_totalvalue.color = Color.red;
        }

    }


}
