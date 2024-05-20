using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class Recipe_item
{
    public bool Is_Craftng;

    public Skill_Type requisite_Skill;
    public int requisite_Level;
    public bool requisite_read_Magazine;

    public int Magazine_ID;  // ���� ���д� �����Ǵ� -1
    public Type Crafting_item_type;
    public int Crafting_item_ID;
    public Crafting_type _Crafting_type;
    public int Crafting_item_number;
    public List<Recipe_Ingredients> Recipe_Ingredients_list;
    public List<Recipe_Ingredients> Recipe_Ingredients_Tool_list;

    public Recipe_item(int _Magazine_ID, Skill_Type Skill, int Skill_level, Type _Crafting_item_type, int _Crafting_item_ID, int _Crafting_item_number)
    {
        Magazine_ID = _Magazine_ID;
        Crafting_item_type = _Crafting_item_type;
        Crafting_item_ID = _Crafting_item_ID;
        Crafting_item_number = _Crafting_item_number;
        requisite_Skill = Skill;
        requisite_Level = Skill_level;
        Is_Craftng = false;
        Recipe_Ingredients_list = new List<Recipe_Ingredients>();
        Recipe_Ingredients_Tool_list = new List<Recipe_Ingredients>();

        if(Magazine_ID > 0)
        {
            requisite_read_Magazine = false;
        }
        else
        {
            requisite_read_Magazine = true;
        }

        switch (_Crafting_item_type)
        {
            case Type.food:
                _Crafting_type = Crafting_type.Crafting_Cook;
                break;
            case Type.Medical:
                _Crafting_type = Crafting_type.Crafting_Medical;
                break;
            case Type.weapon:
                _Crafting_type = Crafting_type.Crafting_Tool;
                break;
            case Type.Electronics:
                _Crafting_type = Crafting_type.Crafting_General;
                break;
            case Type.Farming:
                _Crafting_type = Crafting_type.Crafting_Tool;
                break;
            case Type.Container:
                _Crafting_type = Crafting_type.Crafting_General;
                break;
            case Type.Normal:
                _Crafting_type = Crafting_type.Crafting_General;
                break;
            case Type.Furniture:
                _Crafting_type = Crafting_type.Crafting_Installation;
                break;
            case Type.Tool:
                _Crafting_type = Crafting_type.Crafting_Tool;
                break;
        }
    }

    public void Add_Recipe_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Recipe_Ingredients recipe_Ingredients = new Recipe_Ingredients(_DB_type, _DB_ID, value);
        Recipe_Ingredients_list.Add(recipe_Ingredients);
    }

    public void Add_Recipe_Ingredients_Tool(Type _DB_type, int _DB_ID, int value)
    {
        Recipe_Ingredients recipe_Ingredients = new Recipe_Ingredients(_DB_type, _DB_ID, value);
        Recipe_Ingredients_Tool_list.Add(recipe_Ingredients);
    }

    public void Add_Recipe()
    {
        int Current_index = -1;
        switch (Crafting_item_type)  // ����� �������� Ÿ��
        {
            case Type.food:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.food_Ins[Crafting_item_ID].Food_Image[0], Item_DataBase.item_database.food_Ins[Crafting_item_ID].FoodName, 
                    Item_DataBase.item_database.food_Ins[Crafting_item_ID].FoodName_Kr, Crafting_item_number);
                break;
            case Type.Medical:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.medical_Ins[Crafting_item_ID].Medical_Image, Item_DataBase.item_database.medical_Ins[Crafting_item_ID].MedicalName, 
                    Item_DataBase.item_database.medical_Ins[Crafting_item_ID].MedicalName_Kr, Crafting_item_number);
                break;
            case Type.weapon:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.weapons_Ins[Crafting_item_ID].ItemImage, Item_DataBase.item_database.weapons_Ins[Crafting_item_ID].WeaponName, 
                    Item_DataBase.item_database.weapons_Ins[Crafting_item_ID].WeaponName_Kr, Crafting_item_number);
                break;
            case Type.Electronics:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].Electronics_Image, Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].ElectronicsName, 
                    Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].ElectronicsName_Kr, Crafting_item_number);
                break;
            case Type.Farming:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.Farming_Ins[Crafting_item_ID].Gardening_Image, Item_DataBase.item_database.Farming_Ins[Crafting_item_ID].Gardening_Name, 
                    Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].ElectronicsName_Kr, Crafting_item_number);
                break;
            case Type.Container:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.Container_Ins[Crafting_item_ID].Container_Image, Item_DataBase.item_database.Container_Ins[Crafting_item_ID].ContainerName, 
                    Item_DataBase.item_database.Container_Ins[Crafting_item_ID].ContainerName_Kr, Crafting_item_number);
                break;
            case Type.Normal:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.ETC_Ins[Crafting_item_ID].ETC_Image, Item_DataBase.item_database.ETC_Ins[Crafting_item_ID].ETC_Name, 
                    Item_DataBase.item_database.ETC_Ins[Crafting_item_ID].ETC_Name_kr, Crafting_item_number);
                break;
            case Type.Furniture:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.furniture_Ins[Crafting_item_ID].Furniture_Image, Item_DataBase.item_database.furniture_Ins[Crafting_item_ID].Furniture_Name, 
                    Item_DataBase.item_database.furniture_Ins[Crafting_item_ID].Furniture_Name_kr, Crafting_item_number);
                break;
            case Type.Tool:
                Current_index = UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.Tool_Ins[Crafting_item_ID].Tool_Image, Item_DataBase.item_database.Tool_Ins[Crafting_item_ID].Tool_Name,
                    Item_DataBase.item_database.Tool_Ins[Crafting_item_ID].Tool_Name_Kr, Crafting_item_number);
                break;
        }

        for (int i = 0; i < Recipe_Ingredients_list.Count; i++)
        {
            switch (_Crafting_type)
            {
                case Crafting_type.Crafting_General:
                    UI_Craft.UI_Craft_main.Crafting_General_list[Current_index].Add_Ingredients(
                        Recipe_Ingredients_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_list[i].Recipe_value);
                    break;
                case Crafting_type.Crafting_Tool:
                    UI_Craft.UI_Craft_main.Crafting_Tool_list[Current_index].Add_Ingredients(
                        Recipe_Ingredients_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_list[i].Recipe_value);
                    break;
                case Crafting_type.Crafting_Cook:
                    UI_Craft.UI_Craft_main.Crafting_Cook_list[Current_index].Add_Ingredients(
                        Recipe_Ingredients_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_list[i].Recipe_value);
                    break;
                case Crafting_type.Crafting_Medical:
                    UI_Craft.UI_Craft_main.Crafting_Medical_list[Current_index].Add_Ingredients(
                        Recipe_Ingredients_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_list[i].Recipe_value);
                    break;
                case Crafting_type.Crafting_Installation:
                    UI_Craft.UI_Craft_main.Crafting_Furniture_list[Current_index].Add_Ingredients(
                        Recipe_Ingredients_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_list[i].Recipe_value);
                    break;
            }
        }

        if (Recipe_Ingredients_Tool_list.Count > 0)
        {
            for (int i = 0; i < Recipe_Ingredients_Tool_list.Count; i++)
            {
                switch (_Crafting_type)
                {
                    case Crafting_type.Crafting_General:
                        UI_Craft.UI_Craft_main.Crafting_General_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_Tool_list[i].Recipe_value);
                        break;
                    case Crafting_type.Crafting_Tool:
                        UI_Craft.UI_Craft_main.Crafting_Tool_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_Tool_list[i].Recipe_value);
                        break;
                    case Crafting_type.Crafting_Cook:
                        UI_Craft.UI_Craft_main.Crafting_Cook_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_Tool_list[i].Recipe_value);
                        break;
                    case Crafting_type.Crafting_Medical:
                        UI_Craft.UI_Craft_main.Crafting_Medical_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_Tool_list[i].Recipe_value);
                        break;
                    case Crafting_type.Crafting_Installation:
                        UI_Craft.UI_Craft_main.Crafting_Furniture_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID, Recipe_Ingredients_Tool_list[i].Recipe_value);
                        break;
                }
            }
        }
    }

    public void Set_Is_Crafting()
    {
        switch (requisite_Skill)
        {
            case Skill_Type.Carpentry:
                if(requisite_Level > 0)
                {
                    if(Player_main.player_main.Skill.Carpentry_Level.Get_C_Level() >= requisite_Level)
                    {
                        if (requisite_read_Magazine)
                        {
                            Is_Craftng = true;
                        }
                        else
                        {
                            Is_Craftng = false;
                        }
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                else
                {
                    if (requisite_read_Magazine)
                    {
                        Is_Craftng = true;
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                break;
            case Skill_Type.Farming:
                if (requisite_Level > 0)
                {
                    if (Player_main.player_main.Skill.Farming_Level.Get_C_Level() >= requisite_Level)
                    {
                        if (requisite_read_Magazine)
                        {
                            Is_Craftng = true;
                        }
                        else
                        {
                            Is_Craftng = false;
                        }
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                else
                {
                    if (requisite_read_Magazine)
                    {
                        Is_Craftng = true;
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                break;
            case Skill_Type.Cooking:
                if (requisite_Level > 0)
                {
                    if (Player_main.player_main.Skill.Cooking_Level.Get_C_Level() >= requisite_Level)
                    {
                        if (requisite_read_Magazine)
                        {
                            Is_Craftng = true;
                        }
                        else
                        {
                            Is_Craftng = false;
                        }
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                else
                {
                    if (requisite_read_Magazine)
                    {
                        Is_Craftng = true;
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                break;
            case Skill_Type.Fishing:
                if (requisite_Level > 0)
                {
                    if (Player_main.player_main.Skill.Fishing_Level.Get_S_Level() >= requisite_Level)
                    {
                        if (requisite_read_Magazine)
                        {
                            Is_Craftng = true;
                        }
                        else
                        {
                            Is_Craftng = false;
                        }
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                else
                {
                    if (requisite_read_Magazine)
                    {
                        Is_Craftng = true;
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                break;
            case Skill_Type.Electrical:
                if (requisite_Level > 0)
                {
                    if (Player_main.player_main.Skill.Electrical_Level.Get_C_Level() >= requisite_Level)
                    {
                        if (requisite_read_Magazine)
                        {
                            Is_Craftng = true;
                        }
                        else
                        {
                            Is_Craftng = false;
                        }
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                else
                {
                    if (requisite_read_Magazine)
                    {
                        Is_Craftng = true;
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                break;
            case Skill_Type.FirstAid:
                if (requisite_Level > 0)
                {
                    if (Player_main.player_main.Skill.FirstAid_Level.Get_C_Level() >= requisite_Level)
                    {
                        if (requisite_read_Magazine)
                        {
                            Is_Craftng = true;
                        }
                        else
                        {
                            Is_Craftng = false;
                        }
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                else
                {
                    if (requisite_read_Magazine)
                    {
                        Is_Craftng = true;
                    }
                    else
                    {
                        Is_Craftng = false;
                    }
                }
                break;
            case Skill_Type.None:
                if (requisite_read_Magazine)
                {
                    Is_Craftng = true;
                }
                else
                {
                    Is_Craftng = false;
                }
                break;
        }
    }
}

public class Recipe_Ingredients
{
    public Type Recipe_Ingredients_DB_type;
    public int Recipe_Ingredients_DB_ID;
    public int Recipe_value;  // �ʿ��� ���� or �뷮

    public Recipe_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Recipe_Ingredients_DB_type = _DB_type;
        Recipe_Ingredients_DB_ID = _DB_ID;
        Recipe_value = value;
    }
}

public class Player_Crafting : MonoBehaviour
{
    /********** Magazine Recipe *********/
    //12. Good Cooking Magazine Vol. 1
    public Recipe_item Recipe_Make_Bread;  // ��
    //13. Good Cooking Magazine Vol. 2 
    public Recipe_item Recipe_Make_Bowl_of_Rice; // ������

    //14. Engineer Magazine Vol. 1
    public Recipe_item Recipe_Make_Charcoal_Barbecue;  // ���� �ٺ�ť ���
                                                        // ���: �����ݼ���x4, ��������ġ(2), ���� ����ũ + �ݼ�level_3   // �ݼ� exp 6.25
    //15. Engineer Magazine Vol. 2 
    public Recipe_item Recipe_Make_Propane_Barbecue;   // ������ �ٺ�ť ���
                                                        // ���: �ݼ���x4, ��������ũ, ��������ġ(2), ���� ����ũ + �ݼ�level_6   // �ݼ� exp 6.25

    //16. The Farming Magazine
    public Recipe_item Recipe_Make_Mildew_Cure;    // ������ ��������
                                                    // ���: �� ������ ��������, ��(3), ���(5)
    public Recipe_item Recipe_Make_Flies_Cure;    // ������ ��������
                                                    // ���: �� ������ ��������, ����

    //17. Angler USA Magazine Vol. 1
    public Recipe_item Recipe_Make_Fishing_Rod;  // ���ô�
                                                 // ���: ưư�� �����x1, Į
    //18. Angler USA Magazine Vol. 2
    public Recipe_item Recipe_Make_Fishing_Net;  // ���� �׹�
                                                 // ���: ��x2, ö��x1
    public Recipe_item Recipe_Get_Wire_Back;  //  ���峭 ���� �׹����� ���̾� ������   // ö��x1 ����

    //19. How to Use Generators :  ������ ����
    public Recipe_item Recipe_Teaches_the_player_how_to_connect_generators_to_buildings;

    //20. Laines Auto Manual - Commercial Models :  ǥ�� ���� ���� �������� ����
    public Recipe_item Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types;
    //21. Laines Auto Manual - Performance Models :  ���� ���� ���� �������� ����
    public Recipe_item Recipe_Can_perform_maintenance_on_sport_vehicle_types;
    //22. Laines Auto Manual - Standard Models :  ������ ���� ���� �������� ����
    public Recipe_item Recipe_Can_perform_maintenance_on_standard_vehicle_types;

    //23. The Metalwork Magazine Vol. 1
    public Recipe_item Recipe_Make_Log_Walls;   // �볪�� ��
                                                //  ���: ������õx4, �볪��x4, ��ġ   // ��� exp 1.25
    //24. The Metalwork Magazine Vol. 2  
    public Recipe_item Recipe_Make_Counters;   // ī���� 
                                                //  ���: ����x4, ��x4, ��ġ  + ���level_4   // ��� exp 1.25
    //25. The Metalwork Magazine Vol. 3 
    public Recipe_item Recipe_Make_Composter;   // �����
                                                //  ���: ����x5, ��x4, ��ġ  + ���level_2   // ��� exp 1.25

    //26. Guerilla Radio Vol. 1 
    public Recipe_item Recipe_Craft_Makeshift_Radio;  // ����
    //27. Guerilla Radio Vol. 2 
    public Recipe_item Recipe_Craft_Makeshift_Walkie_Talkie;  // ������

    /********** Level Recipe *********/



    // Start Recipe
    public Recipe_item Recipe_Craft_Salad;  // ������

    public Recipe_item Recipe_Craft_RippedSheets;  // ������ õ
    //public Recipe_item Recipe_Craft_RippedSheets_1;  // ������ õ
    public Recipe_item Recipe_Craft_Sterilized_RippedSheets;  // �ҵ��� ������ õ
    public Recipe_item Recipe_Craft_Sheets;  // õ
    public Recipe_item Recipe_Craft_SheetRope;  // õ ����
    public Recipe_item Recipe_Craft_Plank;  // ����
    public Recipe_item Recipe_Craft_Logs;  // �볪�� ����
    public Recipe_item Recipe_Craft_Log;  // �볪�� ( ���� -> ���� )

    // public Recipe_item Recipe_Craft_Barricade;  // �ٸ�����Ʈ  ( ��orâ���� ��ȣ�ۿ� )    // ���: ����x1, ��x2, ��ġ   // ��� exp 0.75
    // public Recipe_item Recipe_Craft_Metal_Barricade;  // �ݼ� �ٸ�����Ʈ    // ���: �ݼ���x1, ��������ġ(1), ���� ����ũ   // �ݼ� exp 1.5

    public Recipe_item Recipe_Make_Metal_Sheet;    // �ݼ���  // ���: �����ݼ���x4, ��������ġ(2), ���� ����ũ + �ݼ�level_2       // �ݼ� exp 6.25
    public Recipe_item Recipe_Make_Small_Metal_Sheet;    // ���� �ݼ���x3  // ���: �ݼ���x1, ��������ġ(2), ���� ����ũ + �ݼ�level_2        // �ݼ� exp 6.25

    public Recipe_item Recipe_Craft_Spear;  // ���۵� â
    public Recipe_item Recipe_Craft_SpearMachete;  // â(����ü)

    public Recipe_item Recipe_Craft_Splint;  // �θ�  // ���: ����x1, ������ õx1 
    public Recipe_item Recipe_Craft_Sturdy_Stick;  // ưư�� �����x8   // ���: ����x1, ��
    public Recipe_item Recipe_Craft_Wooden_Crate;  // ��������   // ���: ����x3, ��x3, ��ġ   + ���level_1
    public Recipe_item Recipe_Craft_Metal_Crate;  // �ݼӻ���   // ���: �ݼ�������x2, �ݼ���x1, �����ݼ���x1, �ݼӺ�ǰx1, ��������ġ(2), ���� ����ũ   + �ݼ�level_4

    public Recipe_item Recipe_Make_Oven;  // ����  // ö��x2, ������x2, ������ǰ ��ǰx4 + ��ũ������̹�
    public Recipe_item Recipe_Make_Refrigerator; // �����  // ö��x3, �ݼ���x2, ������ǰ ��ǰx4 + ��ũ������̹�
    public Recipe_item Recipe_Make_Bed;  // ħ��  // ����x6, ��x4, ��Ʈ����x1  + ��ġ   + ���level_2
    public Recipe_item Recipe_Make_Mattress;  // ��Ʈ����  // ��x2, õx5  + �ٴ�
    public Recipe_item Recipe_Make_Wooden_Walls;  // ���� ��
    public Recipe_item Recipe_Make_Wooden_Tiles;  // ���� �ٴ�
    public Recipe_item Recipe_Make_Wooden_Door;  // ���� ��
    public Recipe_item Recipe_Make_Wooden_Fence;  // ���� ��Ÿ��
    public Recipe_item Recipe_Make_Sheet_Curtain;  // õ Ŀư
    public Recipe_item Recipe_Make_Barricade;  // �ٸ�����Ʈ
    public Recipe_item Recipe_Make_Metal_Barricade;  // �ݼ� �ٸ�����Ʈ
    public Recipe_item Recipe_Make_Campfire;  // ��ں�

    public Recipe_item Recipe_Make_Poultice;  // ������
    public Recipe_item Recipe_Charge_Magazine;  // źâ ����
    public Recipe_item Recipe_Open_NailBox;  // �� ���� -> ��


    public List<Recipe_item> Recipe_Crafting_list = new List<Recipe_item>();

    int target_index = -1;
    private void Awake()  
    {
        // Cooking
        /////////// �� ///////////    //12. Good Cooking Magazine Vol. 1    
        for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.food_Ins[i].FoodName == "Bread")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.food_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Bread = new Recipe_item(12, Skill_Type.Cooking, 0, Type.food, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Flour")  // �а���x1
                {
                    Recipe_Make_Bread.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // �丮 ����� ���
                {
                    Recipe_Make_Bread.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // �׸�_Tool
                {
                    Recipe_Make_Bread.Add_Recipe_Ingredients_Tool(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Bread);
        }
        else
        {
            target_index = -1;
        }

        /////////// ������ ///////////    //13. Good Cooking Magazine Vol. 2     
        Recipe_Make_Bowl_of_Rice = new Recipe_item(13, Skill_Type.Cooking, 0, Type.food, 0, 1);    
        for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.food_Ins[i].FoodName == "Bowl of Rice")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.food_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Bowl_of_Rice = new Recipe_item(13, Skill_Type.Cooking, 0, Type.food, target_index, 2);
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Rice")  // ��x1
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // �丮 ����� ���
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // �׸�_Tool
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients_Tool(Type.Tool, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Cooking Pot")  // ����_Tool
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients_Tool(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Bowl_of_Rice);
        }
        else
        {
            target_index = -1;
        }

        // Electronics
        /////////// ������ ///////////    //19. How to Use Generators :  ������ ����
        Recipe_Teaches_the_player_how_to_connect_generators_to_buildings = new Recipe_item(19, Skill_Type.Electrical, 0, Type.Electronics, 0, 1);

        Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types = new Recipe_item(20, Skill_Type.Electrical, 0, Type.Normal, 0, 1);    //20. Laines Auto Manual - Commercial Models :  ǥ�� ���� ���� �������� ����
        Recipe_Can_perform_maintenance_on_sport_vehicle_types = new Recipe_item(21, Skill_Type.Electrical, 0, Type.Normal, 0, 1);    //21. Laines Auto Manual - Performance Models :  ���� ���� ���� �������� ����
        Recipe_Can_perform_maintenance_on_standard_vehicle_types = new Recipe_item(22, Skill_Type.Electrical, 0, Type.Normal, 0, 1);    //22. Laines Auto Manual - Standard Models :  ������ ���� ���� �������� ����

        /////////// �볪�� �� ///////////   //23. The Metalwork Magazine Vol. 1        // ��� exp 1.25
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Log Walls")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Log_Walls = new Recipe_item(23, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������õx4
                {
                    Recipe_Make_Log_Walls.Add_Recipe_Ingredients(Type.Medical, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // �볪��x4
                {
                    Recipe_Make_Log_Walls.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Log_Walls.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Log_Walls);
        }
        else
        {
            target_index = -1;
        }

        /////////// ī���� ///////////   //24. The Metalwork Magazine Vol. 2         // ���level_4   // ��� exp 1.25
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Counter")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Counters = new Recipe_item(24, Skill_Type.Carpentry, 4, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x4
                {
                    Recipe_Make_Counters.Add_Recipe_Ingredients(Type.weapon, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x4
                {
                    Recipe_Make_Counters.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Counters.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Counters);
        }
        else
        {
            target_index = -1;
        }

        /////////// ����� ///////////    //25. The Metalwork Magazine Vol. 3         //  ���level_2   // ��� exp 1.25
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Composter")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Composter = new Recipe_item(25, Skill_Type.Carpentry, 2, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x5
                {
                    Recipe_Make_Composter.Add_Recipe_Ingredients(Type.weapon, i, 5);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x4
                {
                    Recipe_Make_Composter.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Composter.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Composter);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� ///////////    //26. Guerilla Radio Vol. 1 
        for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Radio")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.electronics_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Makeshift_Radio = new Recipe_item(-1, Skill_Type.Electrical, 0, Type.Electronics, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // ö��x1
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Amplifier")  // ������x1
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // ������ǰ ��ǰx2
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Aluminum")  // �˷�̴�x2
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // ��ũ������̹�_Tool
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Makeshift_Radio);
        }
        else
        {
            target_index = -1;
        }

        /////////// ������ ���� ///////////    //27. Guerilla Radio Vol. 2
        for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "WalkieTalkie")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.electronics_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Makeshift_Walkie_Talkie = new Recipe_item(27, Skill_Type.Electrical, 0, Type.Electronics, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // ö��x2
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Amplifier")  // ������x1
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // ������ǰ ��ǰx3
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Aluminum")  // �˷�̴�x3
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // ��ũ������̹�_Tool
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Makeshift_Walkie_Talkie);
        }
        else
        {
            target_index = -1;
        }

        // Farming
        /////////// ������ �������� ///////////   //16. The Farming Magazine
        for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Insecticide Spray")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.Tool_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Mildew_Cure = new Recipe_item(16, Skill_Type.Farming, 0, Type.Tool, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Gardening Spray (Empty)")  // �� ������ ��������x1
                {
                    Recipe_Make_Mildew_Cure.Add_Recipe_Ingredients(Type.Tool, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Water")  // ��(3)
                {
                    Recipe_Make_Mildew_Cure.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Cigarettes")  // ���(5)
                {
                    Recipe_Make_Mildew_Cure.Add_Recipe_Ingredients(Type.Medical, i, 5);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Mildew_Cure);
        }
        else
        {
            target_index = -1;
        }

        /////////// ������ �������� ///////////   //16. The Farming Magazine
        for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Mildew Spray")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.Tool_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Flies_Cure = new Recipe_item(16, Skill_Type.Farming, 0, Type.Tool, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Gardening Spray (Empty)")  // �� ������ ��������x1
                {
                    Recipe_Make_Flies_Cure.Add_Recipe_Ingredients(Type.Tool, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Milk")  // ����x1
                {
                    Recipe_Make_Flies_Cure.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Flies_Cure);
        }
        else
        {
            target_index = -1;
        }

        // Fishing
        /////////// ���ô� ///////////     //17. Angler USA Magazine Vol. 1
        for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Fishing Rod")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.weapons_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Fishing_Rod = new Recipe_item(17, Skill_Type.None, 0, Type.weapon, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "WoodenStick")  // ưư�� �����x1
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Twine")  // ��x2
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // ����ü_Tool
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Cleaver")  // �߽ĵ�_Tool
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Fishing_Rod);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� �׹� ///////////     //18. Angler USA Magazine Vol. 2
        for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "FishTrap")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.Tool_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Fishing_Net = new Recipe_item(18, Skill_Type.Fishing, 0, Type.Tool, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // ö��x1
                {
                    Recipe_Make_Fishing_Net.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Twine")  // ��x2
                {
                    Recipe_Make_Fishing_Net.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Fishing_Net);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���峭 ���� �׹����� ���̾� ������ ///////////     //18. Angler USA Magazine Vol. 2
        Recipe_Get_Wire_Back = new Recipe_item(18, Skill_Type.Fishing, 0, Type.Normal, 0, 1);
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Get_Wire_Back = new Recipe_item(18, Skill_Type.Fishing, 0, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "FishTrap (broken)")  // ö��x1
                {
                    Recipe_Get_Wire_Back.Add_Recipe_Ingredients(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Get_Wire_Back);
        }
        else
        {
            target_index = -1;
        }





        /////////// ������ ///////////
        for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.food_Ins[i].FoodName == "Salad")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.food_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Salad = new Recipe_item(-1, Skill_Type.Cooking, 0, Type.food, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // �丮 ����� ���
                {
                    Recipe_Craft_Salad.Add_Recipe_Ingredients(Type.food, i, 1);
                }

            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // �׸�_Tool
                {
                    Recipe_Craft_Salad.Add_Recipe_Ingredients_Tool(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Salad);
        }
        else
        {
            target_index = -1;
        }

        /////////// ������ õ ///////////
        for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.medical_Ins.Count - 1) 
                {
                    target_index = -1;
                }
            }
        }
        if(target_index >= 0)
        {
            Recipe_Craft_RippedSheets = new Recipe_item(-1, Skill_Type.None, 0, Type.Medical, target_index, 1); 
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Is_Cotton == true)  // T_shirt Ÿ���� �Ƿ�  ( �߰� ���� )
                {
                    Recipe_Craft_RippedSheets.Add_Recipe_Ingredients(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_RippedSheets);
        }
        else
        {
            target_index = -1;
        }

        /////////// �ҵ��� ������ õ ///////////
        for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Sterilized Ripped Sheets")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.medical_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Sterilized_RippedSheets = new Recipe_item(-1, Skill_Type.None, 0, Type.Medical, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������ õ
                {
                    Recipe_Craft_Sterilized_RippedSheets.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Whiskey Bottle")  // ���ڿ�
                {
                    Recipe_Craft_Sterilized_RippedSheets.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Bottle of Disinfectant")  // ���ڿ�
                {
                    Recipe_Craft_Sterilized_RippedSheets.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Sterilized_RippedSheets);
        }
        else
        {
            target_index = -1;
        }

        /////////// õ ///////////
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if(target_index >= 0)
        {
            Recipe_Craft_Sheets = new Recipe_item(-1, Skill_Type.None, 0, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������ õx1
                {
                    Recipe_Craft_Sheets.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Sheets);
        }
        else
        {
            target_index = -1;
        }

        /////////// õ ���� ///////////
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "SheetRope")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_SheetRope = new Recipe_item(-1, Skill_Type.None, 0, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // õx1
                {
                    Recipe_Craft_SheetRope.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_SheetRope);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� ///////////
        for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.weapons_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Plank = new Recipe_item(-1, Skill_Type.None, 0, Type.weapon, target_index, 3);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // �볪��x1
                {
                    Recipe_Craft_Plank.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Handsaw")  // ��_Tool
                {
                    Recipe_Craft_Plank.Add_Recipe_Ingredients_Tool(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Plank);
        }
        else
        {
            target_index = -1;
        }

        /////////// �볪�� ���� ///////////
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log stack")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Logs = new Recipe_item(-1, Skill_Type.None, 0, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // �볪��x4
                {
                    Recipe_Craft_Logs.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Logs);
        }
        else
        {
            target_index = -1;
        }

        /////////// �볪��x4 ///////////  
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Log = new Recipe_item(-1, Skill_Type.None, 0, Type.Normal, target_index, 4);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log stack")  // �볪�� ����x1
                {
                    Recipe_Craft_Log.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Log);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���۵� â ///////////
        for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "SpearStick")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.weapons_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Spear = new Recipe_item(-1, Skill_Type.None, 0, Type.weapon, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x1
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // ����ü_Tool
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Cleaver")  // �߽ĵ�_Tool
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Spear);
        }
        else
        {
            target_index = -1;
        }

        /////////// â ( ����ü ) ///////////
        for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "SpearMachete")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.weapons_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_SpearMachete = new Recipe_item(-1, Skill_Type.None, 0, Type.weapon, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "SpearStick")  // ���۵� âx1
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // ����üx1
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Duct Tape")  // ���� ���� ������x2
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_SpearMachete);
        }
        else
        {
            target_index = -1;
        }

        /////////// �θ� ///////////
        for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Splint")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.medical_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Splint = new Recipe_item(-1, Skill_Type.FirstAid, 0, Type.Medical, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������ õx1
                {
                    Recipe_Craft_Splint.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x1
                {
                    Recipe_Craft_Splint.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Splint);
        }
        else
        {
            target_index = -1;
        }

        /////////// ưư�� �����x8 /////////// 
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "WoodenStick")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Sturdy_Stick = new Recipe_item(-1, Skill_Type.None, 0, Type.Normal, target_index, 8);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x1
                {
                    Recipe_Craft_Sturdy_Stick.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Handsaw")  // ��_Tool
                {
                    Recipe_Craft_Sturdy_Stick.Add_Recipe_Ingredients_Tool(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Sturdy_Stick);
        }
        else
        {
            target_index = -1;
        }

        /////////// �ݼ��� ///////////  // �ݼ�level_2       // �ݼ� exp 6.25
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Metal_Sheet = new Recipe_item(-1, Skill_Type.Electrical, 2, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")  // �����ݼ���x4
                {
                    Recipe_Make_Metal_Sheet.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // ������ ��ġx2_Tool
                {
                    Recipe_Make_Metal_Sheet.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // �����⸶��ũ_Tool
                {
                    Recipe_Make_Metal_Sheet.Add_Recipe_Ingredients_Tool(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Metal_Sheet);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� �ݼ���x3 ///////////  // �ݼ�level_2        // �ݼ� exp 6.25
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Small_Metal_Sheet = new Recipe_item(-1, Skill_Type.Electrical, 2, Type.Normal, target_index, 3);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // �ݼ���x1
                {
                    Recipe_Make_Small_Metal_Sheet.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // ������ ��ġx2_Tool
                {
                    Recipe_Make_Small_Metal_Sheet.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // �����⸶��ũ_Tool
                {
                    Recipe_Make_Small_Metal_Sheet.Add_Recipe_Ingredients_Tool(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Small_Metal_Sheet);
        }
        else
        {
            target_index = -1;
        }

        /////////// ��Ʈ���� ///////////    
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Mattress")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Mattress = new Recipe_item(-1, Skill_Type.None, 0, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Twine")  // ��x2
                {
                    Recipe_Make_Mattress.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // õx5
                {
                    Recipe_Make_Mattress.Add_Recipe_Ingredients(Type.Normal, i, 5);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Needle")  // �ٴ�
                {
                    Recipe_Make_Mattress.Add_Recipe_Ingredients_Tool(Type.Tool, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Mattress);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� �� ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Wooden Walls")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Wooden_Walls = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x2
                {
                    Recipe_Make_Wooden_Walls.Add_Recipe_Ingredients(Type.weapon, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x4
                {
                    Recipe_Make_Wooden_Walls.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Wooden_Walls.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Wooden_Walls);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� �ٴ� ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Wooden Tiles")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Wooden_Tiles = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x1
                {
                    Recipe_Make_Wooden_Tiles.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x1
                {
                    Recipe_Make_Wooden_Tiles.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Wooden_Tiles.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Wooden_Tiles);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� �� ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Wooden Door")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Wooden_Door = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x4
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients(Type.weapon, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x4
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Aluminum")  // �˷�̴�x1
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Wooden_Door);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� ��Ÿ�� ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Wooden Fence")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Wooden_Fence = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x2
                {
                    Recipe_Make_Wooden_Fence.Add_Recipe_Ingredients(Type.weapon, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x3
                {
                    Recipe_Make_Wooden_Fence.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Wooden_Fence.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Wooden_Fence);
        }
        else
        {
            target_index = -1;
        }

        /////////// õ Ŀư ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Sheet Curtain")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Sheet_Curtain = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // õx1
                {
                    Recipe_Make_Sheet_Curtain.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Sheet_Curtain);
        }
        else
        {
            target_index = -1;
        }

        /////////// �ٸ�����Ʈ ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Barricade")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Barricade = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x1
                {
                    Recipe_Make_Barricade.Add_Recipe_Ingredients(Type.weapon, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x2
                {
                    Recipe_Make_Barricade.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ_Tool
                {
                    Recipe_Make_Barricade.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Barricade);
        }
        else
        {
            target_index = -1;
        }

        /////////// �ݼ� �ٸ�����Ʈ ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Metal Barricade")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Metal_Barricade = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // �ݼ���x1
                {
                    Recipe_Make_Metal_Barricade.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // ������ ��ġx2_Tool
                {
                    Recipe_Make_Metal_Barricade.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // �����⸶��ũ_Tool
                {
                    Recipe_Make_Metal_Barricade.Add_Recipe_Ingredients_Tool(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Metal_Barricade);
        }
        else
        {
            target_index = -1;
        }

        /////////// ��ں� ///////////   
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Campfire")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Campfire = new Recipe_item(-1, Skill_Type.Carpentry, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������ õx2
                {
                    Recipe_Make_Campfire.Add_Recipe_Ingredients(Type.Medical, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // �볪��x2
                {
                    Recipe_Make_Campfire.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Campfire);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� ///////////      
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Oven")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Oven = new Recipe_item(-1, Skill_Type.Electrical, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // ö��x2
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Glue")  // ������x2
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // ������ǰ ��ǰx4
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // ��ũ������̹�_Tool
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Oven);
        }
        else
        {
            target_index = -1;
        }

        /////////// ����� ///////////       
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Refrigerator")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Refrigerator = new Recipe_item(-1, Skill_Type.Electrical, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // ö��x3
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // �ݼ���x2
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // ������ǰ ��ǰx4
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // ��ũ������̹�_Tool
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Refrigerator);
        }
        else
        {
            target_index = -1;
        }

        /////////// �������� ///////////   //  ���level_1
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Wooden Crate")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Wooden_Crate = new Recipe_item(-1, Skill_Type.Carpentry, 1, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x3
                {
                    Recipe_Craft_Wooden_Crate.Add_Recipe_Ingredients(Type.weapon, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x3
                {
                    Recipe_Craft_Wooden_Crate.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ_Tool
                {
                    Recipe_Craft_Wooden_Crate.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Wooden_Crate);
        }
        else
        {
            target_index = -1;
        }

        /////////// �ݼӻ��� ///////////  // �ݼ�level_4
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Metal Crate")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Craft_Metal_Crate = new Recipe_item(-1, Skill_Type.Electrical, 4, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Metal Pipe")  // �ݼ�������x2
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.weapon, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // �ݼ���x1
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")  // �����ݼ���x1
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "ScrapMetal")  // �ݼӺ�ǰx1
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // ������ ��ġx2_Tool
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // �����⸶��ũ_Tool
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients_Tool(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Metal_Crate);
        }
        else
        {
            target_index = -1;
        }

        /////////// ħ�� ///////////    // ���level_2
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Bed")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Bed = new Recipe_item(-1, Skill_Type.None, 2, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����x6
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients(Type.weapon, i, 6);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // ��x4
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Mattress")  // ��Ʈ����x1
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // ��ġ
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Bed);
        }
        else
        {
            target_index = -1;
        }

        /////////// ���� �ٺ�ť ��� ///////////    //14. Engineer Magazine Vol. 1
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Charcoal Barbecue")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Charcoal_Barbecue = new Recipe_item(14, Skill_Type.Electrical, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")  // �����ݼ���x4
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������õx3
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients(Type.Medical, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // ������ ��ġx2_Tool
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // �����⸶��ũ_Tool
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients_Tool(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Charcoal_Barbecue);
        }
        else
        {
            target_index = -1;
        }

        /////////// ������ �ٺ�ť ��� ///////////   //15. Engineer Magazine Vol. 2 
        for (int i = 0; i < Item_DataBase.item_database.furniture_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.furniture_Ins[i].Furniture_Name == "Propane Barbecue")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.furniture_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Propane_Barbecue = new Recipe_item(15, Skill_Type.Electrical, 0, Type.Furniture, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // �ݼ���x4
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Tank")  // ��������ũx1
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients(Type.Electronics, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // ������ ��ġx2_Tool
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // �����⸶��ũ_Tool
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients_Tool(Type.clothing, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Propane_Barbecue);
        }
        else
        {
            target_index = -1;
        }

        /////////// ������ /////////// 
        for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Poultice")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.medical_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Make_Poultice = new Recipe_item(-1, Skill_Type.FirstAid, 0, Type.Medical, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Plantain")  // ������x2
                {
                    Recipe_Make_Poultice.Add_Recipe_Ingredients(Type.Medical, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "MortarPestle")  // ����_Tool
                {
                    Recipe_Make_Poultice.Add_Recipe_Ingredients_Tool(Type.Medical, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Make_Poultice);
        }
        else
        {
            target_index = -1;
        }

        /////////// źâ ���� /////////// 
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Magazine")  // �� 30�� ���� ����
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Charge_Magazine = new Recipe_item(-1, Skill_Type.None, 1, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "BulletBox")  // ź�����
                {
                    Recipe_Charge_Magazine.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Magazine (Empty)")  // �� źâ
                {
                    Recipe_Charge_Magazine.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Charge_Magazine);
        }
        else
        {
            target_index = -1;
        }

        /////////// �� /////////// 
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")
            {
                target_index = i;
                break;
            }
            else
            {
                if (i == Item_DataBase.item_database.ETC_Ins.Count - 1)
                {
                    target_index = -1;
                }
            }
        }
        if (target_index >= 0)
        {
            Recipe_Open_NailBox = new Recipe_item(-1, Skill_Type.None, 1, Type.Normal, target_index, 100);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "NailsBox")  // ������
                {
                    Recipe_Open_NailBox.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Open_NailBox);
        }
        else
        {
            target_index = -1;
        }


    }


    private void Start()
    { 
        // Start �����Ǵ� �����Ҷ� true�� ����
        Recipe_Craft_Salad.Set_Is_Crafting();
        Recipe_Craft_RippedSheets.Set_Is_Crafting();
        Recipe_Craft_Sheets.Set_Is_Crafting();
        Recipe_Craft_SheetRope.Set_Is_Crafting();
        Recipe_Craft_Plank.Set_Is_Crafting();
        Recipe_Craft_Logs.Set_Is_Crafting();
        Recipe_Craft_Log.Set_Is_Crafting();
        Recipe_Craft_Spear.Set_Is_Crafting();
        Recipe_Craft_SpearMachete.Set_Is_Crafting();
        Recipe_Craft_Splint.Set_Is_Crafting();
        Recipe_Craft_Sturdy_Stick.Set_Is_Crafting();
        Recipe_Make_Oven.Set_Is_Crafting();
        Recipe_Make_Refrigerator.Set_Is_Crafting();
        Recipe_Make_Mattress.Set_Is_Crafting();
        Recipe_Make_Wooden_Walls.Set_Is_Crafting();
        Recipe_Make_Wooden_Tiles.Set_Is_Crafting();
        Recipe_Make_Wooden_Door.Set_Is_Crafting();
        Recipe_Make_Wooden_Fence.Set_Is_Crafting();
        Recipe_Make_Sheet_Curtain.Set_Is_Crafting();
        Recipe_Make_Barricade.Set_Is_Crafting();
        Recipe_Make_Campfire.Set_Is_Crafting();
        Recipe_Make_Metal_Barricade.Set_Is_Crafting();
        Recipe_Craft_Sterilized_RippedSheets.Set_Is_Crafting();
        Recipe_Make_Poultice.Set_Is_Crafting();
        Recipe_Charge_Magazine.Set_Is_Crafting();
        Recipe_Open_NailBox.Set_Is_Crafting();



        // �׽�Ʈ �� false �� �ٲ����ϴ� ������ ( ���ǿ� ������ true�� �ٲ��� �� )
        // ����
        Recipe_Make_Metal_Sheet.Set_Is_Crafting();
        Recipe_Make_Small_Metal_Sheet.Set_Is_Crafting();
        Recipe_Craft_Wooden_Crate.Set_Is_Crafting();
        Recipe_Craft_Metal_Crate.Set_Is_Crafting();
        Recipe_Make_Bed.Set_Is_Crafting();


        // �Ű���
        Recipe_Make_Log_Walls.Set_Is_Crafting();
        Recipe_Make_Counters.Set_Is_Crafting();
        Recipe_Make_Composter.Set_Is_Crafting();
        Recipe_Make_Charcoal_Barbecue.Set_Is_Crafting();
        Recipe_Make_Propane_Barbecue.Set_Is_Crafting();
        Recipe_Make_Fishing_Rod.Set_Is_Crafting();
        Recipe_Make_Fishing_Net.Set_Is_Crafting();
        Recipe_Get_Wire_Back.Set_Is_Crafting();
        Recipe_Make_Mildew_Cure.Set_Is_Crafting();
        Recipe_Make_Flies_Cure.Set_Is_Crafting();
        Recipe_Make_Bread.Set_Is_Crafting();
        Recipe_Make_Bowl_of_Rice.Set_Is_Crafting();
        Recipe_Craft_Makeshift_Radio.Set_Is_Crafting();
        Recipe_Craft_Makeshift_Walkie_Talkie.Set_Is_Crafting();


    }







}
