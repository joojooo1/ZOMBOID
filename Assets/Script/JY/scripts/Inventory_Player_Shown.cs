using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Player_Shown : MonoBehaviour
{
    public enum Storage_Type
    {
        Hand = 0,
        Hipsak = 1,
        SmallBag =2,

    }

    public List<short> Backpacks_List; // ���, ���� ����Ʈ
    public List<short[,,]> Packages; // ���, ���濡 �����ϴ� ������ �迭( 1�� type / 2��, id / 3�� ���� / 4�� Ư������ / 5�� Ư������)

    [SerializeField]
    GameObject User_Inventory;
    [SerializeField]
    GameObject Storage_Inventory;

    [SerializeField]
    GameObject Info_Box;
    [SerializeField]
    GameObject Drag_Target_Image;

    private void Start()
    {
        //�÷��̾��� ������� ������
        for(short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
        }

        Generagting_Visual_Area();
    }

    //�÷��̾� ���

    //���� ����Ʈ
    //����ǰ ����Ʈ

    //���� �迭

    private void Generating_Acting_Inventory(short Backpack_ID, short[,,] Exiest_Packages)
    {
        //������ ũ�� ������
        int BackPacks_X = 1;
        int BackPacks_Y = 1;

        Backpacks_List.Add(Backpack_ID);
        Packages.Add(Exiest_Packages);
        //Instantiate
    }
    private void Generagting_Visual_Area()
    {
        //�÷��̾��� ������� ������ ���� ID ,
        //instan

        
        
    }

    public void Refresh_BackpacksList(int[,] Order_And_ID)
    {
    }

    public void Refresh_Packages(int order,int BackPackID, int[,] package)
    {
        //���� ID�� �´� ũ��,�̹��� ������
        
    }
    
}
