using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using static Item_DataBase;

public class UI_Craft_window : MonoBehaviour
{
    public static UI_Craft_window ui_Craft_Window;

    public UnityEngine.UI.Scrollbar scrollbar;
    public UnityEngine.UI.Text item_Text;
    public GameObject Info_window;

    List<Crafting_item> Origin_list;
    List<UI_Craft_Prefab> Crafting_item_Prefab_list;
    List<UI_Craft_Prefab> Crafting_Ingredients_Prefab_list;

    public GameObject Crafting_Prefab;
    public Transform Crafting_Window;
    public GameObject Crafting_Ingredients_Prefab;
    public Transform Crafting_Ingredients_Window;
    public GameObject Crafting_Ins_item;
    public Transform Crafting_Ins_Window;
    public Crafting_type type;

    private void OnEnable()
    {
        ui_Craft_Window = this;
        scrollbar.value = 1;

        Origin_list = new List<Crafting_item>();
        Crafting_item_Prefab_list = new List<UI_Craft_Prefab>();
        Crafting_Ingredients_Prefab_list = new List<UI_Craft_Prefab>();

        list_ins();
    }

    public void list_ins()
    {
        switch (type)
        {
            case Crafting_type.Crafting_General:
                if (UI_Craft.UI_Craft_main.Crafting_General_list != null)
                {
                    for (int i = 0; i < UI_Craft.UI_Craft_main.Crafting_General_list.Count; i++)
                    {
                        Origin_list.Add(UI_Craft.UI_Craft_main.Crafting_General_list[i]);
                    }
                }
                break;
            case Crafting_type.Crafting_Tool:
                if (UI_Craft.UI_Craft_main.Crafting_Tool_list != null)
                {
                    for (int i = 0; i < UI_Craft.UI_Craft_main.Crafting_Tool_list.Count; i++)
                    {
                        Origin_list.Add(UI_Craft.UI_Craft_main.Crafting_Tool_list[i]);
                    }
                }
                break;
            case Crafting_type.Crafting_Cook:
                if (UI_Craft.UI_Craft_main.Crafting_Cook_list != null)
                {
                    for (int i = 0; i < UI_Craft.UI_Craft_main.Crafting_Cook_list.Count; i++)
                    {
                        Origin_list.Add(UI_Craft.UI_Craft_main.Crafting_Cook_list[i]);
                    }
                }
                break;
            case Crafting_type.Crafting_Medical:
                if (UI_Craft.UI_Craft_main.Crafting_Medical_list != null)
                {
                    for (int i = 0; i < UI_Craft.UI_Craft_main.Crafting_Medical_list.Count; i++)
                    {
                        Origin_list.Add(UI_Craft.UI_Craft_main.Crafting_Medical_list[i]);
                    }
                }
                break;
            case Crafting_type.Crafting_Furniture:
                if (UI_Craft.UI_Craft_main.Crafting_Furniture_list != null)
                {
                    for (int i = 0; i < UI_Craft.UI_Craft_main.Crafting_Furniture_list.Count; i++)
                    {
                        Origin_list.Add(UI_Craft.UI_Craft_main.Crafting_Furniture_list[i]);
                    }

                }
                break;
        }

        if (Origin_list != null)
        {
            for (int i = 0; i < Origin_list.Count;)
            {
                GameObject obj = null;
                obj = Instantiate(Crafting_Prefab, Crafting_Window);
                UI_Craft_Prefab item = obj.GetComponentInChildren<UI_Craft_Prefab>();
                item.Set_item(Origin_list[i], i);
                Crafting_item_Prefab_list.Add(item);
                i++;
            }
        }
    }

    private void OnDisable()
    {
        foreach (Transform child in Crafting_Window)
        {
            Destroy(child.gameObject);
        }

        Origin_list.Clear();
        Crafting_item_Prefab_list.Clear();
        Clear_Ingredients_Window();
    }

    public void Choice_item(int index)
    {
        for (int i = 0; i < Crafting_item_Prefab_list.Count; i++)
        {
            if (Crafting_item_Prefab_list[i].item_index == index)
            {
                Crafting_item_Prefab_list[i].Choice = true;
            }
            else
            {
                Crafting_item_Prefab_list[i].Choice = false;
            }
        }

        for (int k = 0; k < Crafting_item_Prefab_list.Count; k++)
        {
            Color tmp = Crafting_item_Prefab_list[k].item_Image.color;
            if (Crafting_item_Prefab_list[k].Choice)
            {
                tmp.a = 1f;
            }
            else
            {
                tmp.a = 0.5f;
            }
            Crafting_item_Prefab_list[k].item_Image.color = tmp;
        }

        Clear_Ingredients_Window();
        Ins_Ingredients_Window(Crafting_item_Prefab_list[index]);
    }

    public void Open_name_window(Transform pos, string name)
    {
        Info_window.SetActive(true);
        Info_window.transform.position = pos.position;
        Vector3 temp = new Vector3(80, -20, 0);
        Info_window.transform.position += temp;
        item_Text.text = name;       
    }

    public void Close_name_window()
    {
        Info_window.SetActive(false);
    }

    public void Ins_Ingredients_Window(UI_Craft_Prefab _item)
    {
        for (int i = 0; i < _item.item_Info.Ingredients_list.Count;)
        {
            GameObject obj = null;
            obj = Instantiate(Crafting_Ingredients_Prefab, Crafting_Ingredients_Window);
            UI_Craft_Prefab item = obj.GetComponent<UI_Craft_Prefab>();
            item.Set_Ingredients(_item.item_Info, i);
            Crafting_Ingredients_Prefab_list.Add(item);
            i++;
        }
    }

    public void Clear_Ingredients_Window()
    {
        foreach (Transform child in Crafting_Ingredients_Window)
        {
            Destroy(child.gameObject);
        }
        Crafting_Ingredients_Prefab_list.Clear();
    }

    public void Ins_item_Window(UI_Craft_Prefab _item)
    {
        GameObject obj = null;
        obj = Instantiate(Crafting_Ins_item, Crafting_Ins_Window);
        UI_Craft_Ins_Prefab item = obj.GetComponent<UI_Craft_Ins_Prefab>();
        item.Set_Info(_item.item_Info);
    }
}
