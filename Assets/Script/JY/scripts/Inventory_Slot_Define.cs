
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDropHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    bool IsPointerIn = false;
    public short Storage_Order_IfPlayer;//플레이어 저장소 순서
    public short Slot_X;
    public short Slot_Y;

    public short Item_Type;
    public short Item_ID;
    public short Item_Amount;
    public short Item_Weight;
    public bool Is_Virtical;
    public bool Is_Virtical_While_Moving;

    public bool IsMain;
    public Transform What_Main;

    Text Count;
    Image Image;

    public void Start()
    {
        Image = GetComponentInChildren<Image>();
        Count = GetComponentInChildren<Text>();
        //count, image 연동 DB연동
    }

    public void Refresh_This_Slot()
    {
        //ID로 이미지 가져옴
        Count.text = Item_Amount.ToString();
        //Image.sprie =

    }
    public void OnBeginDrag(PointerEventData eventData) // 시작
    {
        //InventoryOvermind.InventoryOM.FSN = InventorySlotNum;
        Debug.Log("BeingDrag");
        Inventory_Player_Shown.InvPS.FS_Slot_X = Slot_X;
        Inventory_Player_Shown.InvPS.FS_Slot_Y = Slot_Y;
        Is_Virtical_While_Moving = Is_Virtical;
        if (Storage_Order_IfPlayer != 0)
        {
            Inventory_Player_Shown.InvPS.FS_Is_Player = true;
            Inventory_Player_Shown.InvPS.FS_Slot_Order = Storage_Order_IfPlayer;
        }

    }
    public void OnDrop(PointerEventData eventDate) // 성공
    {
        Debug.Log("Drop");
        //Debug.Log("Drop");
        Inventory_Player_Shown.InvPS.LS_Slot_X = Slot_X;
        Inventory_Player_Shown.InvPS.LS_Slot_Y = Slot_Y;
        if (Inventory_Player_Shown.InvPS.FS_Slot_Y != Inventory_Player_Shown.InvPS.LS_Slot_Y &&
            Inventory_Player_Shown.InvPS.FS_Slot_X != Inventory_Player_Shown.InvPS.LS_Slot_X) // 제자리 연산 검증
        {
            //InventoryOvermind.InventoryOM.ItemAdd(0, InventoryOvermind.InventoryOM.ItemCountArray[InventorySlotNum]);
            //드롭이 정상진행 되어야 교환 함수 실행
        }


    }
    public void OnDrag(PointerEventData eventData) //진행
    {
        //InventoryOvermind.InventoryOM.DraggingImage(eventData, InventorySlotNum);
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Is_Virtical_While_Moving)
            {
                Is_Virtical_While_Moving = false;
            }
            else
            {
                Is_Virtical_While_Moving = true;
            }
            Inventory_Player_Shown.InvPS.FS_Is_Virtical = Is_Virtical_While_Moving;
            //UPDATE
        }
        Inventory_Player_Shown.InvPS.Drag_Target_Prefeb.transform.position = new Vector3(Input.mousePosition.x+10,Input.mousePosition.y-10,0);
    }

    public void OnEndDrag(PointerEventData eventData) // 무조건 실행
    {
        //Debug.Log("DragFailed");

        //UserStatusTextController.USTC.StatusRefresh();

        //InventoryOvermind.InventoryOM.DragFailed();
        //드래그 타겟 이미지 비활성화
        Inventory_Player_Shown.InvPS.Drag_Target_Prefeb.transform.position = new Vector3(5000, 5000, 0);
        Debug.Log("EndDrag");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsPointerIn = true;
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
        IsPointerIn = false;
        //ItemInfoTextBox.InfoTextBox.TextSet(null, 0, 0, 0, IsPointerIn, null);

    }
}
