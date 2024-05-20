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

    public Transform PlayerBackPacks_Shown; // 가방에 할당된 아이콘이 보이는곳
    public Transform Non_PlayerBackPacks_Shown; // 서브

    public GameObject[] PBP_S_Ordering_Array; // 아이콘 순서 정리 배열

    public Transform Out_Location; // 공유

    public Transform The_Basic_BPIcon_NeverMove;
    public Transform The_Basic_TileIcon_NeverMove; //서브

    public GameObject BackPack_Public_Prefeb; // v
    [SerializeField]
    GameObject[] Inventory_Form_Prefebs; // 공유

    public Transform Inventory_Form_Location; // 인벤 프리펩 생성위치
    public Transform Inventory_Form_Location_ForStorage; //서브
    public Transform Tile_Basic_Format_Never_Delete;

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
    Animator SubAnim;
    public GameObject Storage_s;
    public bool inven_open; // v

    //Crafting 연동
    public List<short[]> CraftingResources;

    [SerializeField]
    public Sprite[] Icons;
    public Item_Weapons NowWeapon; // 착용 무기정보



    private void Awake()
    {
        InvPS = this;
        Anim = GetComponent<Animator>();
        SubAnim = Storage_s.GetComponent<Animator>();
        inven_open = false;
    }


    private void Start()
    {
        CraftingResources = new List<short[]>();
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
            //0.투,안,마 3.재킷,조끼 5.시,글,벨,신,바,다리보호구 11.다리,허리,허리,등 가방 15.외티 내티 속옷
            Equipment[Count].GetComponent<InventorySlot>().IsMain = true;
            Equipment[Count].GetComponent<InventorySlot>().ParentTransform = this.transform;
            Equipment[Count].GetComponent<InventorySlot>().ParentSize = 100;//임의로 100
            //Equipment[Count].GetComponent<InventorySlot>().Image = Equipment[Count].GetComponentInChildren<Image>().gameObject;
            int Num = 0;
            foreach (Image Kids in Equipment[Count].GetComponentsInChildren<Image>())
            {

                if (Num == 1)
                {
                    Equipment[Count].GetComponent<InventorySlot>().BackgroundColor = Kids.transform.gameObject;
                }
                if (Num == 2)
                {
                    Equipment[Count].GetComponent<InventorySlot>().Image = Kids.transform.gameObject;
                }

                Num++;
                if (Num > 2)
                {
                    break;
                }
            }

            short Size = Item_DataBase.item_database.Requesting_Size(Equipment_Package_Notbe_Synchronized[0, Count, 0], Equipment_Package_Notbe_Synchronized[1, Count, 0]);
            Equipment[Count].GetComponent<InventorySlot>().Size = Size;


        }
        // 0424 1차 라이브러리 테스팅 ============================================================================================
        Inventory_Form_Location.gameObject.GetComponentInChildren<Inventory_8x6>().Generating_Slots_First(Inventory_Library.IL.Inventory_DB[1], 1);
        //0426 초기 가방 테스팅=================================================
        Equipment_Package_Notbe_Synchronized[0, 14, 0] = 8;
        Equipment_Package_Notbe_Synchronized[4, 14, 0] = 2;
        Refreshing_Equipment_Slots(Equipment_Package_Notbe_Synchronized);

        Resetting_BPICons_Order();
        //======================================================================


    }

    public void SetAnim(bool open)
    {
        inven_open = open;
        Anim.SetBool("Open", inven_open);
        SubAnim.SetBool("Open", inven_open);
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

    public void Resetting_BPICons_Order()
    {
        List<GameObject> Bag_Icons = new List<GameObject>();
        foreach (Toggle Kids in PlayerBackPacks_Shown.GetComponentsInChildren<Toggle>())
        {
            Bag_Icons.Add(Kids.transform.gameObject);
        }
        PBP_S_Ordering_Array = Bag_Icons.ToArray();
        short Dumy_Num = 0;
        foreach (GameObject Objects in PBP_S_Ordering_Array)
        {
            Objects.GetComponent<BPIcon_SimpleAct>().Its_Own_Order = Dumy_Num;
            Dumy_Num++;
            if (Objects.transform == The_Basic_BPIcon_NeverMove)
            {
                Objects.GetComponent<BPIcon_SimpleAct>().IsBasic = true;
            }
        }
    }

    public void When_Selected_BPIcons(short Its_Own_Order)
    {
        foreach (GameObject Bag_Icons in PBP_S_Ordering_Array)
        {
            if (Bag_Icons.GetComponent<BPIcon_SimpleAct>().Its_Own_Order != Its_Own_Order) // 다르면 outl로 이동
            {
                Bag_Icons.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Out_Location);
                Bag_Icons.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.localPosition = new Vector3(0, 0, 0);
            }
            else
            {
                Bag_Icons.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Inventory_Form_Location);
                foreach (GameObject BPNotIcons in Inventory_Form_Location)
                {
                    BPNotIcons.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }

    public void Return_Basic_BPIcons()
    {
        foreach (GameObject Kids in PBP_S_Ordering_Array)
        {
            Kids.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Out_Location);
            Kids.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.localPosition = new Vector3(0, 0, 0);
            Kids.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Inventory_Form_Location);
        }
    }

    public void S_When_Selected_BPIcons(short Its_Own_Order)
    {
        foreach (GameObject Bag_Icons in PBP_S_Ordering_Array)
        {
            if (Bag_Icons.GetComponent<BPIcon_SimpleAct>().Its_Own_Order != Its_Own_Order) // 다르면 outl로 이동
            {
                Bag_Icons.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Out_Location);
                Bag_Icons.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.localPosition = new Vector3(0, 0, 0);
            }
            else
            {
                Bag_Icons.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Inventory_Form_Location);
                foreach (GameObject BPNotIcons in Inventory_Form_Location)
                {
                    BPNotIcons.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }

    public void S_Return_Basic_BPIcons()
    {
        foreach (GameObject Kids in PBP_S_Ordering_Array)
        {
            Kids.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Out_Location);
            Kids.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.localPosition = new Vector3(0, 0, 0);
            Kids.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.SetParent(Inventory_Form_Location);
        }
    }

    public void Storage_Contact_Refresh(short Storage_Order_HaveToChange, int Unchangeable_Size, bool On_Off)
    {
        if (On_Off)
        {
            int BP_RealSize = Unchangeable_Size;
            switch (BP_RealSize)
            {
                case 8140:

                    
                        Tile_Basic_Format_Never_Delete.GetComponent<Inventory_8x14>().Refreshing_Changed_Slots(Inventory_Library.IL.Getting_Package(Storage_Order_HaveToChange));
                        Tile_Basic_Format_Never_Delete.GetComponent<Inventory_8x14>().Slot_Image.GetComponent<Image>().sprite = Tile_Basic_Format_Never_Delete.GetComponent<Inventory_8x14>().GroundImage_Only_For8x14;
                        Tile_Basic_Format_Never_Delete.GetComponent<Inventory_8x14>().Storage_Order = Storage_Order_HaveToChange;

                        Inventory_Library.IL.Resetting_Package(Storage_Order_HaveToChange, Tile_Basic_Format_Never_Delete.GetComponent<Inventory_8x14>().Recent_Recieved_Package);

                    

                    break;

            }

        }
    }

    public bool Drag_Check_Only()
    {
        int Width = FS_Item_Size / 100;
        int Height = FS_Item_Size % 100;
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
            case 812:
                CopyPackage_FS = FSParent.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                break;
            case 24:
                CopyPackage_FS = FSParent.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                break;
            case 610:
                CopyPackage_FS = FSParent.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                break;
            case 44:
                CopyPackage_FS = FSParent.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                break;
            case 43:
                CopyPackage_FS = FSParent.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                break;
            case 814:
                CopyPackage_FS = FSParent.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
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
            case 812:
                CopyPackage_LS = LSParent.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                break;
            case 24:
                CopyPackage_LS = LSParent.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                break;
            case 610:
                CopyPackage_LS = LSParent.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                break;
            case 44:
                CopyPackage_LS = LSParent.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                break;
            case 43:
                CopyPackage_LS = LSParent.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                break;
            case 814:
                CopyPackage_LS = LSParent.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
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

        int Canvas_Width = SlotSize_Req(Width - 2);
        int Canvas_Height = SlotSize_Req(Height - 2);

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
        int Height = FS_Item_Size % 100;
        short[,,] CopyPackage_FS = new short[1, 1, 1];
        short[,,] CopyPackage_LS = new short[1, 1, 1];

        if (FSItSelf.GetComponent<InventorySlot>().This_Own_Form_IFDE_D != null) // 자기 안에 가방 금지
        {
            if (FSItSelf.GetComponent<InventorySlot>().This_Own_Form_IFDE_D == LSParent)
            {
                return;
            }
        }

        if (FSPSize == 100 && LSPSize == 100)
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
                case 812:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                    break;
                case 24:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                    break;
                case 610:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                    break;
                case 44:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                    break;
                case 43:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                    break;
                case 814:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
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
                case 812:
                    CopyPackage_LS = FSParent.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                    break;
                case 24:
                    CopyPackage_LS = FSParent.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                    break;
                case 610:
                    CopyPackage_LS = FSParent.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                    break;
                case 44:
                    CopyPackage_LS = FSParent.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                    break;
                case 43:
                    CopyPackage_LS = FSParent.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                    break;
                case 814:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
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
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x6>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 810:
                    FSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 812:
                    FSParent.GetComponent<Inventory_8x12>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x12>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 24:
                    FSParent.GetComponent<Inventory_2x4>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_2x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 610:
                    FSParent.GetComponent<Inventory_6x10>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_6x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 44:
                    FSParent.GetComponent<Inventory_4x4>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_4x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 43:
                    FSParent.GetComponent<Inventory_4x3>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_4x3>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 814:
                    FSParent.GetComponent<Inventory_8x14>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x14>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
            }
            switch (LSPSize)
            {
                case 100:
                    Refreshing_Equipment_Slots(CopyPackage_LS);
                    break;
                case 86:
                    LSParent.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x6>().Storage_Order, true,FS_Slot_X,FS_Slot_Y);
                    break;
                case 810:
                    LSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 812:
                    LSParent.GetComponent<Inventory_8x12>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x12>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 24:
                    LSParent.GetComponent<Inventory_2x4>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_2x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 610:
                    LSParent.GetComponent<Inventory_6x10>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_6x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 44:
                    LSParent.GetComponent<Inventory_4x4>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_4x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 43:
                    LSParent.GetComponent<Inventory_4x3>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_4x3>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 814:
                    LSParent.GetComponent<Inventory_8x14>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x14>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
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
                case 812:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                    break;
                case 24:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                    break;
                case 610:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                    break;
                case 44:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                    break;
                case 43:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                    break;
                case 814:
                    CopyPackage_FS = FSParent.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
                    break;
            }
            switch (LSPSize)
            {
                case 100:
                    CopyPackage_LS = this.Equipment_Package_Notbe_Synchronized;
                    break;
                case 86:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                    break;
                case 810:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                    break;
                case 812:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                    break;
                case 24:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                    break;
                case 610:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                    break;
                case 44:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                    break;
                case 43:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                    break;
                case 814:
                    CopyPackage_LS = LSParent.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
                    break;
            }
        }

        //크기 검증
        if (Checking_Only_Size_For_InCanFit_All(FS_Is_Virtical, Width, Height, LS_Slot_X, LS_Slot_Y, (int)LSPSize, CopyPackage_LS))
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
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x6>().Storage_Order, true, FS_Slot_X,FS_Slot_Y);
                    break;
                case 810:
                    FSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 812:
                    FSParent.GetComponent<Inventory_8x12>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x12>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 24:
                    FSParent.GetComponent<Inventory_2x4>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_2x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 610:
                    FSParent.GetComponent<Inventory_6x10>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_6x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 44:
                    FSParent.GetComponent<Inventory_4x4>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_4x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 43:
                    FSParent.GetComponent<Inventory_4x3>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_4x3>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 814:
                    FSParent.GetComponent<Inventory_8x14>().Refreshing_Changed_Slots(CopyPackage_FS);
                    //SendServer_Inv_Info(CopyPackage_FS, FSParent.GetComponent<Inventory_8x14>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
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
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x6>().Storage_Order, true,FS_Slot_X,FS_Slot_Y);
                    break;
                case 810:
                    LSParent.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 812:
                    LSParent.GetComponent<Inventory_8x12>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x12>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 24:
                    LSParent.GetComponent<Inventory_2x4>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_2x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 610:
                    LSParent.GetComponent<Inventory_6x10>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_6x10>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 44:
                    LSParent.GetComponent<Inventory_4x4>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_4x4>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 43:
                    LSParent.GetComponent<Inventory_4x3>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_4x3>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
                    break;
                case 814:
                    LSParent.GetComponent<Inventory_8x14>().Refreshing_Changed_Slots(CopyPackage_LS);
                    //SendServer_Inv_Info(CopyPackage_LS, LSParent.GetComponent<Inventory_8x14>().Storage_Order, true, FS_Slot_X, FS_Slot_Y);
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
                if (XLine > 10 && XLine < 15)// 11,12,13,14 가방라인
                {
                    if (Equipment[XLine].GetComponent<InventorySlot>().IsShown_OnPlayer == false)
                    {
                        Equipment[XLine].GetComponent<InventorySlot>().BP_Array_Num_Starting0 = XLine;
                        GameObject New_BP_Image = Instantiate(BackPack_Public_Prefeb, new Vector3(0f, 0f, 0f), Quaternion.identity);
                        Equipment[XLine].GetComponent<InventorySlot>().This_Own_Image_IfDoesntExiest_Delete = New_BP_Image.transform;
                        New_BP_Image.transform.SetParent(PlayerBackPacks_Shown);


                        //prefeb.transform.localScale = Vector3.one;

                        New_BP_Image.GetComponent<Image>().sprite = Item_DataBase.item_database.Requesting_Image(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                        New_BP_Image.GetComponent<Toggle>().group = PlayerBackPacks_Shown.GetComponent<ToggleGroup>();
                        New_BP_Image.GetComponent<BPIcon_SimpleAct>().IsPlayer = true;
                        RectTransform canvasRectTransform = New_BP_Image.GetComponent<RectTransform>();
                        canvasRectTransform.anchorMin = new Vector2(0f, 1f);
                        canvasRectTransform.anchorMax = new Vector2(0f, 1f);
                        canvasRectTransform.localPosition = Vector3.zero;
                        canvasRectTransform.localScale = new Vector3(0.8f, 0.8f, 1);

                        int BP_RealSize = Item_DataBase.item_database.Requesting_Size(changedPackage[0, XLine, YLine], changedPackage[1, XLine, YLine]);
                        switch (BP_RealSize)
                        {
                            case 405:
                                GameObject New_Bp_Tabs = Instantiate(Inventory_Form_Prefebs[5], new Vector3(0f, 0f, 0f), Quaternion.identity);
                                Equipment[XLine].GetComponent<InventorySlot>().This_Own_Form_IFDE_D = New_Bp_Tabs.transform;
                                New_Bp_Tabs.transform.SetParent(Inventory_Form_Location);
                                RectTransform Bp_Rect = New_Bp_Tabs.GetComponent<RectTransform>();
                                Bp_Rect.anchorMin = new Vector2(0f, 1f);
                                Bp_Rect.anchorMax = new Vector2(0f, 1f);
                                Bp_Rect.localPosition = Vector3.zero;
                                Bp_Rect.localScale = new Vector3(1, 1, 1);
                                //0426
                                New_BP_Image.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation = New_Bp_Tabs.transform;

                                New_Bp_Tabs.GetComponent<Inventory_8x10>().Generating_Slots_First(Inventory_Library.IL.Inventory_DB[Equipment_Package_Notbe_Synchronized[4, XLine, 0]], Equipment_Package_Notbe_Synchronized[4, XLine, 0]);
                                break;
                            case 202:
                                GameObject New_Bp_Tabs1 = Instantiate(Inventory_Form_Prefebs[2], new Vector3(0f, 0f, 0f), Quaternion.identity);
                                Equipment[XLine].GetComponent<InventorySlot>().This_Own_Form_IFDE_D = New_Bp_Tabs1.transform;
                                New_Bp_Tabs1.transform.SetParent(Inventory_Form_Location);
                                RectTransform Bp_Rect1 = New_Bp_Tabs1.GetComponent<RectTransform>();
                                Bp_Rect1.anchorMin = new Vector2(0f, 1f);
                                Bp_Rect1.anchorMax = new Vector2(0f, 1f);
                                Bp_Rect1.localPosition = Vector3.zero;
                                Bp_Rect1.localScale = new Vector3(1, 1, 1);
                                //0426
                                New_BP_Image.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation = New_Bp_Tabs1.transform;

                                New_Bp_Tabs1.GetComponent<Inventory_8x10>().Generating_Slots_First(Inventory_Library.IL.Inventory_DB[Equipment_Package_Notbe_Synchronized[4, XLine, 0]], Equipment_Package_Notbe_Synchronized[4, XLine, 0]);
                                break;
                        }

                    }
                }
                //Equipment[XLine].GetComponent<InventorySlot>().Is_Changed--;
            }
            else // 빔
            {
                if (XLine > 10 && XLine < 15 && !(Equipment[XLine].GetComponent<InventorySlot>().This_Own_Image_IfDoesntExiest_Delete == null))// 11,12,13,14 가방라인
                {
                    Destroy(Equipment[XLine].GetComponent<InventorySlot>().This_Own_Image_IfDoesntExiest_Delete.gameObject);
                    Equipment[XLine].GetComponent<InventorySlot>().This_Own_Image_IfDoesntExiest_Delete = null;
                    Equipment[XLine].GetComponent<InventorySlot>().BP_Array_Num_Starting0 = 500;
                    Equipment[XLine].GetComponent<InventorySlot>().IsShown_OnPlayer = false;

                    switch (Equipment[XLine].GetComponent<InventorySlot>().Size * 2) // 확인필요 사라지지않음.
                    {
                        case 810:
                            Inventory_Library.IL.Inventory_DB[Equipment[XLine].GetComponent<InventorySlot>().This_Own_Form_IFDE_D.gameObject.GetComponent<Inventory_8x10>().Storage_Order] = Equipment[XLine].GetComponent<InventorySlot>().This_Own_Form_IFDE_D.gameObject.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                            break;
                    }
                    Destroy(Equipment[XLine].GetComponent<InventorySlot>().This_Own_Form_IFDE_D.gameObject);
                    Equipment[XLine].GetComponent<InventorySlot>().This_Own_Form_IFDE_D = null;
                }
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

    public void Storage_Contract(Transform Located_Tile, short Contacted_LB_Num, bool On_Off)
    {
        if (On_Off)
        {
            GameObject New_Storage_Image = Instantiate(BackPack_Public_Prefeb, new Vector3(0f, 0f, 0f), Quaternion.identity);
            //New_BP_Image.GetComponent<Image>().sprite 아이콘 이미지 변경
            New_Storage_Image.transform.SetParent(Non_PlayerBackPacks_Shown);
            New_Storage_Image.GetComponent<Toggle>().group = Non_PlayerBackPacks_Shown.GetComponent<ToggleGroup>();
            RectTransform Stroage_canvasRectTransform = New_Storage_Image.GetComponent<RectTransform>();

            Stroage_canvasRectTransform.anchorMin = new Vector2(0f, 1f);
            Stroage_canvasRectTransform.anchorMax = new Vector2(0f, 1f);
            Stroage_canvasRectTransform.localPosition = Vector3.zero;
            Stroage_canvasRectTransform.localScale = new Vector3(0.8f, 0.8f, 1);


            //하위 저장소별 크기변경 할당 라이브러리 번호 할당
            GameObject New_Storage_Tabs = Instantiate(Inventory_Form_Prefebs[7], new Vector3(0f, 0f, 0f), Quaternion.identity);
            //저장소창 이미지 변경

            New_Storage_Tabs.GetComponent<Inventory_8x14>().Storage_Order = Contacted_LB_Num;


            New_Storage_Tabs.transform.SetParent(Inventory_Form_Location_ForStorage);
            RectTransform Storage_Rect = New_Storage_Tabs.GetComponent<RectTransform>();
            Storage_Rect.anchorMin = new Vector2(0f, 1f);
            Storage_Rect.anchorMax = new Vector2(0f, 1f);
            Storage_Rect.localPosition = Vector3.zero;
            Storage_Rect.localScale = new Vector3(1, 1, 1);

            New_Storage_Image.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation = New_Storage_Tabs.transform;

            New_Storage_Tabs.GetComponent<Inventory_8x14>().Generating_Slots_First(Inventory_Library.IL.Inventory_DB[Contacted_LB_Num], Contacted_LB_Num);
        }
        else
        {
            foreach (BPIcon_SimpleAct Storage_Images in Non_PlayerBackPacks_Shown.GetComponentsInChildren<BPIcon_SimpleAct>())
            {
                if (Storage_Images.IsBasic == false)//기본저장소 아님
                {
                    Destroy((Storage_Images.Reverse_Lovation.gameObject));
                    Destroy(Storage_Images.gameObject);
                }
            }
        }
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
            case 812:
                xl = 8;
                yl = 12;
                break;
            case 24:
                xl = 4;
                yl = 2;
                break;
            case 610:
                xl = 6;
                yl = 10;
                break;
            case 44:
                xl = 4;
                yl = 4;
                break;
            case 43:
                xl = 4;
                yl = 3;
                break;
            case 814:
                xl = 8;
                yl = 14;
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

        if (FSItSelf.GetComponent<InventorySlot>().This_Own_Form_IFDE_D != null) // 자기 안에 가방 금지
        {
            if (FSItSelf.GetComponent<InventorySlot>().This_Own_Form_IFDE_D == LSParent)
            {
                Clear = false;
                return Clear;
            }
        }

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
                                if (!LSParent.GetComponent<Inventory_8x10>().Slots[(Xfirst + Last_Slot_X_order) + 8 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                            case 812:
                                if (!LSParent.GetComponent<Inventory_8x12>().Slots[(Xfirst + Last_Slot_X_order) + 8 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                            case 24:
                                if (!LSParent.GetComponent<Inventory_2x4>().Slots[(Xfirst + Last_Slot_X_order) + 4 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                            case 610:
                                if (!LSParent.GetComponent<Inventory_6x10>().Slots[(Xfirst + Last_Slot_X_order) + 6 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                            case 44:
                                if (!LSParent.GetComponent<Inventory_4x4>().Slots[(Xfirst + Last_Slot_X_order) + 4 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                            case 43:
                                if (!LSParent.GetComponent<Inventory_4x3>().Slots[(Xfirst + Last_Slot_X_order) + 4 * (Ysecond + Last_Slot_Y_order)].IsMain)
                                {
                                    Clear = false;
                                    return Clear;
                                }
                                break;
                            case 814:
                                if (!LSParent.GetComponent<Inventory_8x14>().Slots[(Xfirst + Last_Slot_X_order) + 8 * (Ysecond + Last_Slot_Y_order)].IsMain)
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

    public void Clearing_Ready_Crafting() // crafting below
    {
        CraftingResources = new List<short[]>();
    }

    public void Crafting_Resources(short Type, short ID, short Amount)
    {
        short[] New_Resource_T_ID_Am = { Type, ID, Amount };
        CraftingResources.Add(New_Resource_T_ID_Am);
    }

    public bool Searching_Crafting_Resources(short[] Find_It) // 순환 저장소 고려않음
    {
        bool Cleared = false;
        foreach(Toggle obj in PlayerBackPacks_Shown.GetComponentsInChildren<Toggle>())
        {
            short Player_InvWindow_Size = obj.gameObject.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.gameObject.GetComponentInChildren<InventorySlot>().ParentSize;
            Transform Player_InvWindow = obj.gameObject.GetComponent<BPIcon_SimpleAct>().Reverse_Lovation.gameObject.GetComponentInChildren<InventorySlot>().ParentTransform;

            short[,,] Target_Package = new short[1, 1, 1];
            short Target_Package_Num = 0;
            switch (Player_InvWindow_Size)
            {
                case 100:
                    break;
                case 86:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_8x6>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_8x6>().Storage_Order;
                    break;
                case 810:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_8x10>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_8x10>().Storage_Order;
                    break;
                case 812:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_8x12>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_8x12>().Storage_Order;
                    break;
                case 24:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_2x4>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_2x4>().Storage_Order;
                    break;
                case 610:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_6x10>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_6x10>().Storage_Order;
                    break;
                case 44:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_4x4>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_4x4>().Storage_Order;
                    break;
                case 43:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_4x3>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_4x3>().Storage_Order;
                    break;
                case 814:
                    Target_Package = Player_InvWindow.GetComponent<Inventory_8x14>().Recent_Recieved_Package;
                    Target_Package_Num = Player_InvWindow.GetComponent<Inventory_8x14>().Storage_Order;
                    break;
            }
            for(int y = 0; y < Target_Package.GetLength(1); y++)
            {
                for(int x=0; x < Target_Package.GetLength(2); x++)
                {
                    if (Target_Package[0, y, x] == Find_It[0]&&Target_Package[1,y,x]==Find_It[1]&&Target_Package[2,y,x]>=Find_It[2])
                    {
                        Target_Package[2,y,x] -= Find_It[2];

                        Cleared = true;
                        goto Is_Right;
                    }
                }
            }
        Is_Right:;
            if (Cleared == true)
            {
                switch (Player_InvWindow_Size)
                {
                    case 100:
                        break;
                    case 86:
                        Player_InvWindow.GetComponent<Inventory_8x6>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 810:
                        Player_InvWindow.GetComponent<Inventory_8x10>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 812:
                        Player_InvWindow.GetComponent<Inventory_8x12>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 24:
                        Player_InvWindow.GetComponent<Inventory_2x4>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 610:
                        Player_InvWindow.GetComponent<Inventory_6x10>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 44:
                        Player_InvWindow.GetComponent<Inventory_4x4>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 43:
                        Player_InvWindow.GetComponent<Inventory_4x3>().Refreshing_Changed_Slots(Target_Package);
                        break;
                    case 814:
                        Player_InvWindow.GetComponent<Inventory_8x14>().Refreshing_Changed_Slots(Target_Package);
                        break;
                }
            }
            return Cleared;
            //? library 동기화 ?
        }
        return Cleared;
    }

    public bool Checking_Crafting_Canbe()
    {
        bool All_Cleared = false;
        int Goal = CraftingResources.Count;
        int Count = 0;
        foreach(short[] acts in CraftingResources)
        {
            if (Searching_Crafting_Resources(acts))
            {
                Count++;
            }
        }
        if (Count == Goal)
        {
            All_Cleared = true;
        }


        return All_Cleared;
    }



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


}

