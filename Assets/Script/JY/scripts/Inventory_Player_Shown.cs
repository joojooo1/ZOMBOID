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
    GameObject User_Inventory; //좌상단 바
    [SerializeField]
    GameObject Storage_Inventory; // 우상단 바
    [SerializeField]
    GameObject Info_Box; // 세부정보 표시 창 UI
    [SerializeField]
    public Transform Drag_Target_Prefeb; // v 드래그중인 이미지
    [SerializeField]
    Sprite[] Equipment_Sample_Array; // v ? ※

    [SerializeField]
    GameObject[] Equipment; // v ? ※

    public short[,,] Equipment_Package_Notbe_Synchronized; // v ? ※

    public List<short> Backpacks_List; // 장비, 가방 리스트
    public List<short> Storage_List; // 접근중인 저장소 리스트

    public List<short> Storage_Presets_List; // 초기 생성 
    public List<short[,,]> Packages_Player;
    public List<short[,,]> Packages_Storage;// 장비, 가방에 대응하는 아이템 배열( 1면 type / 2면, id / 3면 갯수 / 4면 방향 / 5면 특수정보)

    [SerializeField]
    public List<Transform> Player_Storages;
    [SerializeField]
    public List<Transform> Other_Storages;
    //                                                                              신선도,조리여부,개봉여부,크기,무게
    //2칸이상의 대부분의 장비 형태들은 방향을 기준으로 옆 블럭에 추가정보를 저장
    //가방의 경우 패키지 인덱스를 저장
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
        //초기 생성연산만
        //플레이어의 장비목록을 가져옴 backpacks list에 정렬후 넣음
        for (short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
            short[,,] recieve = new short[1, 1, 1];
            recieve = Inventory_Library.IL.Getting_Package(0); // 0 은 라이브러리에서의 패키지 order
            Packages_Player.Add(recieve);

        }

        // 장비 정의

        Equipment_Package_Notbe_Synchronized = new short[5, 18, 1]; 
        for (int Count = 0; Count < Equipment.Length; Count++)
        {
            Equipment[Count].GetComponent<InventorySlot>().Storage_Order_IfPlayer = 0;
            Equipment[Count].GetComponent<InventorySlot>().Slot_X = (short)Count;
            Equipment[Count].GetComponent<InventorySlot>().Slot_Y = 0;
            Equipment[Count].GetComponent<InventorySlot>().Item_Type = Equipment_Package_Notbe_Synchronized[0, Count, 0];
            Equipment[Count].GetComponent<InventorySlot>().Item_ID = Equipment_Package_Notbe_Synchronized[1, Count, 0];
            Equipment[Count].GetComponent<InventorySlot>().Item_Amount = Equipment_Package_Notbe_Synchronized[2, Count, 0];
            Equipment[Count].GetComponent<InventorySlot>().Equipment = true;
            Equipment[Count].GetComponent<InventorySlot>().EquipPosition = Count;
            //투,안,마 3.재킷,조끼 5.시,글,벨,신,바,다리보호구 11.다리,허리,허리,등 가방 15.외티 내티 속옷
            Equipment[Count].GetComponent<InventorySlot>().IsMain = true;
            Equipment[Count].GetComponent<InventorySlot>().ParentTransform = this.transform;
            Equipment[Count].GetComponent<InventorySlot>().ParentSize = 100;//임의로 100
            //Equipment[Count].GetComponent<InventorySlot>().Image = Equipment[Count].GetComponentInChildren<Image>().gameObject;
            //Image[] Kids = Equipment[Count].GetComponentsInChildren<Image>();
            //foreach (Image InKids in Kids)
            //{
            //    if (!InKids.gameObject == Equipment[Count].GetComponent<InventorySlot>().Image)
            //    {
            //        Equipment[Count].GetComponent<InventorySlot>().BackgroundColor = InKids.gameObject;
            //    }
            //}
            short Size = Item_DataBase.item_database.Requesting_Size(Equipment_Package_Notbe_Synchronized[0, Count, 0], Equipment_Package_Notbe_Synchronized[1, Count, 0]);
            Equipment[Count].GetComponent<InventorySlot>().Size = Size;
        }
    }

    public void SetAnim(bool open)
    {
        inven_open = open;
        Anim.SetBool("Open", inven_open);
    }

    private void Generating_Acting_Inventory(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        //백팩의 크기 가져옴
        List<GameObject> Slots = new List<GameObject>(); // 슬롯 저장
        short BackPacks_X = (short)Exiest_Packages.GetLength(1);
        short BackPacks_Y = (short)Exiest_Packages.GetLength(2);
        float Sum_Weight = 0;
        //Instantiate for(int i=0;i<XY;i++){
        //instantiate 칸들 생성
        //slots.add for each
        for (short BP_Depth = 0; BP_Depth < BackPack_Depth_Define; BP_Depth++)
        {
            //( 1면 type / 2면, id / 3면 갯수 / 4면 무게 / 5면 특수정보)
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
        switch (FSPSize) // 사이즈 조정 ※
        {
            case 100:
                break;
            case 86:
                CopyPackage_FS = FSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                break;
            case 810:
                CopyPackage_FS = FSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                break;
        }
        switch (LSPSize)
        {
            case 100:
                break;
            case 86:
                CopyPackage_LS = LSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                break;
            case 810:
                CopyPackage_LS = LSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                break;
        }

        return Checking_Only_Size_For_InCanFit_All(FS_Is_Virtical, Width, Height, LS_Slot_X, LS_Slot_Y, (int)LSPSize, CopyPackage_LS);
    }

    public void SubRequest_Drag_Image() 
    {
        Sprite Image = null;
        short Type = FSItSelf.GetComponent<InventorySlot>().Item_Type;
        short ID = FSItSelf.GetComponent<InventorySlot>().Item_ID;
        int Size = FSItSelf.GetComponent<InventorySlot>().Size;

        int Width = (int)Size / 100;
        int Height = (int)Size % 10;

        int Canvas_Width = SlotSize_Req(Width-2);
        int Canvas_Height = SlotSize_Req(Height-2);

        Image = Item_DataBase.item_database.Requesting_Image(Type, ID);


        Drag_Target_Prefeb.GetComponent<Inventry_DragImage>().Change_Image(Image, Width, Height, Canvas_Width, Canvas_Height);
    }

    private int SlotSize_Req(int num)
    {
        //0 , 19 , 37, 56
        //1,  2,  3, 4
        int Length = 0;

        switch (num)
        {
            case -1:
                Length = 0;
                break;
            case 0:
                Length = 18;
                break;
            case 1:
                Length = 18;
                break;
            case 2:
                Length = 36;
                break;
            case 3:
                Length = 56;
                break;
            case 4:
                Length = 75;
                break;
            case 5:
                Length = 93;
                break;
            case 6:
                Length = 112;
                break;
            case 7:
                Length = 130;
                break;
            case 8:
                Length = 130;
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

        if (FSPSize == 100&&LSPSize == 100)
        {
            return;
        }
        else if (LSPSize == 100) // 들어가서 return 안나옴, 크기검증 없음
        {
            //보유중 패키지 복사
            switch (FSPSize) // 스위치 조정 ※
            {
                case 100:
                    CopyPackage_FS = this.Equipment_Package_Notbe_Synchronized;
                    break;

                case 86:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                    break;

                case 810:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                    break;
            }
            switch (LSPSize)
            {
                case 100:
                    CopyPackage_LS = this.Equipment_Package_Notbe_Synchronized;
                    //장비 타입 검증 해야됨 ※
                    break;

                case 86:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                    break;

                case 810:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                    break;
            }
            //바로 패키지 이동
            for (int i = 0; i < 5; i++)
            {
                CopyPackage_LS[i, LS_Slot_X, LS_Slot_Y] = CopyPackage_FS[i, FS_Slot_X, FS_Slot_Y];
                CopyPackage_FS[i, FS_Slot_X, FS_Slot_Y] = 0;
            }
            //표시
            switch (FSPSize)
            {
                case 100:
                    Refreshing_Equipment_Slots(CopyPackage_FS);
                    break;

                case 86:
                    FSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_FS);
                    SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x6>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;

                case 810:
                    FSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_FS);
                    SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
            }
            switch (LSPSize)
            {
                case 100:
                    Refreshing_Equipment_Slots(CopyPackage_LS);
                    break;

                case 86:
                    LSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_LS);
                    SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x6>().Storage_Order, true,FS_Slot_X,FS_Slot_Y);
                    break;
                case 810:
                    LSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_LS);
                    SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
            }
            return;
        }
        //장비창과 관계없음
        else // 하위로 진행 크기검증 있음 ----------------------
        {
            //보유 패키지 복사 대입
            switch (FSPSize) // 스위치 조정 ※
            {
                case 100:
                    CopyPackage_FS = this.Equipment_Package_Notbe_Synchronized;
                    break;
                case 86:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                    break;
                case 810:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                    break;
            }
            switch (LSPSize)
            {
                case 100:
                    CopyPackage_FS = this.Equipment_Package_Notbe_Synchronized;
                    break;
                case 86:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                    break;
                case 810:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                    break;
            }
        }

        //크기 검증
        if (Checking_Only_Size_For_InCanFit_All(FS_Is_Virtical, Width, Height, LS_Slot_X, LS_Slot_Y, (int)LSPSize,CopyPackage_LS))
        {
            //바로 이동
            for (int i = 0; i < 5; i++)
            {
                CopyPackage_LS[i, LS_Slot_X, LS_Slot_Y] = CopyPackage_FS[i, FS_Slot_X, FS_Slot_Y];
                CopyPackage_FS[i, FS_Slot_X, FS_Slot_Y] = 0;
            }
            //표시
            switch (FSPSize)
            {
                case 100:
                    Refreshing_Equipment_Slots(CopyPackage_FS);
                    break;
                case 86:
                    FSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_FS);
                    SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x6>().Storage_Order, true, FS_Slot_X,FS_Slot_Y);
                    break;
                case 810:
                    FSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_FS);
                    SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
            }
            switch (LSPSize)
            {
                case 100:
                    Refreshing_Equipment_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x6>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 86:
                    LSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_LS);
                    SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x6>().Storage_Order, true,FS_Slot_X,FS_Slot_Y);
                    break;
                case 810:
                    LSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_LS);
                    SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
            }

        }


    }

    public void Refreshing_Equipment_Slots(short[,,] changedPackage)
    {
        int x = changedPackage.GetLength(1);
        int y = 1;
        int deep = changedPackage.GetLength(0);

        int YLine = 0;
        for (int XLine = 0; XLine < x; XLine++)
        {
            if (!(changedPackage[0, XLine, YLine] == 0)) // 비어있지않음
            {
                Equipment[XLine].GetComponent<InventorySlot>().Image.GetComponent<Image>().sprite = Item_DataBase.item_database.Requesting_Image(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                Equipment[XLine].GetComponent<InventorySlot>().Image.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                Equipment[XLine].GetComponent<InventorySlot>().BackgroundColor.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f); //?
                short Size = Item_DataBase.item_database.Requesting_Size(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);

                Equipment[XLine].GetComponent<InventorySlot>().Item_Type = changedPackage[0, XLine, YLine];
                Equipment[XLine].GetComponent<InventorySlot>().Item_ID = changedPackage[1, XLine, YLine];
                Equipment[XLine].GetComponent<InventorySlot>().ParentTransform = this.transform;
                Equipment[XLine].GetComponent<InventorySlot>().ParentSize = 100;
                Equipment[XLine].GetComponent<InventorySlot>().Size = Size;

                Equipment[XLine].GetComponent<InventorySlot>().What_Main = null;
                Equipment[XLine].GetComponent<InventorySlot>().IsMain = true;

                //Equipment[XLine].GetComponent<InventorySlot>().Is_Changed--;
            }
            else // 빔
            {
                Equipment[XLine].GetComponent<InventorySlot>().Image.GetComponent<Image>().sprite = Equipment_Sample_Array[XLine];
                Equipment[XLine].GetComponent<InventorySlot>().BackgroundColor.GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f); // ?
                Equipment[XLine].GetComponent<InventorySlot>().Item_Type = 0;
                Equipment[XLine].GetComponent<InventorySlot>().Item_ID = 0;

                Equipment[XLine].GetComponent<InventorySlot>().ParentTransform = this.transform;
                Equipment[XLine].GetComponent<InventorySlot>().ParentSize = 100;
                //short SizeOfItem = Item_DataBase.item_database.Requesting_Size(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                //Equipment[XLine].GetComponent<InventorySlot>().Size = SizeOfItem;
            }
        }



       Equipment_Package_Notbe_Synchronized = changedPackage;
    }

    public bool Checking_Only_Size_For_InCanFit_All(bool IsVirtical, int First_Item_Lengthof_X, int First_Item_Lengthof_Y,
        short Last_Slot_X_order, short Last_Slot_Y_order, int LSPSize, short[,,] Target_Package)
    //Length = 1부터, order는 0부터
    {
        
        bool Clear = false;
        if (LSPSize == 100)
        {
            // 장비 검증연산 해야됨
            Clear = true;
            return Clear;
        }
        int x = First_Item_Lengthof_X;
        int y = First_Item_Lengthof_Y;

        int sx = Last_Slot_X_order;
        int sy = Last_Slot_Y_order;

        int xl = 0;
        int yl = 0;
        switch (LSPSize)
        {
            case 86:
                xl = 8;
                yl = 6;
                break;
            case 810:
                xl = 8;
                yl = 10;
                break;
        }


        if (IsVirtical)
        {

            x = First_Item_Lengthof_Y;
            y = First_Item_Lengthof_X;

            sx = Last_Slot_X_order;
            sy = Last_Slot_Y_order;

            int dump = 0;
            dump = yl;
            xl = yl;
            yl = dump;
        }

        if (((x - 1) + sx < xl)) // 배경연산
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
                            case 810:
                                if(!LSParent.GetComponent<Inventory_8x10>().Slots[(Xfirst + Last_Slot_X_order) + 8 * (Ysecond + Last_Slot_Y_order)].IsMain)
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

    //방향, type, id, 갯수 // 특정



    public void SendServer_Inv_Info(short[,,] After_Package, short Order, bool IsP, short Before_X, short Before_Y)
    {
        int x = After_Package.GetLength(1);
        int y = After_Package.GetLength(2);
        int deep = After_Package.GetLength(0);
        for (int YLine = 0; YLine < y; YLine++)
        {
            for (int XLine = 0; XLine < x; XLine++)
            {
                if (!(After_Package[0, XLine, YLine] == 0))
                {
                    int location_Packet = 1000000000;
                    int Info_Packet = 10000000;
                    int Before_Location = 1000;

                    location_Packet += 100000000 * XLine; // 1
                    location_Packet += 1000000 * YLine; // 2
                    location_Packet += 1000 * Order; // 3
                    //(1면 type / 2면, id / 3면 갯수 / 4면 방향 / 5면 특수정보)

                    Before_Location += Before_X * 100;
                    Before_Location += Before_Y;

                    for (int a = 0; a < deep; a++)
                    {
                        switch (a)
                        {
                            case 0:
                                Info_Packet += (1000000 * After_Package[a, XLine, YLine]); //type 1,1
                                break;
                            case 1:
                                Info_Packet += (1000 * After_Package[a, XLine, YLine]); //id 3,2
                                break;
                            case 2:
                                Info_Packet += (1 * After_Package[a, XLine, YLine]); //amount 4,3
                                break;
                            case 3:
                                Info_Packet += (100000 * After_Package[a, XLine, YLine]); //dir 2,1
                                break;
                            case 4:
                                location_Packet += After_Package[a, XLine, YLine];
                                break;
                        }
                    }


                    CPacket InvPacket = CPacket.create((int)PROTOCOL.INV_SYNCHRONIZATION);
                    InvPacket.push(location_Packet);
                    InvPacket.push(Info_Packet);
                    InvPacket.push(Before_Location);
                    CMainGame.current.Inv_Sync(InvPacket);
                }
            }
        }
    }



    private void Changed_Backpacks_Output(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        //가방의 정보 고유번호 저장소를 host에게 저장
    }
    private void Changed_Backpacks_Input(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        // Order 정렬 후 대입연산
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

