using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_8x6 : MonoBehaviour
{
    int X_Length = 8;
    int Y_Length = 6;
    public short Storage_Order;
    short[,,] Recent_Recieved_Package;

    Item_Container ThisID;
    InventorySlot[] Slots;

    short[,,] packageExample1 = new short[5, 8, 6];

    public void Example()
    {
        for (int deep = 0; deep < 5; deep++)
        {
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x < 2 && y < 2 && deep == 0)
                    {
                        packageExample1[deep, x, y] = 1;

                    }
                    if (x < 2 && y < 2 && deep == 1)
                    {
                        packageExample1[deep, x, y] = 1;
                    }
                }
            }
        }
    }

    private void Start()
    {
        Slots = GetComponentsInChildren<InventorySlot>();
        ThisID = Item_DataBase.item_database.Container_Ins[8];
        Example();
        DefiningSlots();
        //Generating_Slots_First(packageExample);
    }
    public void Generating_Slots_First(short[,,] package)
    {
        int x = package.GetLength(1);
        int y = package.GetLength(2);
        int deep = package.GetLength(0);
        List<InventorySlot> SlotsDefine = new List<InventorySlot>();

        for (int amountofslots = 0; amountofslots < x * y; amountofslots++)
        {
            //prefeb 积己
            //0~7, 0~5
            GameObject prefeb = null;
            prefeb.GetComponentInChildren<Canvas>().sortingOrder = 1;
            if (amountofslots >= 8)
            {
                prefeb.GetComponent<InventorySlot>().Slot_Y = (short)(amountofslots / 8);
                prefeb.GetComponent<InventorySlot>().Slot_X = (short)(amountofslots % 8);
            }
            else
            {
                prefeb.GetComponent<InventorySlot>().Slot_X = (short)amountofslots;
                prefeb.GetComponent<InventorySlot>().Slot_Y = 0;
            }

            //SlotsDefine.Add ~~~
            Slots = SlotsDefine.ToArray();
        }


    }
    public void Refreshing_Changed_Slots()
    {

    }

    public bool Checking_Only_Size_For_InCanFit_86(bool IsVirtical, int First_Item_Lengthof_X, int First_Item_Lengthof_Y,
        short Last_Slot_X_order, short Last_Slot_Y_order)
    //Length = 1何磐, order绰 0何磐
    {
        bool Clear = false;

        int x = First_Item_Lengthof_X;
        int y = First_Item_Lengthof_Y;

        int sx = Last_Slot_X_order;
        int sy = Last_Slot_Y_order;

        int xl = X_Length;
        int yl = Y_Length;

        if (!IsVirtical)
        {

            x = First_Item_Lengthof_Y;
            y = First_Item_Lengthof_X;

            sx = Last_Slot_X_order;
            sy = Last_Slot_Y_order;

            xl = X_Length;
            yl = Y_Length;
        }

        if (((x - 1) + sx < xl))
        {
            if (((y - 1) + sy) < yl)
            {
                Clear = true;
            }
        }
        else return Clear;

        if (true)
        {
            for(int Ysecond = 0; Ysecond < y; Ysecond++)
            {
                for(int Xfirst = 0; Xfirst < x; Xfirst++)
                {
                    if (!(Recent_Recieved_Package[0, Last_Slot_X_order+Xfirst, Last_Slot_Y_order+Ysecond] == 0))
                    {
                        return Clear;
                    }
                }
            }
        }


        return Clear;
    }

    public void Adding_Item()
    {

    }
    public void Deleting_Item()
    {

    }
}
