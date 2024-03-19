using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;

public class Inventory_Player_Shown : MonoBehaviour
{
    public static Inventory_Player_Shown InvPS;
    public enum Storage_Type
    {
        Hand = 0,
        Hipsak = 1,
        SmallBag =2,
    }

    public List<short> Backpacks_List; // 장비, 가방 리스트
    public List<short> Storage_List; // 접근중인 저장소 리스트

    public List<short> Storage_Presets_List; // 초기 생성 
    public List<short[,,]> Packages; // 장비, 가방에 대응하는 아이템 배열( 1면 type / 2면, id / 3면 갯수 / 4면 방향 / 5면 특수정보)
    //2칸이상의 대부분의 장비 형태들은 방향을 기준으로 옆 블럭에 추가정보를 저장
    //가방의 경우 패키지 인덱스를 저장

    [SerializeField]
    GameObject User_Inventory;
    [SerializeField]
    GameObject Storage_Inventory;

    [SerializeField]
    GameObject Info_Box;
    [SerializeField]
    GameObject Drag_Target_Image;

    public float Total_Weight;
    short BackPack_Depth_Define = 5;

    public short FS_Slot_X;
    public short FS_Slot_Y;
    public short FS_Slot_Order;
    public bool FS_Is_Player;
    public bool FS_Is_Virtical;

    public short LS_Slot_X;
    public short LS_Slot_Y;
    public short LS_Slot_Order;
    public bool LS_Is_Player;

    private void Awake()
    {
        InvPS = this;
    }
    private void Start()
    {
        //플레이어의 장비목록을 가져옴
        for(short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
        }

        //Generagting_Visual_Area();
    }

    //플레이어 장비

    //가방 리스트
    //소지품 리스트

    //가방 배열

    //ID로 데이터베이스 크기참조, 초기생성, 순서 , 슬롯의 갱신 포함
    private void First_Generating_Presets_of_Storage_Type(short Storage_Type)
    {

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

            foreach(GameObject slotsEach in Slots)
            {
                //slotsEach.GetComponent<InventorySlot>().Refresh_This_Slot;
                //Sum_Weight += slotsEach.GetComponent<InventorySlot>().Weight;
            }
        }


        Backpacks_List.Add(Backpack_ID);
        Packages.Add(Exiest_Packages);
        
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

    public void Refresh_Packages(int order,int BackPackID, int[,] package)
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
