
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDropHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    bool IsPointerIn = false;
    public short Storage_Order_IfPlayer;//플레이어 저장소 순서
    public short Slot_X; // v
    public short Slot_Y; // v

    public short Item_Type; // v
    public short Item_ID; // v
    public short Item_Amount;
    public short Item_Weight;

    public bool Is_Virtical_Changed;
    public bool Is_Virtical_While_Moving;
    public int Size;

    public bool Equipment;
    public int EquipPosition;


    bool First_Con = false;

    public bool IsMain; // v false= 종속(빈칸이 아님)
    public Transform What_Main; // v
    public int Is_Changed;

    public Transform ParentTransform;
    public short ParentSize;

    public GameObject Putti;
    public GameObject Text;
    public GameObject Image;
    public GameObject BorderLine;
    public GameObject BackgroundColor;

    public void Start()
    {
        //count, image 연동 DB연동
    }
    public void On_F()
    {
        First_Con = true;
    }
    public void Off_F()
    {
        First_Con = false;
    }
    public bool Req_F()
    {
        bool Is_Setting;
        Is_Setting = First_Con;
        return Is_Setting;
    }

    public void Refresh_This_Slot()
    {
        //Count.text = Item_Amount.ToString();
        //Image.sprie =

    }
    public void OnBeginDrag(PointerEventData eventData) // 시작
    {
        if (IsMain)
        {
            Debug.Log("BeingDrag");
            Inventory_Player_Shown.InvPS.FS_Slot_X = Slot_X;
            Inventory_Player_Shown.InvPS.FS_Slot_Y = Slot_Y;
            Is_Virtical_While_Moving = Is_Virtical_Changed;

            Inventory_Player_Shown.InvPS.FS_Is_Player = true;
            Inventory_Player_Shown.InvPS.FS_Slot_Order = Storage_Order_IfPlayer;

            Inventory_Player_Shown.InvPS.FSParent = ParentTransform;
            Inventory_Player_Shown.InvPS.FSPSize = ParentSize;
            Inventory_Player_Shown.InvPS.FS_Item_Size = Size;

            Inventory_Player_Shown.InvPS.FSItSelf = this.transform;
            Inventory_Player_Shown.InvPS.SubRequest_Drag_Image();
        }
        else
        {
            Inventory_Player_Shown.InvPS.FS_Slot_X = What_Main.GetComponent<InventorySlot>().Slot_X;
            Inventory_Player_Shown.InvPS.FS_Slot_Y = What_Main.GetComponent<InventorySlot>().Slot_Y;
            Is_Virtical_While_Moving = Is_Virtical_Changed;

            Inventory_Player_Shown.InvPS.FS_Is_Player = true;
            Inventory_Player_Shown.InvPS.FS_Slot_Order = Storage_Order_IfPlayer;

            Inventory_Player_Shown.InvPS.FSParent = ParentTransform;
            Inventory_Player_Shown.InvPS.FSPSize = ParentSize;
            Inventory_Player_Shown.InvPS.FS_Item_Size = What_Main.GetComponent<InventorySlot>().Size;

            Inventory_Player_Shown.InvPS.FSItSelf = What_Main.GetComponent<InventorySlot>().transform;
            Inventory_Player_Shown.InvPS.SubRequest_Drag_Image();
        }
    }
    public void OnDrop(PointerEventData eventDate) // 성공
    {
        if (IsMain)
        {
            Debug.Log("Drop");
            Inventory_Player_Shown.InvPS.LS_Slot_X = Slot_X;
            Inventory_Player_Shown.InvPS.LS_Slot_Y = Slot_Y;
            //Inventory_Player_Shown.InvPS.LS_Transform = this.transform;
            if (Inventory_Player_Shown.InvPS.FS_Slot_Y == Inventory_Player_Shown.InvPS.LS_Slot_Y &&
                Inventory_Player_Shown.InvPS.FS_Slot_X == Inventory_Player_Shown.InvPS.LS_Slot_X&&
                Inventory_Player_Shown.InvPS.FSParent == Inventory_Player_Shown.InvPS.LSParent) // 제자리 연산 검증
            {
                Debug.Log("Same Location");
                return;
            }

            Inventory_Player_Shown.InvPS.LSParent = ParentTransform;
            Inventory_Player_Shown.InvPS.LSPSize = ParentSize;
            Inventory_Player_Shown.InvPS.LSItSelf = this.transform;
            Inventory_Player_Shown.InvPS.Move_Request();
        }
        else
        {
            Inventory_Player_Shown.InvPS.LS_Slot_X = What_Main.GetComponent<InventorySlot>().Slot_X;
            Inventory_Player_Shown.InvPS.LS_Slot_Y = What_Main.GetComponent<InventorySlot>().Slot_Y;
            if (Inventory_Player_Shown.InvPS.FS_Slot_Y == Inventory_Player_Shown.InvPS.LS_Slot_Y &&
                Inventory_Player_Shown.InvPS.FS_Slot_X == Inventory_Player_Shown.InvPS.LS_Slot_X &&
                Inventory_Player_Shown.InvPS.FSParent == Inventory_Player_Shown.InvPS.LSParent) // 제자리 연산 검증
            {
                Debug.Log("Same Location");
                return;
            }
            Inventory_Player_Shown.InvPS.LSParent = ParentTransform;
            Inventory_Player_Shown.InvPS.LSPSize = ParentSize;
            Inventory_Player_Shown.InvPS.LSItSelf = What_Main.GetComponent<InventorySlot>().transform;
            Inventory_Player_Shown.InvPS.Move_Request();
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
        Inventory_Player_Shown.InvPS.Drag_Target_Prefeb.transform.position = new Vector3(Input.mousePosition.x-10, Input.mousePosition.y-30, 0);
        //Inventory_Player_Shown.InvPS.
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
        if (IsMain)
        {
            IsPointerIn = true;
            Inventory_Player_Shown.InvPS.LS_Slot_X = Slot_X;
            Inventory_Player_Shown.InvPS.LS_Slot_Y = Slot_Y;
            Inventory_Player_Shown.InvPS.LSParent = ParentTransform;
            Inventory_Player_Shown.InvPS.LSPSize = ParentSize;
            Inventory_Player_Shown.InvPS.LSItSelf = this.transform;
            if (Inventory_Player_Shown.InvPS.Drag_Check_Only())
            {
                Inventory_Player_Shown.InvPS.Drag_Target_Prefeb.GetComponent<Inventry_DragImage>().Change_Border_Color(true);
            }
        }
        else
        {
            IsPointerIn = true;
            Inventory_Player_Shown.InvPS.LS_Slot_X = What_Main.GetComponent<InventorySlot>().Slot_X;
            Inventory_Player_Shown.InvPS.LS_Slot_Y = What_Main.GetComponent<InventorySlot>().Slot_Y;
            Inventory_Player_Shown.InvPS.LSParent = ParentTransform;
            Inventory_Player_Shown.InvPS.LSPSize = ParentSize;
            Inventory_Player_Shown.InvPS.LSItSelf = What_Main.GetComponent<InventorySlot>().transform;
            if (Inventory_Player_Shown.InvPS.Drag_Check_Only())
            {
                Inventory_Player_Shown.InvPS.Drag_Target_Prefeb.GetComponent<Inventry_DragImage>().Change_Border_Color(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsPointerIn = false;
        Inventory_Player_Shown.InvPS.Drag_Target_Prefeb.GetComponent<Inventry_DragImage>().Change_Border_Color(false);
        //ItemInfoTextBox.InfoTextBox.TextSet(null, 0, 0, 0, IsPointerIn, null);

    }
}
