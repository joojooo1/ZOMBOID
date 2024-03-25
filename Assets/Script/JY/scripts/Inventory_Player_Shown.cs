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
    public List<short[,,]> Packages_Player;
    public List<short[,,]> Packages_Storage;// 장비, 가방에 대응하는 아이템 배열( 1면 type / 2면, id / 3면 갯수 / 4면 방향 / 5면 특수정보)
    //2칸이상의 대부분의 장비 형태들은 방향을 기준으로 옆 블럭에 추가정보를 저장
    //가방의 경우 패키지 인덱스를 저장


    //장비중인 가방을 체크함, 받아옴
    //가방의 프리펩을 가져와서 생성하고 라이브러리에서 해당 리스트를 가져옴 -a
    //프리펩에 리스트를 입혀서 표시함 (전체)-a
    //가방의 지정된 순서로 정렬함
    //정렬이 완료된 순서로 생성함(인벤프리펩, 가방 이미지)
    //완성된 프리펩을 PLAYER INVENTORY 개체의 자식으로 순서대로 생성함

    //드래그 시작지점의 배열을 분석, 가로 세로 크기와 아이템정보, 갯수,를 획득
    //드래그중 이미지를 복사해 마우스 추적
    //드래그 완료 후 도착지점의 배열을 분석, 지정 크기만큼 검증연산
    //이동 가능시 해당배열에 지정 크기만금 할당 시작 배열의 해당개체를 제거및 배열 정리
    //정리된 배열은 PLAYER의 경우 가방을 버리기전까지 갱신하지 않음
    //저장소의 경우 이동즉시 갱신함
    //시작과 도착 개체가 같은경우 최대 스텍갯수 검증 후 가능하면 겹침
    //시작과 도착 개체가 다른경우 크기를 확인후에 교체함
    //도착 개체가 비어있는경우 시작 개체 크기만큼 위치검증 후에 이동연산

    //장비시 인벤의 있던 아이템은 저장되고 사라짐
    //장비 해제시 배열을 한번 둘러보고 저장 가능 위치가 있으면 저장(?)
    //장비 해제시 바닥에 드랍함

    [SerializeField]
    GameObject User_Inventory; //좌상단 바
    [SerializeField]
    GameObject Storage_Inventory; // 우상단 바

    [SerializeField]
    GameObject Info_Box; // 세부정보 표시 창 UI
    [SerializeField]
    GameObject Drag_Target_Image; // 드래그중인 이미지

    public float Total_Weight; // ? / ?
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
        //플레이어의 장비목록을 가져옴 backpacks list에 정렬후 넣음
        for(short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
            short[,,] recieve = new short[1, 1, 1];
            recieve = Inventory_Library.IL.Getting_Package(0); // 0 은 라이브러리에서의 패키지 order
            Packages_Player.Add(recieve);
            
        }
        
        
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
        //Packages.Add(Exiest_Packages);
        
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
