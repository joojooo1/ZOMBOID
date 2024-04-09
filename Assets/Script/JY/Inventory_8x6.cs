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

    public GameObject SlotPrefeb;


    Item_Container ThisID;
    InventorySlot[] Slots;

    short[,,] packageExample1 =
    {
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {1,0,1,0,0,0},
            {0,0,0,0,0,0},
            {1,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {9,0,18,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
           {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        },
        {
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0},
            {0,0,0,0,0,0}
        }
    };

    private void Start()
    {
        
        ThisID = Item_DataBase.item_database.Container_Ins[8];
        Generating_Slots_First(packageExample1);
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
            GameObject prefeb = Instantiate(SlotPrefeb, new Vector3(0f, 0f, 0f), Quaternion.identity);
            prefeb.transform.SetParent(this.transform);
            prefeb.GetComponentInChildren<Canvas>().sortingOrder = 1;
            prefeb.transform.localScale = Vector3.one;
            RectTransform canvasRectTransform = prefeb.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
            canvasRectTransform.anchorMin = new Vector2(0f, 1f);
            canvasRectTransform.anchorMax = new Vector2(0f, 1f);
            canvasRectTransform.localPosition = Vector3.zero;
            canvasRectTransform.sizeDelta = Vector2.zero;
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

            SlotsDefine.Add(prefeb.GetComponent<InventorySlot>());
            
        }
        Slots = SlotsDefine.ToArray();

        for(int YLine =0; YLine < y; YLine++)
        {
            for(int XLine = 0; XLine<x; XLine++)
            {
                if (!(package[0, XLine, YLine] == 0))
                {
                    Slots[YLine * X_Length + XLine].Image.sprite = Item_DataBase.item_database.Requesting_Image(package[0, XLine, YLine], package[1, XLine, YLine]);
                    Slots[YLine * X_Length + XLine].Item_Type = package[0, XLine, YLine];
                    Slots[YLine * X_Length + XLine].Item_ID = package[1, XLine, YLine];
                    Slots[YLine * X_Length + XLine].IsMain = true;

                }
            }
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
