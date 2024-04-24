using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Craft_Ins_Prefab : MonoBehaviour
{
    public UnityEngine.UI.Image item_Image;
    public Crafting_item item_Info;

    public void Set_Info(Crafting_item item)
    {
        item_Image.sprite = item.item_Image;
        item_Info = item;
    }




}
