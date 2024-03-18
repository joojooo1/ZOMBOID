using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{
    bool IsPointerIn = false;
    public int Storage_Num;
    public int Slot_X;
    public int Slot_Y;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("DragStart");
        //InventoryOvermind.InventoryOM.FSN = InventorySlotNum;


    }
    public void OnDrag(PointerEventData eventData)
    {
        //InventoryOvermind.InventoryOM.DraggingImage(eventData, InventorySlotNum);
    }
    public void OnDrop(PointerEventData eventDate)
    {
        //Debug.Log("Drop");
        //InventoryOvermind.InventoryOM.LSN = InventorySlotNum;
        //if (InventoryOvermind.InventoryOM.FSN != InventoryOvermind.InventoryOM.LSN)
        //{
        //    InventoryOvermind.InventoryOM.ItemAdd(0, InventoryOvermind.InventoryOM.ItemCountArray[InventorySlotNum]);
        //}

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("DragFailed");

        //UserStatusTextController.USTC.StatusRefresh();

        //InventoryOvermind.InventoryOM.DragFailed();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //IsPointerIn = true;
        //if (InventoryOvermind.InventoryOM.ItemCodeArray[InventorySlotNum] != 0)
        //{
        //    string name = InventoryOvermind.InventoryOM.ItemDataBase[InventoryOvermind.InventoryOM.ItemCodeArray[InventorySlotNum]].ItemName;
        //    float att = InventoryOvermind.InventoryOM.ItemDataBase[InventoryOvermind.InventoryOM.ItemCodeArray[InventorySlotNum]].ItemAtdStat;
        //    float def = InventoryOvermind.InventoryOM.ItemDataBase[InventoryOvermind.InventoryOM.ItemCodeArray[InventorySlotNum]].ItemDefStat;
        //    int amount = InventoryOvermind.InventoryOM.ItemCountArray[InventorySlotNum];
        //    ItemInfoTextBox.InfoTextBox.TextSet(name, att, def, amount, IsPointerIn, gameObject);
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //IsPointerIn = false;
        //ItemInfoTextBox.InfoTextBox.TextSet(null, 0, 0, 0, IsPointerIn, null);
    }
}
