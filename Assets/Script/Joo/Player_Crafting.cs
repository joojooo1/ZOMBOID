using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UIElements;

public class Recipe_item
{
    public bool Is_Craftng;

    public int Recipe_ID;

    public int Magazine_ID;  // ���� ���д� �����Ǵ� -1
    public Type Crafting_item_type;
    public int Crafting_item_ID;
    public Crafting_type _Crafting_type;
    public int Crafting_item_number;
    public List<Recipe_Ingredients> Recipe_Ingredients_list;
    public List<Recipe_Ingredients> Recipe_Ingredients_Tool_list;

    public Recipe_item(int _Magazine_ID, Type _Crafting_item_type, int _Crafting_item_ID, int _Crafting_item_number)
    {
        Magazine_ID = _Magazine_ID;
        Crafting_item_type = _Crafting_item_type;
        Crafting_item_ID = _Crafting_item_ID;
        Crafting_item_number = _Crafting_item_number;
        Is_Craftng = false;
        Recipe_Ingredients_list = new List<Recipe_Ingredients>();
        Recipe_Ingredients_Tool_list = new List<Recipe_Ingredients>();

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

    public void Add_Recipe_Ingredients_Tool(Type _DB_type, int _DB_ID)
    {
        Recipe_Ingredients recipe_Ingredients = new Recipe_Ingredients(_DB_type, _DB_ID, 1);
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
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID);
                        break;
                    case Crafting_type.Crafting_Tool:
                        UI_Craft.UI_Craft_main.Crafting_Tool_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID);
                        break;
                    case Crafting_type.Crafting_Cook:
                        UI_Craft.UI_Craft_main.Crafting_Cook_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID);
                        break;
                    case Crafting_type.Crafting_Medical:
                        UI_Craft.UI_Craft_main.Crafting_Medical_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID);
                        break;
                    case Crafting_type.Crafting_Installation:
                        UI_Craft.UI_Craft_main.Crafting_Furniture_list[Current_index].Add_Ingredients_Tool(
                            Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_type, Recipe_Ingredients_Tool_list[i].Recipe_Ingredients_DB_ID);
                        break;
                }
            }
        }
    }
}

public class Recipe_Ingredients
{
    public Type Recipe_Ingredients_DB_type;
    public int Recipe_Ingredients_DB_ID;
    public int Recipe_value;  // �ʿ��� ����

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
    public Recipe_item Recipe_Make_Dough;  // ����
    //13. Good Cooking Magazine Vol. 2 
    public Recipe_item Recipe_Make_Bread; // ��

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
    public Recipe_item Recipe_Fix_Fishing_Rod;  // ���ô� ��ġ��
                                                // ���: ưư�� �����x1, ��x1, ��x2, Į
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
    public Recipe_item Recipe_Craft_RippedSheets;  // ������ õ
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

    public Recipe_item Recipe_Craft_Salad;

    public List<Recipe_item> Recipe_Crafting_list = new List<Recipe_item>();

    int target_index = -1;
    private void Awake()  
    {
        // ������
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
            Recipe_Craft_Salad = new Recipe_item(-1, Type.food, target_index, 1);
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
                    Recipe_Craft_Salad.Add_Recipe_Ingredients_Tool(Type.Tool, i);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Salad);
        }
        else
        {
            target_index = -1;
        }


        // Cooking
        //Recipe_Make_Cake_Batter = new Recipe_item(12, Type.food, 0);
        //for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
        //{
        //    if (Item_DataBase.item_database.food_Ins[i].FoodName == "Flour")
        //    {
        //        Recipe_Make_Cake_Batter.Add_Recipe_Ingredients(Type.food, i, 1);
        //        break;
        //    }
        //}
        //for (int i = 0; i < Item_DataBase.item_database.Container_Ins.Count; i++)
        //{
        //    if (Item_DataBase.item_database.Container_Ins[i].ContainerName == "Bowl")
        //    {
        //        Recipe_Make_Cake_Batter.Add_Recipe_Ingredients(Type.Container, i, 1);
        //        break;
        //    }
        //}
        //Recipe_Crafting_list.Add(Recipe_Make_Cake_Batter);

        Recipe_Make_Bread = new Recipe_item(13, Type.food, 0, 1);
        //Recipe_Crafting_list.Add(Recipe_Make_Bread);

        // Electronics
        Recipe_Teaches_the_player_how_to_connect_generators_to_buildings = new Recipe_item(24, Type.Electronics, 0, 1);

        Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types = new Recipe_item(28, Type.Normal, 0, 1);
        Recipe_Can_perform_maintenance_on_sport_vehicle_types = new Recipe_item(29, Type.Normal, 0, 1);
        Recipe_Can_perform_maintenance_on_standard_vehicle_types = new Recipe_item(30, Type.Normal, 0, 1);

        Recipe_Make_Log_Walls = new Recipe_item(31, Type.Furniture, 0, 1);
        Recipe_Make_Counters = new Recipe_item(32, Type.Furniture, 0, 1);
        Recipe_Make_Composter = new Recipe_item(33, Type.Furniture, 0, 1);
        Recipe_Make_Metal_Sheet = new Recipe_item(34, Type.Normal, 0, 1);
        Recipe_Make_Small_Metal_Sheet = new Recipe_item(34, Type.Normal, 0, 1);

        Recipe_Craft_Makeshift_Radio = new Recipe_item(35, Type.Normal, 0, 1);  // ���� ����
        Recipe_Craft_Makeshift_Walkie_Talkie = new Recipe_item(36, Type.Normal, 0, 1);  // ������ ����

        // Farming
        Recipe_Make_Mildew_Cure = new Recipe_item(20, Type.Normal, 0, 1);
        Recipe_Make_Flies_Cure = new Recipe_item(20, Type.Normal, 0, 1);

        // Fishing
        Recipe_Make_Fishing_Rod = new Recipe_item(21, Type.weapon, 0, 1);
        Recipe_Fix_Fishing_Rod = new Recipe_item(21, Type.Normal, 0, 1);
        Recipe_Make_Fishing_Net = new Recipe_item(22, Type.weapon, 0, 1);
        Recipe_Get_Wire_Back = new Recipe_item(22, Type.Normal, 0, 1);


        // Start
        // ������ õ
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
            Recipe_Craft_RippedSheets = new Recipe_item(-1, Type.Medical, target_index, 1); 
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Is_Cotton == true)  // T_shirt Ÿ���� �Ƿ�  ( �߰� ���� )
                {
                    Recipe_Craft_RippedSheets.Add_Recipe_Ingredients(Type.clothing, i, 1);
                    //break;
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_RippedSheets);
        }
        else
        {
            target_index = -1;
        }

        // õ
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
            Recipe_Craft_Sheets = new Recipe_item(-1, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������ õ
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

        // õ ����
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
            Recipe_Craft_SheetRope = new Recipe_item(-1, Type.Normal, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // õ
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


        // ����
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
            Recipe_Craft_Plank = new Recipe_item(-1, Type.weapon, target_index, 3);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // �볪��
                {
                    Recipe_Craft_Plank.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Plank);
        }
        else
        {
            target_index = -1;
        }


        // �볪�� ����
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
            Recipe_Craft_Logs = new Recipe_item(-1, Type.Normal, target_index, 1);
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

        // �볪��x4  
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
            Recipe_Craft_Log = new Recipe_item(-1, Type.Normal, target_index, 4);
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log stack")  // �볪�� ����
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

        // ���۵� â
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
            Recipe_Craft_Spear = new Recipe_item(-1, Type.weapon, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // ����ü_Tool
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients_Tool(Type.weapon, i);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Cleaver")  // �߽ĵ�_Tool
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients_Tool(Type.weapon, i);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Spear);
        }
        else
        {
            target_index = -1;
        }

        // â ( ����ü )
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
            Recipe_Craft_SpearMachete = new Recipe_item(-1, Type.weapon, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "SpearStick")  // ���۵� â
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // ����ü
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Duct Tape")  // ���� ���� ������
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

        // �θ�
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
            Recipe_Craft_Splint = new Recipe_item(-1, Type.Medical, target_index, 1);
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // ������ õ
                {
                    Recipe_Craft_Splint.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����
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

        // ưư�� �����x8   // ���: ����x1, ��
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
            Recipe_Craft_Sturdy_Stick = new Recipe_item(-1, Type.Normal, target_index, 8);
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // ����
                {
                    Recipe_Craft_Sturdy_Stick.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Handsaw")  // ��_Tool
                {
                    Recipe_Craft_Sturdy_Stick.Add_Recipe_Ingredients_Tool(Type.Tool, i);
                }
            }
            Recipe_Crafting_list.Add(Recipe_Craft_Sturdy_Stick);
        }
        else
        {
            target_index = -1;
        }

        Recipe_Make_Metal_Sheet = new Recipe_item(-1, Type.Normal, target_index, 1);    // �ݼ���  // ���: �����ݼ���x4, ��������ġ(2), ���� ����ũ + �ݼ�level_2       // �ݼ� exp 6.25
        Recipe_Make_Small_Metal_Sheet = new Recipe_item(-1, Type.Normal, target_index, 3);    // ���� �ݼ���x3  // ���: �ݼ���x1, ��������ġ(2), ���� ����ũ + �ݼ�level_2        // �ݼ� exp 6.25

    }


    private void Start()
    {
        //for (int i = 0; i < Recipe_Crafting_list.Count; i++)
        //{
        //    Recipe_Crafting_list[i].Recipe_ID = i;
        //}

        // Start �����Ǵ� �����Ҷ� true�� ����
        Recipe_Craft_Salad.Is_Craftng = true;

        Recipe_Craft_RippedSheets.Is_Craftng = true;
        Recipe_Craft_Sheets.Is_Craftng = true;
        Recipe_Craft_SheetRope.Is_Craftng= true;
        Recipe_Craft_Plank.Is_Craftng = true;
        Recipe_Craft_Logs.Is_Craftng = true;
        Recipe_Craft_Log.Is_Craftng = true;
        Recipe_Craft_Spear.Is_Craftng = true;
        Recipe_Craft_SpearMachete.Is_Craftng = true;
        Recipe_Craft_Splint.Is_Craftng = true;
        Recipe_Craft_Sturdy_Stick.Is_Craftng = true;
    }







}
