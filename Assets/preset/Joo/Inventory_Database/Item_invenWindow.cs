using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_Type
{
    empty = 0,
    Food = 1,
    Medical = 2,
    Weapons = 3
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
        for (int i = 0; i < 30; ++i)
        {
            tempObj = Instantiate(slotPrefab, SlotWindow);
            Item_Ins slot = tempObj.GetComponent<Item_Ins>();
            slotlist.Add(slot);
            slotlist[i].SetItem(Item_Type.empty, 0);
        }


        InsertItem((Item_Type)1, 1);
        InsertItem((Item_Type)2, 2);
        InsertItem((Item_Type)3, 3);
    }

    private void Update()
    {
        // 물병 등 다 마시고 Container 로 변경되어야 하는 경우 반영해야 됨
    }


    void InsertItem(Item_Type Type, int ItemCode)
    {
        for (int i = 0; i < slotlist.Count; ++i)
        {
            if (slotlist[i].CurrentType == Item_Type.empty)
            {
                slotlist[i].SetItem(Type, ItemCode);
                return;
            }
        }
    }

}
