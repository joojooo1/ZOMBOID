using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_Type
{
    Food = 0,
    Medical = 1,
    Weapons = 2
}


public class Item_invenWindow : MonoBehaviour
{
    List<Item_Ins> slotlist = new List<Item_Ins>();
    [SerializeField]
    GameObject slotPrefab;
    [SerializeField]
    Transform SlotWindow;
    void Start()
    {
        GameObject tempObj = null;
        for (int i = 0; i < 5; ++i)
        {
            tempObj = Instantiate(slotPrefab, SlotWindow);
            Item_Ins slot = tempObj.GetComponent<Item_Ins>();
            slotlist.Add(slot);
        }

        InsertItem((Item_Type)0, 1);
        InsertItem((Item_Type)1, 2);
        InsertItem((Item_Type)2, 3);
    }

    void InsertItem(Item_Type Type, int ItemCode)
    {
        for (int i = 0; i < slotlist.Count; ++i)
        {
            slotlist[i].SetItem(Type, ItemCode);
            return;
        }
    }

}
