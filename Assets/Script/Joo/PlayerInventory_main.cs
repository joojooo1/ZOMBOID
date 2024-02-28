using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory_main : MonoBehaviour
{
    public static PlayerInventory_main playerInventory_main;

    public PlayerInventory_Weight Inventory_Weight = new PlayerInventory_Weight();

    public List<GameObject> Inventory = new List<GameObject>();
    public void Add_Weapon_Item(GameObject Add_Item)
    {
        Weapon_Detail item = Add_Item.GetComponent<Weapon_Detail>();
        Inventory_Weight.Add_Weight(item.WeaponWeight);
        Inventory.Add(Add_Item);
        if (Inventory_Weight.Get_Current_Weight() > Inventory_Weight.Get_MaxWeight())
        {
            Inventory_Weight.Add_Weight(-item.WeaponWeight);
            Inventory.Remove(Add_Item);
        }
    }

    //public void Is_Equipping_weapon(int weapon_ID)
    //{
    //    foreach (GameObject Weapon_Detail in Inventory)
    //    {
    //        if(Weapon_Detail.WeaponID == weapon_ID)
    //        {
    //            Weapon_Detail.Is_Equipping = true;
    //        }
    //        else
    //        {
    //            Weapon_Detail.Is_Equipping = false;
    //        }
    //    }

    //}

    public int weapon_ID; // 아이템의 고유한 식별자

    private float lastClickTime;
    private int clickCount;

    public void OnMouseUpAsButton(Weapon_Detail Weapon)
    {
        
        //if (currentItem == null || currentItem != item)
        //{
        //    currentItem = item;
        //}
        // 같은 아이템을 더블 클릭했을 때
        //else
        //{
        //    // 아이템의 ID를 가져옴
        //    //int itemID = item.itemID;
        //    Debug.Log("Double clicked item with ID: " + itemID);
        //    // 원하는 동작을 수행
        //}

        float currentTime = Time.time;
        if (currentTime - lastClickTime < 0.2f) // 더블클릭 간격을 설정
        {
            clickCount++;
            if (clickCount == 2)
            {
                //Is_Equipping_weapon(weapon_ID); // 더블클릭 시 아이템을 장착
                clickCount = 0;
            }
        }
        else
        {
            clickCount = 1;
        }
        lastClickTime = currentTime;
    }



}
