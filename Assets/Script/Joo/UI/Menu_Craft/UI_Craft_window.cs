using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Craft_window : MonoBehaviour
{


    public UnityEngine.UI.Scrollbar scrollbar;
    List<GameObject> Crafting_item_list = new List<GameObject>();

    public GameObject Crafting_Prefab;

    void Start()
    {
        scrollbar.value = 1;
    }

    //public void 
}
