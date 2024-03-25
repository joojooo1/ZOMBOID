using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_8x6 : MonoBehaviour
{
    int X_Length = 8;
    int Y_Length = 6;

    InventorySlot[] Slots;

    private void Start()
    {
        Slots = GetComponentsInChildren<InventorySlot>();
        DefiningSlots();
    }

    public void DefiningSlots()
    {
        //x열 0~7
        //y열 0~5


        for (int i = 0; i < Slots.Length; i++)
        {
            int LengthX = 0;
            int LengthY = 0;
            if (i > 7)
            {
                int mul8 = i;
                for (int j = 1; mul8 > 7; j++)
                {
                    mul8 -= 8;
                    if (mul8 <= 7)
                    {
                        LengthY = j;
                        LengthX = mul8;
                    }
                }
                Slots[i].Slot_X = (short)LengthX;
                Slots[i].Slot_Y = (short)LengthY;

            }
            else
            {
                Slots[i].Slot_X = (short)i;
                Slots[i].Slot_Y = 0;
            }
        }
    }

    public void Checking_Slots_For_InCanFit_86(bool IsVirtical, int Lengthof_X, int Lengthof_Y, short X_order, short Y_order)
    {
        //x 0~7
        //y 0~5
        //y1행은 9번째 i=8
        if (!IsVirtical) // 가로 기존형태
        {
            int Order = (Y_order * 8 + X_order);

            if ((Lengthof_X - (X_order)) < Lengthof_X)
            {
                Debug.Log("X Cannot Fit");
            }
            else
            {
                if ((Lengthof_Y - (Y_order)) < Lengthof_Y)
                {
                    Debug.Log("Y Cannot Fit");
                }
                else
                {
                    //공간이 충분하므로 이동연산
                }
            }
        }
        else
        {

        }
    }

    public void Adding_Item()
    {

    }
    public void Deleting_Item()
    {

    }
}
