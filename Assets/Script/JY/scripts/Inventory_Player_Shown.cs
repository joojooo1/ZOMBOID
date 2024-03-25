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

    public List<short> Backpacks_List; // ���, ���� ����Ʈ
    public List<short> Storage_List; // �������� ����� ����Ʈ

    public List<short> Storage_Presets_List; // �ʱ� ���� 
    public List<short[,,]> Packages_Player;
    public List<short[,,]> Packages_Storage;// ���, ���濡 �����ϴ� ������ �迭( 1�� type / 2��, id / 3�� ���� / 4�� ���� / 5�� Ư������)
    //2ĭ�̻��� ��κ��� ��� ���µ��� ������ �������� �� ���� �߰������� ����
    //������ ��� ��Ű�� �ε����� ����


    //������� ������ üũ��, �޾ƿ�
    //������ �������� �����ͼ� �����ϰ� ���̺귯������ �ش� ����Ʈ�� ������ -a
    //�����鿡 ����Ʈ�� ������ ǥ���� (��ü)-a
    //������ ������ ������ ������
    //������ �Ϸ�� ������ ������(�κ�������, ���� �̹���)
    //�ϼ��� �������� PLAYER INVENTORY ��ü�� �ڽ����� ������� ������

    //�巡�� ���������� �迭�� �м�, ���� ���� ũ��� ����������, ����,�� ȹ��
    //�巡���� �̹����� ������ ���콺 ����
    //�巡�� �Ϸ� �� ���������� �迭�� �м�, ���� ũ�⸸ŭ ��������
    //�̵� ���ɽ� �ش�迭�� ���� ũ�⸸�� �Ҵ� ���� �迭�� �ش簳ü�� ���Ź� �迭 ����
    //������ �迭�� PLAYER�� ��� ������ ������������ �������� ����
    //������� ��� �̵���� ������
    //���۰� ���� ��ü�� ������� �ִ� ���ذ��� ���� �� �����ϸ� ��ħ
    //���۰� ���� ��ü�� �ٸ���� ũ�⸦ Ȯ���Ŀ� ��ü��
    //���� ��ü�� ����ִ°�� ���� ��ü ũ�⸸ŭ ��ġ���� �Ŀ� �̵�����

    //���� �κ��� �ִ� �������� ����ǰ� �����
    //��� ������ �迭�� �ѹ� �ѷ����� ���� ���� ��ġ�� ������ ����(?)
    //��� ������ �ٴڿ� �����

    [SerializeField]
    GameObject User_Inventory; //�»�� ��
    [SerializeField]
    GameObject Storage_Inventory; // ���� ��

    [SerializeField]
    GameObject Info_Box; // �������� ǥ�� â UI
    [SerializeField]
    GameObject Drag_Target_Image; // �巡������ �̹���

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
        //�÷��̾��� ������� ������ backpacks list�� ������ ����
        for(short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
            short[,,] recieve = new short[1, 1, 1];
            recieve = Inventory_Library.IL.Getting_Package(0); // 0 �� ���̺귯�������� ��Ű�� order
            Packages_Player.Add(recieve);
            
        }
        
        
    }

    //�÷��̾� ���

    //���� ����Ʈ
    //����ǰ ����Ʈ

    //���� �迭

    //ID�� �����ͺ��̽� ũ������, �ʱ����, ���� , ������ ���� ����
    private void First_Generating_Presets_of_Storage_Type(short Storage_Type)
    {

    }

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
        //������ ���� ������ȣ ����Ҹ� host���� ����
    }
    private void Changed_Backpacks_Input(short Backpack_ID, short[,,] Exiest_Packages, short Order)
    {
        // Order ���� �� ���Կ���
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
