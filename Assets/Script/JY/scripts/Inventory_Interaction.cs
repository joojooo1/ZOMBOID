using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Interaction : MonoBehaviour
{
    public static Inventory_Interaction Inventory_InAct;

    void Awake()
    {
        Inventory_InAct = this; // 인스턴스

        
    }
}
