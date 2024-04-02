using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_8x6 : MonoBehaviour
{
    int X_Length = 8;
    int Y_Length = 6;
    Item_Container ThisID;
    InventorySlot[] Slots;

    short[,,] packageExample = new short[5, 8, 6];
    
    public void Example()
    {
        for(int deep = 0; deep < 5; deep++)
        {
            for(int y=0; y < 6; y++)
            {
                for(int x = 0; x < 8; x++)
                {
                    if (x < 2 && y < 2&&deep==0)
                    {
                        packageExample[deep, x, y] = 1;
                        
                    }
                    if (x < 2 && y < 2 && deep == 1)
                    {
                        packageExample[deep, x, y] = 1;
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
        int x =package.GetLength(1);
        int y = package.GetLength(2);
        int deep = package.GetLength(0);

        for(int i=0;i < Slots.Length; i++)
        {
            int Slot_x = (int)Slots[i].Slot_X;
            int Slot_y = (int)Slots[i].Slot_Y;

            for(int a=0;a< Slot_y; a++)
            {
                for(int b = 0; b < Slot_x; b++)
                {
                    if (package[0, b, a] != 0)//x,y축을 순차적으로 순회, z축0번 아이템타입을 확인 타입이0이 아니면 정보가 있음
                    {
                        for(int c = 0; c < deep; c++)
                        {
                            //int sum = (y * 8) + x;
                            //Slots[sum].GetComponentInChildren<Image>().sprite = Item_DataBase.item_database.food_Ins[package[1, b, a]].Food_Image[0];
                        }
                    }


                }
            }



        }

       for(int a = 0; a < y; a++)
        {
            for(int b=0; b< x; a++)
            {
                for(int c = 0; c < deep; c++)
                {
                    if (deep == 0)
                    {
                        if (package[c, b, a] != 0)
                        {

                        }
                    }
                }
            }
        }
    }
    public void Refreshing_Changed_Slots()
    {

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
