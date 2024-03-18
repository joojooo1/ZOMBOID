using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class Inventory_Controller : MonoBehaviour
{
    public static Inventory_Controller InvC;

    private GameObject DragTargetImage;

    [SerializeField]
    private GameObject ItemInfoBox;

    public Inventory_SlotsEach[] Slots_Array;
    public int ID_Array;
    public int Count_Array;

    int FirstSNX;
    int FirstSNY;
    int LastSNX;
    int LastSNY;

    private void Awake()
    {
        InvC = this;
    }

    void InventoryGenerating()
    {

    }
}
