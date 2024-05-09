using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.Profiling.Memory.Experimental;
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

    public GameObject delete_button;

    public Crafting_type type;

    private void OnEnable()
    {
        ui_Craft_Window = this;

        Origin_list = new List<Crafting_item>();
        Crafting_item_Prefab_list = new List<UI_Craft_Prefab>();
        Crafting_Ingredients_Prefab_list = new List<UI_Craft_Prefab>();

        Add_Crafting_list();

        scrollbar.value = 1;
    }

    public void Add_Crafting_list()
    {
        for (int i = 0; i < Player_main.player_main.crafting_recipe.Recipe_Crafting_list.Count; i++)
        {
            if (Player_main.player_main.crafting_recipe.Recipe_Crafting_list[i].Is_Craftng)
            {
                Player_main.player_main.crafting_recipe.Recipe_Crafting_list[i].Add_Recipe();
            }            
        }

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
        Selected_item = null;
        for(int i = 0; i < Origin_list.Count; i++)
        {
            Origin_list[i].Ingredients_list.Clear();
        }
        Origin_list.Clear();
        Clear_Ingredients_Window();
        Clear_item_Window();
    }

    public void Choice_item(int index)
    {
        for (int i = 0; i < Crafting_item_Prefab_list.Count; i++)
        {
            if (Crafting_item_Prefab_list[i].item_index == index)
            {
                Crafting_item_Prefab_list[i].Choice = true;
                Selected_item = Crafting_item_Prefab_list[i];
                break;
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
        //0509 JY
        Inventory_Player_Shown.InvPS.Clearing_Ready_Crafting();
        //0509 JY
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
        if(_item.item_Info.item_type != Crafting_type.Crafting_Cook)
        {
            for (int i = 0; i < Origin_list[_item.item_index].Ingredients_list.Count;)
            {
                GameObject obj = null;
                obj = Instantiate(Crafting_Ingredients_Prefab, Crafting_Ingredients_Window);



                UI_Craft_Prefab item = obj.GetComponent<UI_Craft_Prefab>();
                item.Set_Ingredients(Origin_list[_item.item_index], i);
                
                Crafting_Ingredients_Prefab_list.Add(item);
                i++;
            }
        }
        else
        {
            for (int i = 0; i < 4;)
            {
                GameObject obj = null;
                obj = Instantiate(Crafting_Ingredients_Prefab, Crafting_Ingredients_Window);
                UI_Craft_Prefab item = obj.GetComponent<UI_Craft_Prefab>();
                item.Set_Ingredients_Box(i);

                Crafting_Ingredients_Prefab_list.Add(item);
                i++;
            }
        }

    }

    public void Clear_item_Window()
    {
        foreach (Transform child in Crafting_Window)
        {
            Destroy(child.gameObject);
        }
        Crafting_item_Prefab_list.Clear();
    }

    public void Clear_Ingredients_Window()
    {
        foreach (Transform child in Crafting_Ingredients_Window)
        {
            Destroy(child.gameObject);
        }
        Crafting_Ingredients_Prefab_list.Clear();
    }

    UI_Craft_Prefab Selected_item = null;
    public void Ins_item_Window()
    {
        bool check = false;
        if(Crafting_Ins_Window != null)
        {
            foreach (Transform child in Crafting_Ins_Window)
            {
                if(child.gameObject.activeSelf) check = true;
                else check = false;
            }
        }

        if (Selected_item != null && check == false)//여기에 재료 조건문 추가
        {
            //0509 JY
            

            if (!Inventory_Player_Shown.InvPS.Checking_Crafting_Canbe())
            {
                return;
            }
            //0509 JY
            if (type != Crafting_type.Crafting_Furniture)   // 재료가 있는지 확인하고 있으면 생성하도록 구현해야함
            {
                GameObject obj = null;
                obj = Instantiate(Crafting_Ins_item, Crafting_Ins_Window);
                UI_Craft_Ins_Prefab item = obj.GetComponent<UI_Craft_Ins_Prefab>();
                item.Set_Info(Selected_item.item_Info);
                delete_button.SetActive(true);

                // 재료만큼 인벤토리에서 없애고 관련 스킬 경험치 올려야됨
                switch (Selected_item.item_Info.item_DB_type)
                {
                    case Type.food:
                        Player_main.player_main.Skill.Cooking_Level.SetEXP(0.75f);
                        break;
                    case Type.Electronics:
                        Player_main.player_main.Skill.Electrical_Level.SetEXP(0.75f);
                        break;
                    case Type.Furniture:
                        Player_main.player_main.Skill.Carpentry_Level.SetEXP(0.75f);
                        break;

                        //case Type.Farming:  // Farming_Level은 농사지어서 EXP up
                        //case Type.Medical:  // FirstAid_Level은 치료해서 EXP up
                        //case Type.clothing: // 재단술 구현x
                }

            }
            else
            {
                // 가구는 제작하기 버튼 누르면 맵에서 바로 설치하는 기능 구현해야함
                // 제작창에서 Crafting_Ins_Window 없음
            }

        }

    }

    public void Destroy_item()
    {
        foreach (Transform child in Crafting_Ins_Window)
        {
            Destroy(child.gameObject);
        }
        delete_button.SetActive(false);
    }
}
