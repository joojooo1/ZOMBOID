using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Item_Type
//{
//    empty = 0,
//    Food = 1,
//    Medical = 2,
//    Weapons = 3,
//    Literature = 4,
//    Electronics = 5,
//    Clothing = 6,
//    Gardening = 7,
//    Container = 8
//}


public class Item_invenWindow : MonoBehaviour
{
    List<Item_Ins> slotlist = new List<Item_Ins>();
    [SerializeField]
    GameObject slotPrefab;
    [SerializeField]
    Transform SlotWindow;
    void Start()
    {
        //GameObject tempObj = null;
        //for (int i = 0; i < 30; ++i)
        //{
        //    tempObj = Instantiate(slotPrefab, SlotWindow);
        //    Item_Ins slot = tempObj.GetComponent<Item_Ins>();
        //    slotlist.Add(slot);
        //    slotlist[i].SetItem(Item_Type.empty, 0);
        //}


        //InsertItem((Item_Type)1, 1);
        //InsertItem((Item_Type)2, 2);
        //InsertItem((Item_Type)3, 3);
    }

    private void Update()
    {
        // 물병 등 다 마시고 Container 로 변경되어야 하는 경우 반영해야 됨
    }


    //void InsertItem(Item_Type Type, int ItemCode)
    //{
    //    for (int i = 0; i < slotlist.Count; ++i)
    //    {
    //        if (slotlist[i].CurrentType == Item_Type.empty)
    //        {
    //            slotlist[i].SetItem(Type, ItemCode);
    //            return;
    //        }
    //    }
    //}

    /*******  Food  *******/

    // 비어있는 오브젝트(선반 등)와 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_item(Location_Type location_Type)
    {
        List<Item_Food> food_List = new List<Item_Food>();  // 생성위치에 맞는 아이템 List
        for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
        {
            food_List.Add(Item_DataBase.item_database.food_Ins[i]);
        }

        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~8개 생성

        GameObject obj = null;
        for (int i = 0; i < Count; i++)
        {
            System.Random rand_item = new System.Random();
            int item = rand_item.Next(0, food_List.Count);

        }

    }


    /*******  Literature  *******/

    // 비어있는 책장과 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_Book(Location_Type location_Type)
    {
        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~10개 생성

        for (int i = 0; i < Count; i++)
        {
            System.Random rand_book = new System.Random();
            int item = rand_book.Next(0, Item_DataBase.item_database.literature_Ins.Count);

            //Instan(literature_Ins[item]);
        }

    }


    // Medical

    // 비어있는 오브젝트(약국의 선반 등)와 플레이어가 충돌 시 랜덤으로 생성되도록 호출
    // bool로 기존에 생성된 적 있는 오브젝트인지 체크
    public void Set_Generating_item(Location_Type location_Type, List<Item_Medical> medical_Ins)
    {
        List<Item_Medical> medical_List = new List<Item_Medical>();
        for (int i = 0; i < medical_Ins.Count; i++)
        {
            if (medical_Ins[i].Is_Ins)  // 제작해야하는 아이템 제외
                medical_List.Add(medical_Ins[i]);
        }

        System.Random rand_Count = new System.Random();
        int Count = rand_Count.Next(0, 8);  // 0~6개 생성

        for (int i = 0; i < Count; i++)
        {
            System.Random rand_item = new System.Random();
            int item = rand_item.Next(0, medical_List.Count);

            //Instan(medical_List[item]);
        }

    }


    // Weapons

    public void Equipping_Weapon(Item_Weapons weapon)  // UI에서 장비 착용 시 호출
    {
        //Item_Weapons Current_Weapon = Instan(weapon);
        //if (weapon.WeaponType == Weapon_type.Gun)
        //{
        //    weapon.Gun_Max_Capacity = 20;
        //}
        weapon.Nesting_Depth = 1;
        Player_main.player_main.Is_Equipping_Weapons = true;
    }

    //public Item_Weapons Instan(Item_Weapons weapon)
    //{
    //    Item_Weapons newWeapon = Instantiate(Weapons_Prefab).GetComponent<Item_Weapons>();
    //    newWeapon = weapon;
    //    return newWeapon;
    //}

    //public void Set_AMMO_Capacity(Item_Weapons weapon)
    //{
    //    switch (weapon.Gun_Magazine)
    //    {
    //        case Magazine_Type.M9_Magazine:
    //            weapon.Gun_Max_Capacity = 15;
    //            break;
    //        case Magazine_Type.M1911_Auto_Magazine:
    //            weapon.Gun_Max_Capacity = 7;
    //            break;
    //        case Magazine_Type.D_E_Magazine:
    //            weapon.Gun_Max_Capacity = 8;
    //            break;
    //        case Magazine_Type.MSR700_Magazine:
    //            weapon.Gun_Max_Capacity = 3;
    //            break;
    //        case Magazine_Type.MSR788_Magazine:
    //            weapon.Gun_Max_Capacity = 3;
    //            break;
    //        case Magazine_Type.M16_Magazine:
    //            weapon.Gun_Max_Capacity = 30;
    //            break;
    //        case Magazine_Type.M14_Magazine:
    //            weapon.Gun_Max_Capacity = 20;
    //            break;
    //        case Magazine_Type.None:
    //            break;
    //    }
    //}

    // 

}
