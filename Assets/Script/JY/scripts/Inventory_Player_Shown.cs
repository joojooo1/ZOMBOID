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

    public List<short> Backpacks_List; // 장비, 가방 리스트
    public List<short[,,]> Packages; // 장비, 가방에 대응하는 아이템 배열( 1면 type / 2면, id / 3면 갯수 / 4면 특수정보 / 5면 특수정보)

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
        //플레이어의 장비목록을 가져옴
        for(short i = 0; i < Backpacks_List.Count; i++)
        {
            //Generating_Acting_Inventory(Backpacks_List[i].ID,)
        }

        Generagting_Visual_Area();
    }

    //플레이어 장비

    //가방 리스트
    //소지품 리스트

    //가방 배열

    private void Generating_Acting_Inventory(short Backpack_ID, short[,,] Exiest_Packages)
    {
        //백팩의 크기 가져옴
        int BackPacks_X = 1;
        int BackPacks_Y = 1;

        Backpacks_List.Add(Backpack_ID);
        Packages.Add(Exiest_Packages);
        //Instantiate
    }
    private void Generagting_Visual_Area()
    {
        //플레이어의 가방들을 가져옴 가방 ID ,
        //instan

        
        
    }

    public void Refresh_BackpacksList(int[,] Order_And_ID)
    {
    }

    public void Refresh_Packages(int order,int BackPackID, int[,] package)
    {
        //가방 ID에 맞는 크기,이미지 가져옴
        
    }
    
}
