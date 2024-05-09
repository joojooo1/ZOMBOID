using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPIcon_SimpleAct : MonoBehaviour
{
    public Transform Reverse_Lovation;
    public short Its_Own_Order;
    private Toggle Toggle;
    public bool IsBasic = false;
    public bool IsPlayer = false;

    private void Start()
    {
        Toggle = GetComponent<Toggle>();
        Toggle.onValueChanged.AddListener(delegate { ToggleValueChanged(Toggle.isOn); });
    }

    public void ToggleValueChanged(bool IsOn)
    {

        if (IsPlayer == true)
        {
            if (IsBasic)
            {
                Return_Basic();
            }
            else if (IsOn)
            {
                Request_Selected();
            }
        }
        else
        {
            if (IsBasic)
            {
                Return_Basic();
            }
            else if (IsOn)
            {
                Request_Selected();
            }
        }
    }

    public void Request_Selected()
    {
        Inventory_Player_Shown.InvPS.When_Selected_BPIcons(Its_Own_Order);
    }

    public void Return_Basic()
    {
        Inventory_Player_Shown.InvPS.Return_Basic_BPIcons();
    }
}
