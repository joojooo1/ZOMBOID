using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Title_Characteristic_Add : MonoBehaviour
{
    public static UI_Title_Characteristic_Add UI_Characteristic_Add;

    public UnityEngine.UI.Button P_button;

    private void Awake()
    {
        UI_Characteristic_Add = this;
    }

    public void Set_Add_button_P()
    {
        P_button.IsActive();
    }


}
