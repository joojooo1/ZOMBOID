using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeNet;
using VirusWarGameServer;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.EventSystems;

public class Inventory_Player_Shown : MonoBehaviour
{
    public static Inventory_Player_Shown InvPS;
    public enum Storage_Type
    {
        Hand = 0,
        Hipsak = 1,
        SmallBag = 2,
    }

    [SerializeField]
    GameObject User_Inventory; //�»�� ��
    [SerializeField]
    GameObject Storage_Inventory; // ���� ��
    [SerializeField]
    GameObject Info_Box; // �������� ǥ�� â UI
    [SerializeField]
    public Transform Drag_Target_Prefeb; // v �巡������ �̹���

    public List<short> Backpacks_List; // ���, ���� ����Ʈ
    public List<short> Storage_List; // �������� ����� ����Ʈ

    public List<short> Storage_Presets_List; // �ʱ� ���� 
    public List<short[,,]> Packages_Player;
    public List<short[,,]> Packages_Storage;// ���, ���濡 �����ϴ� ������ �迭( 1�� type / 2��, id / 3�� ���� / 4�� ���� / 5�� Ư������)

    [SerializeField]
    public List<Transform> Player_Storages;
    [SerializeField]
    public List<Transform> Other_Storages;
    //                                                                              �ż���,��������,��������,ũ��,����
    //2ĭ�̻��� ��κ��� ��� ���µ��� ������ �������� �� ���� �߰������� ����
    //������ ��� ��Ű�� �ε����� ����
    public float Total_Weight; // ? / ?
    short BackPack_Depth_Define = 5;


    public short FS_Slot_X; // v
    public short FS_Slot_Y; // v
    public short FS_Slot_Order;

    public Transform FSParent; // v
    public Transform FSItSelf; // v
    public short FSPSize; // v
    public int FS_Item_Size; // v

    public bool FS_Is_Player;
    public bool FS_Is_Virtical;


    public short LS_Slot_X; // v
    public short LS_Slot_Y; // v
    public short LS_Slot_Order;

    public Transform LSParent; // v
    public Transform LSItSelf; // v
    public short LSPSize; // v

    public bool LS_Is_Player;

    Animator Anim;
    public bool inven_open; // v

    private void Awake()
    {
        InvPS = this;
        Anim = GetComponent<Animator>();
        inven_open = false;
    }

    private void Start()
    {
        //�ʱ� �������길
        //�÷��̾��� ������� ������ backpacks list�� ������ ����
        for (short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
            short[,,] recieve = new short[1, 1, 1];
            recieve = Inventory_Library.IL.Getting_Package(0); // 0 �� ���̺귯�������� ��Ű�� order
            Packages_Player.Add(recieve);

        }


    }

    public void SetAnim(bool open)
    {
        inven_open = open;
        Anim.SetBool("Open", inven_open);
    }

    private void Ready_For_Change_From_Slot()
    {
        //p�迭 s�迭 ���鼭 ����item db ȹ��, ���� 8x6 ��ũ��Ʈ �˻�
        if (FS_Is_Player)
        {
            //Packages_Player[FS_Slot_Order]
        }
        else
        {
            //Packages_Storage[LS_Slot_Order]
        }


    }

    //�÷��̾� ���

    //���� ����Ʈ
    //����ǰ ����Ʈ

    //���� �迭

    //ID�� �����ͺ��̽� ũ������, �ʱ����, ���� , ������ ���� ����

    private void Generating_Acting_Inventory(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        //������ ũ�� ������
        List<GameObject> Slots = new List<GameObject>(); // ���� ����
        short BackPacks_X = (short)Exiest_Packages.GetLength(1);
        short BackPacks_Y = (short)Exiest_Packages.GetLength(2);
        float Sum_Weight = 0;
        //Instantiate for(int i=0;i<XY;i++){
        //instantiate ĭ�� ����
        //slots.add for each
        for (short BP_Depth = 0; BP_Depth < BackPack_Depth_Define; BP_Depth++)
        {
            //( 1�� type / 2��, id / 3�� ���� / 4�� ���� / 5�� Ư������)
            switch (BP_Depth)
            {
                case 0:
                    for (short SlotNumY = 0; SlotNumY < BackPacks_Y; SlotNumY++)
                    {
                        for (short SlotNumX = 0; SlotNumX < BackPacks_X; SlotNumX++)
                        {
                            //Slots[SlotNumX,SlotNumY].GetComponent<Inventory_Slot_Define>().Type set
                            //Slots[SlotNumX,SlotNumY].GetComponent<Inventory_Slot_Define>().Slot Num set
                        }
                    }
                    break;
                case 1:
                    for (short SlotNumY = 0; SlotNumY < BackPacks_Y; SlotNumY++)
                    {
                        for (short SlotNumX = 0; SlotNumX < BackPacks_X; SlotNumX++)
                        {
                            //Slots[SlotNumX,SlotNumY].GetComponent<Inventory_Slot_Define>().ID set
                        }
                    }
                    break;
                case 2:
                    for (short SlotNumY = 0; SlotNumY < BackPacks_Y; SlotNumY++)
                    {
                        for (short SlotNumX = 0; SlotNumX < BackPacks_X; SlotNumX++)
                        {
                            //Slots[SlotNumX,SlotNumY].GetComponent<Inventory_Slot_Define>().Amount set
                        }
                    }
                    break;
                case 3:
                    for (short SlotNumY = 0; SlotNumY < BackPacks_Y; SlotNumY++)
                    {
                        for (short SlotNumX = 0; SlotNumX < BackPacks_X; SlotNumX++)
                        {
                            //Slots[SlotNumX,SlotNumY].GetComponent<Inventory_Slot_Define>().Weight set
                        }
                    }
                    break;
                case 4:
                    for (short SlotNumY = 0; SlotNumY < BackPacks_Y; SlotNumY++)
                    {
                        for (short SlotNumX = 0; SlotNumX < BackPacks_X; SlotNumX++)
                        {
                            //Slots[SlotNumX,SlotNumY].GetComponent<Inventory_Slot_Define>().Special set
                        }
                    }
                    break;
                case 5:
                    break;

            }

            foreach (GameObject slotsEach in Slots)
            {
                //slotsEach.GetComponent<InventorySlot>().Refresh_This_Slot;
                //Sum_Weight += slotsEach.GetComponent<InventorySlot>().Weight;
            }
        }


        Backpacks_List.Add(Backpack_ID);
        //Packages.Add(Exiest_Packages);

    }

    public bool Drag_Check_Only()
    {
        int Width = FS_Item_Size / 100;
        int Height = FS_Item_Size % 10;
        short[,,] CopyPackage_FS = new short[1, 1, 1];
        short[,,] CopyPackage_LS = new short[1, 1, 1];
        switch (FSPSize)
        {
            case 86:
                CopyPackage_FS = FSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                break;
        }
        switch (LSPSize)
        {
            case 86:
                CopyPackage_LS = LSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                break;
        }
        
        return Checking_Only_Size_For_InCanFit_All(FS_Is_Virtical, Width, Height, LS_Slot_X, LS_Slot_Y, (int)LSPSize / 10, (int)LSPSize % 10, CopyPackage_LS);
    }

    public void SubRequest_Drag_Image()
    {
        Sprite Image = null;
        short Type = FSItSelf.GetComponent<InventorySlot>().Item_Type;
        short ID = FSItSelf.GetComponent<InventorySlot>().Item_ID;
        int Size = FSItSelf.GetComponent<InventorySlot>().Size;

        int Width= (int)Size / 100;
        int Height= (int)Size % 10;

        int Canvas_Width = SlotSize_Req(Width);
        int Canvas_Height = SlotSize_Req(Height);

        Image =Item_DataBase.item_database.Requesting_Image(Type, ID);


        Drag_Target_Prefeb.GetComponent<Inventry_DragImage>().Change_Image(Image, Width, Height, Canvas_Width, Canvas_Height);
    }

    private int SlotSize_Req(int num)
    {
        //0 , 19 , 37
        //1,  2,  3
        int Length = 0;

        switch (num)
        {
            case 1:
                Length = 0;
                break;
            case 2:
                Length = 19;
                break;
            case 3:
                Length = 37;
                break;
        }
        return Length;
    }

    public void Move_Request()
    {
        int Width = FS_Item_Size / 100;
        int Height = FS_Item_Size % 10;
        short[,,] CopyPackage_FS = new short[1, 1, 1];
        short[,,] CopyPackage_LS = new short[1, 1, 1];
        switch (FSPSize)
        {
            case 86:
                CopyPackage_FS = FSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                break;
        }
        switch (LSPSize)
        {
            case 86:
                CopyPackage_LS = LSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                break;
        }
        //Checking_Only_Size_For_InCanFit_All(FS_Is_Virtical, Width, Height, LS_Slot_X, LS_Slot_Y, (int)LSPSize / 10, (int)LSPSize % 10, CopyPackage);
        if (Checking_Only_Size_For_InCanFit_All(FS_Is_Virtical, Width, Height, LS_Slot_X, LS_Slot_Y, (int)LSPSize / 10, (int)LSPSize % 10, CopyPackage_LS))
        {
            for(int i = 0; i < 5; i++)
            {
                CopyPackage_LS[i, LS_Slot_X, LS_Slot_Y] = CopyPackage_FS[i, FS_Slot_X, FS_Slot_Y];
                CopyPackage_FS[i, FS_Slot_X, FS_Slot_Y] = 0;
            }
            switch (FSPSize)
            {
                case 86:
                    FSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, 38, true);

                    break;
            }
            switch (LSPSize)
            {
                case 86:
                    LSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_LS);
                    SendServer_Inv_Info(CopyPackage_LS, 38, true);
                    break;
            }

        }


    }

    

    public bool Checking_Only_Size_For_InCanFit_All(bool IsVirtical, int First_Item_Lengthof_X, int First_Item_Lengthof_Y,
        short Last_Slot_X_order, short Last_Slot_Y_order, int X_Length_OnStorage, int Y_Length_OnStorage, short[,,] Target_Package)
    //Length = 1����, order�� 0����
    {
        bool Clear = false;

        int x = First_Item_Lengthof_X;
        int y = First_Item_Lengthof_Y;

        int sx = Last_Slot_X_order;
        int sy = Last_Slot_Y_order;

        int xl = X_Length_OnStorage;
        int yl = Y_Length_OnStorage;

        if (IsVirtical)
        {

            x = First_Item_Lengthof_Y;
            y = First_Item_Lengthof_X;

            sx = Last_Slot_X_order;
            sy = Last_Slot_Y_order;

            xl = X_Length_OnStorage;
            yl = Y_Length_OnStorage;
        }

        if (((x - 1) + sx < xl)) // ��濬��
        {
            if (((y - 1) + sy) < yl)
            {
                Clear = true;
            }
            else return Clear;
        }
        else return Clear;

        if (true)
        {
            for (int Ysecond = 0; Ysecond < y; Ysecond++)
            {
                for (int Xfirst = 0; Xfirst < x; Xfirst++)
                {
                    if (!(Target_Package[0, Last_Slot_X_order + Xfirst, Last_Slot_Y_order + Ysecond] == 0))
                    {
                        Clear = false;
                        return Clear;
                    }

                    if (FSItSelf.GetComponent<InventorySlot>().Size != 101)
                    {
                        switch (LSPSize)
                        {
                            case 86:
                                if (!LSParent.GetComponent<Inventory_8x6>().Slots[(Xfirst + Last_Slot_X_order) + 8 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                        }
                    }

                }
            }
        }


        return Clear;
    }

    //����, type, id, ���� // Ư��



    public void SendServer_Inv_Info(short[,,] Changed_Package, short Order, bool IsP)
    {
        int x = Changed_Package.GetLength(1);
        int y = Changed_Package.GetLength(2);
        int deep = Changed_Package.GetLength(0);
        for (int YLine = 0; YLine < y; YLine++)
        {
            for (int XLine = 0; XLine < x; XLine++)
            {
                if (!(Changed_Package[0, XLine, YLine] == 0))
                {
                    int location_Packet = 1000000000;
                    int Info_Packet = 10000000;

                    location_Packet += 100000000*XLine; // 1
                    location_Packet += 1000000 *YLine; // 2
                    location_Packet += 1000 * Order; // 3
                    //(1�� type / 2��, id / 3�� ���� / 4�� ���� / 5�� Ư������)

                    for (int a = 0; a < deep; a++)
                    {
                        switch (a)
                        {
                            case 0:
                                Info_Packet += (1000000*Changed_Package[a, XLine, YLine]); //type 1,1
                                break;
                            case 1:
                                Info_Packet += (1000 * Changed_Package[a, XLine, YLine]); //id 3,2
                                break;
                            case 2:
                                Info_Packet += (1 * Changed_Package[a, XLine, YLine]); //amount 4,3
                                break;
                            case 3:
                                Info_Packet += (100000*Changed_Package[a, XLine, YLine]); //dir 2,1
                                break;
                            case 4:
                                location_Packet += Changed_Package[a, XLine, YLine];
                                break;
                        }
                    }


                    CPacket InvPacket = CPacket.create((int)PROTOCOL.INV_SYNCHRONIZATION);
                    InvPacket.push(location_Packet);
                    InvPacket.push(Info_Packet);
                    CMainGame.current.Inv_Sync(InvPacket);
                }
            }
        }
    }



    private void Changed_Backpacks_Output(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        //������ ���� ������ȣ ����Ҹ� host���� ����
    }
    private void Changed_Backpacks_Input(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        // Order ���� �� ���Կ���
    }


    public void Refresh_BackpacksList(int[,] Order_And_ID)
    {
    }

    public void Refresh_Packages(int order, int BackPackID, int[,] package)
    {
    }

    public void Dragging_Item_Image_On()
    {

    }
    public void Dragging_Item_End()
    {

    }

    public void When_Drag_Success()
    {

    }
    public void Moving_Count_Add()
    {

    }
    public void Moving_Empty_Add()
    {

    }
    public void Moving_Change_Space()
    {

    }
}

