using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UIElements;

public class Recipe_item
{
    public bool Is_Craftng;

    public int Recipe_ID;

    public int Magazine_ID;  // 잡지 안읽는 레시피는 -1
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
        switch (Crafting_item_type)  // 만드는 아이템의 타입
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
    public int Recipe_value;  // 필요한 개수

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
    public Recipe_item Recipe_Make_Dough;  // 반죽
    //13. Good Cooking Magazine Vol. 2 
    public Recipe_item Recipe_Make_Bread; // 빵

    //14. Engineer Magazine Vol. 1
    public Recipe_item Recipe_Make_Charcoal_Barbecue;  // 숯불 바베큐 기계
                                                        // 재료: 소형금속판x4, 프로판토치(2), 용접 마스크 + 금속level_3   // 금속 exp 6.25
    //15. Engineer Magazine Vol. 2 
    public Recipe_item Recipe_Make_Propane_Barbecue;   // 프로판 바베큐 기계
                                                        // 재료: 금속판x4, 프로판탱크, 프로판토치(2), 용접 마스크 + 금속level_6   // 금속 exp 6.25

    //16. The Farming Magazine
    public Recipe_item Recipe_Make_Mildew_Cure;    // 살충제 스프레이
                                                    // 재료: 빈 원예용 스프레이, 물(3), 담배(5)
    public Recipe_item Recipe_Make_Flies_Cure;    // 곰팡이 스프레이
                                                    // 재료: 빈 원예용 스프레이, 우유

    //17. Angler USA Magazine Vol. 1
    public Recipe_item Recipe_Make_Fishing_Rod;  // 낚시대
                                                 // 재료: 튼튼한 막대기x1, 칼
    public Recipe_item Recipe_Fix_Fishing_Rod;  // 낚시대 고치기
                                                // 재료: 튼튼한 막대기x1, 못x1, 끈x2, 칼
    //18. Angler USA Magazine Vol. 2
    public Recipe_item Recipe_Make_Fishing_Net;  // 낚시 그물
                                                 // 재료: 끈x2, 철사x1
    public Recipe_item Recipe_Get_Wire_Back;  //  고장난 낚시 그물에서 와이어 떼내기   // 철사x1 나옴

    //19. How to Use Generators :  발전기 사용법
    public Recipe_item Recipe_Teaches_the_player_how_to_connect_generators_to_buildings;

    //20. Laines Auto Manual - Commercial Models :  표준 차량 유형 유지관리 가능
    public Recipe_item Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types;
    //21. Laines Auto Manual - Performance Models :  대형 차량 유형 유지관리 가능
    public Recipe_item Recipe_Can_perform_maintenance_on_sport_vehicle_types;
    //22. Laines Auto Manual - Standard Models :  스포츠 차량 유형 유지관리 가능
    public Recipe_item Recipe_Can_perform_maintenance_on_standard_vehicle_types;

    //23. The Metalwork Magazine Vol. 1
    public Recipe_item Recipe_Make_Log_Walls;   // 통나무 벽
                                                 //  재료: 찢어진천x4, 통나무x4, 망치   // 목공 exp 1.25
    //24. The Metalwork Magazine Vol. 2  
    public Recipe_item Recipe_Make_Counters;   // 카운터 
                                                //  재료: 판자x4, 못x4, 망치  + 목공level_4   // 목공 exp 1.25
    //25. The Metalwork Magazine Vol. 3 
    public Recipe_item Recipe_Make_Composter;   // 퇴비통
                                                 //  재료: 판자x5, 못x4, 망치  + 목공level_2   // 목공 exp 1.25

    //26. Guerilla Radio Vol. 1 
    public Recipe_item Recipe_Craft_Makeshift_Radio;  // 라디오
    //27. Guerilla Radio Vol. 2 
    public Recipe_item Recipe_Craft_Makeshift_Walkie_Talkie;  // 무전기

    /********** Level Recipe *********/



    // Start Recipe
    public Recipe_item Recipe_Craft_RippedSheets;  // 찢어진 천
    public Recipe_item Recipe_Craft_Sheets;  // 천
    public Recipe_item Recipe_Craft_SheetRope;  // 천 밧줄
    public Recipe_item Recipe_Craft_Plank;  // 판자
    public Recipe_item Recipe_Craft_Logs;  // 통나무 묶음
    public Recipe_item Recipe_Craft_Log;  // 통나무 ( 묶음 -> 낱개 )

    // public Recipe_item Recipe_Craft_Barricade;  // 바리케이트  ( 문or창문에 상호작용 )    // 재료: 판자x1, 못x2, 망치   // 목공 exp 0.75
    // public Recipe_item Recipe_Craft_Metal_Barricade;  // 금속 바리케이트    // 재료: 금속판x1, 프로판토치(1), 용접 마스크   // 금속 exp 1.5

    public Recipe_item Recipe_Make_Metal_Sheet;    // 금속판  // 재료: 소형금속판x4, 프로판토치(2), 용접 마스크 + 금속level_2       // 금속 exp 6.25
    public Recipe_item Recipe_Make_Small_Metal_Sheet;    // 소형 금속판x3  // 재료: 금속판x1, 프로판토치(2), 용접 마스크 + 금속level_2        // 금속 exp 6.25

    public Recipe_item Recipe_Craft_Spear;  // 제작된 창
    public Recipe_item Recipe_Craft_SpearMachete;  // 창(마테체)

    public Recipe_item Recipe_Craft_Splint;  // 부목  // 재료: 판자x1, 찢어진 천x1 
    public Recipe_item Recipe_Craft_Sturdy_Stick;  // 튼튼한 막대기x8   // 재료: 판자x1, 톱

    public Recipe_item Recipe_Craft_Salad;

    public List<Recipe_item> Recipe_Crafting_list = new List<Recipe_item>();

    int target_index = -1;
    private void Awake()  
    {
        // 샐러드
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
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // 요리 재료인 경우
                {
                    Recipe_Craft_Salad.Add_Recipe_Ingredients(Type.food, i, 1);
                }

            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // 그릇_Tool
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

        Recipe_Craft_Makeshift_Radio = new Recipe_item(35, Type.Normal, 0, 1);  // 라디오 제작
        Recipe_Craft_Makeshift_Walkie_Talkie = new Recipe_item(36, Type.Normal, 0, 1);  // 무전기 제작

        // Farming
        Recipe_Make_Mildew_Cure = new Recipe_item(20, Type.Normal, 0, 1);
        Recipe_Make_Flies_Cure = new Recipe_item(20, Type.Normal, 0, 1);

        // Fishing
        Recipe_Make_Fishing_Rod = new Recipe_item(21, Type.weapon, 0, 1);
        Recipe_Fix_Fishing_Rod = new Recipe_item(21, Type.Normal, 0, 1);
        Recipe_Make_Fishing_Net = new Recipe_item(22, Type.weapon, 0, 1);
        Recipe_Get_Wire_Back = new Recipe_item(22, Type.Normal, 0, 1);


        // Start
        // 찢어진 천
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
                if (Item_DataBase.item_database.clothing_Ins[i].Is_Cotton == true)  // T_shirt 타입인 의류  ( 추가 가능 )
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

        // 천
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진 천
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

        // 천 밧줄
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // 천
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


        // 판자
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // 통나무
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


        // 통나무 묶음
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // 통나무x4
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

        // 통나무x4  
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log stack")  // 통나무 묶음
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

        // 제작된 창
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // 마테체_Tool
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients_Tool(Type.weapon, i);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Cleaver")  // 중식도_Tool
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

        // 창 ( 마테체 )
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "SpearStick")  // 제작된 창
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // 마테체
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Duct Tape")  // 강력 접착 테이프
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

        // 부목
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진 천
                {
                    Recipe_Craft_Splint.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자
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

        // 튼튼한 막대기x8   // 재료: 판자x1, 톱
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자
                {
                    Recipe_Craft_Sturdy_Stick.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Handsaw")  // 톱_Tool
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

        Recipe_Make_Metal_Sheet = new Recipe_item(-1, Type.Normal, target_index, 1);    // 금속판  // 재료: 소형금속판x4, 프로판토치(2), 용접 마스크 + 금속level_2       // 금속 exp 6.25
        Recipe_Make_Small_Metal_Sheet = new Recipe_item(-1, Type.Normal, target_index, 3);    // 소형 금속판x3  // 재료: 금속판x1, 프로판토치(2), 용접 마스크 + 금속level_2        // 금속 exp 6.25

    }


    private void Start()
    {
        //for (int i = 0; i < Recipe_Crafting_list.Count; i++)
        //{
        //    Recipe_Crafting_list[i].Recipe_ID = i;
        //}

        // Start 레시피는 시작할때 true로 변경
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
