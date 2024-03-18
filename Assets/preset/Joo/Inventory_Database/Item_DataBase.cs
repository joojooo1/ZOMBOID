using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_DataBase : MonoBehaviour
{
    public static Item_DataBase item_database;

    private void Awake()
    {
        if (item_database == null)
        {
            item_database = this;
        }
    }

    public List<Item_Food> food_Ins;
    public List<Item_Medical> medical_Ins;
    public List<Item_Weapons> weapons_Ins;
    public List<Item_Literature> literature_Ins;
    public List<Item_Electronics> electronics_Ins;
    public List<Item_Clothing> clothing_Ins;
    public List<Item_Gardening> gardening_Ins;
    public List<Item_Container> Container_Ins;


    public Item_Food Get_Foodlist(int ID)
    {
        return food_Ins[ID];
    }

    public Item_Medical Get_Medicallist(int ID)
    {
        return medical_Ins[ID];
    }

    public Item_Weapons Get_Weaponslist(int ID)
    {
        return weapons_Ins[ID];
    }

    [SerializeField]
    Item_Ins DetailWindow;

    public void OpenDetail(Item_Type type, int ItemCode)
    {
        DetailWindow.SetItem(type, ItemCode);
        DetailWindow.gameObject.SetActive(true);
    }

    public void CloseDetail()
    {
        DetailWindow.gameObject.SetActive(false);
    }
}
