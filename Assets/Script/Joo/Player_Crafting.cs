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

    public int Magazine_ID;  // 잡지 안읽는 레시피는 -1
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
    public int Recipe_value;  // 필요한 개수 or 용량

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
    public Recipe_item Recipe_Make_Bread;  // 빵
    //13. Good Cooking Magazine Vol. 2 
    public Recipe_item Recipe_Make_Bowl_of_Rice; // 볶음밥

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
    public Recipe_item Recipe_Craft_Salad;  // 샐러드

    public Recipe_item Recipe_Craft_RippedSheets;  // 찢어진 천
    //public Recipe_item Recipe_Craft_RippedSheets_1;  // 찢어진 천
    public Recipe_item Recipe_Craft_Sterilized_RippedSheets;  // 소독된 찢어진 천
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
    public Recipe_item Recipe_Craft_Wooden_Crate;  // 나무상자   // 재료: 판자x3, 못x3, 망치   + 목공level_1
    public Recipe_item Recipe_Craft_Metal_Crate;  // 금속상자   // 재료: 금속파이프x2, 금속판x1, 작은금속판x1, 금속부품x1, 프로판토치(2), 용접 마스크   + 금속level_4

    public Recipe_item Recipe_Make_Oven;  // 오븐  // 철사x2, 접착제x2, 전자제품 부품x4 + 스크류드라이버
    public Recipe_item Recipe_Make_Refrigerator; // 냉장고  // 철사x3, 금속판x2, 전자제품 부품x4 + 스크류드라이버
    public Recipe_item Recipe_Make_Bed;  // 침대  // 판자x6, 못x4, 매트리스x1  + 망치   + 목공level_2
    public Recipe_item Recipe_Make_Mattress;  // 매트리스  // 실x2, 천x5  + 바늘
    public Recipe_item Recipe_Make_Wooden_Walls;  // 나무 벽
    public Recipe_item Recipe_Make_Wooden_Tiles;  // 나무 바닥
    public Recipe_item Recipe_Make_Wooden_Door;  // 나무 문
    public Recipe_item Recipe_Make_Wooden_Fence;  // 나무 울타리
    public Recipe_item Recipe_Make_Sheet_Curtain;  // 천 커튼
    public Recipe_item Recipe_Make_Barricade;  // 바리케이트
    public Recipe_item Recipe_Make_Metal_Barricade;  // 금속 바리케이트
    public Recipe_item Recipe_Make_Campfire;  // 모닥불

    public Recipe_item Recipe_Make_Poultice;  // 습포제
    public Recipe_item Recipe_Charge_Magazine;  // 탄창 충전
    public Recipe_item Recipe_Open_NailBox;  // 못 상자 -> 못


    public List<Recipe_item> Recipe_Crafting_list = new List<Recipe_item>();

    int target_index = -1;
    private void Awake()  
    {
        // Cooking
        /////////// 빵 ///////////    //12. Good Cooking Magazine Vol. 1    
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
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Flour")  // 밀가루x1
                {
                    Recipe_Make_Bread.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // 요리 재료인 경우
                {
                    Recipe_Make_Bread.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // 그릇_Tool
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

        /////////// 볶음밥 ///////////    //13. Good Cooking Magazine Vol. 2     
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
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Rice")  // 쌀x1
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // 요리 재료인 경우
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // 그릇_Tool
                {
                    Recipe_Make_Bowl_of_Rice.Add_Recipe_Ingredients_Tool(Type.Tool, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Cooking Pot")  // 냄비_Tool
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
        /////////// 발전기 ///////////    //19. How to Use Generators :  발전기 사용법
        Recipe_Teaches_the_player_how_to_connect_generators_to_buildings = new Recipe_item(19, Skill_Type.Electrical, 0, Type.Electronics, 0, 1);

        Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types = new Recipe_item(20, Skill_Type.Electrical, 0, Type.Normal, 0, 1);    //20. Laines Auto Manual - Commercial Models :  표준 차량 유형 유지관리 가능
        Recipe_Can_perform_maintenance_on_sport_vehicle_types = new Recipe_item(21, Skill_Type.Electrical, 0, Type.Normal, 0, 1);    //21. Laines Auto Manual - Performance Models :  대형 차량 유형 유지관리 가능
        Recipe_Can_perform_maintenance_on_standard_vehicle_types = new Recipe_item(22, Skill_Type.Electrical, 0, Type.Normal, 0, 1);    //22. Laines Auto Manual - Standard Models :  스포츠 차량 유형 유지관리 가능

        /////////// 통나무 벽 ///////////   //23. The Metalwork Magazine Vol. 1        // 목공 exp 1.25
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진천x4
                {
                    Recipe_Make_Log_Walls.Add_Recipe_Ingredients(Type.Medical, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // 통나무x4
                {
                    Recipe_Make_Log_Walls.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 카운터 ///////////   //24. The Metalwork Magazine Vol. 2         // 목공level_4   // 목공 exp 1.25
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x4
                {
                    Recipe_Make_Counters.Add_Recipe_Ingredients(Type.weapon, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x4
                {
                    Recipe_Make_Counters.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 퇴비통 ///////////    //25. The Metalwork Magazine Vol. 3         //  목공level_2   // 목공 exp 1.25
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x5
                {
                    Recipe_Make_Composter.Add_Recipe_Ingredients(Type.weapon, i, 5);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x4
                {
                    Recipe_Make_Composter.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 라디오 ///////////    //26. Guerilla Radio Vol. 1 
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // 철사x1
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Amplifier")  // 증폭기x1
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // 전자제품 부품x2
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Aluminum")  // 알루미늄x2
                {
                    Recipe_Craft_Makeshift_Radio.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // 스크류드라이버_Tool
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

        /////////// 무전기 제작 ///////////    //27. Guerilla Radio Vol. 2
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // 철사x2
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Amplifier")  // 증폭기x1
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // 전자제품 부품x3
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Aluminum")  // 알루미늄x3
                {
                    Recipe_Craft_Makeshift_Walkie_Talkie.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // 스크류드라이버_Tool
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
        /////////// 살충제 스프레이 ///////////   //16. The Farming Magazine
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
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Gardening Spray (Empty)")  // 빈 원예용 스프레이x1
                {
                    Recipe_Make_Mildew_Cure.Add_Recipe_Ingredients(Type.Tool, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Water")  // 물(3)
                {
                    Recipe_Make_Mildew_Cure.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Cigarettes")  // 담배(5)
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

        /////////// 곰팡이 스프레이 ///////////   //16. The Farming Magazine
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
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Gardening Spray (Empty)")  // 빈 원예용 스프레이x1
                {
                    Recipe_Make_Flies_Cure.Add_Recipe_Ingredients(Type.Tool, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Milk")  // 우유x1
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
        /////////// 낚시대 ///////////     //17. Angler USA Magazine Vol. 1
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "WoodenStick")  // 튼튼한 막대기x1
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Twine")  // 끈x2
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // 마테체_Tool
                {
                    Recipe_Make_Fishing_Rod.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Cleaver")  // 중식도_Tool
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

        /////////// 낚시 그물 ///////////     //18. Angler USA Magazine Vol. 2
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // 철사x1
                {
                    Recipe_Make_Fishing_Net.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Twine")  // 끈x2
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

        /////////// 고장난 낚시 그물에서 와이어 떼내기 ///////////     //18. Angler USA Magazine Vol. 2
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
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "FishTrap (broken)")  // 철사x1
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





        /////////// 샐러드 ///////////
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
                if (Item_DataBase.item_database.food_Ins[i].Ingredients_Cooked == true)  // 요리 재료인 경우
                {
                    Recipe_Craft_Salad.Add_Recipe_Ingredients(Type.food, i, 1);
                }

            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Bowl")  // 그릇_Tool
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

        /////////// 찢어진 천 ///////////
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
                if (Item_DataBase.item_database.clothing_Ins[i].Is_Cotton == true)  // T_shirt 타입인 의류  ( 추가 가능 )
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

        /////////// 소독된 찢어진 천 ///////////
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진 천
                {
                    Recipe_Craft_Sterilized_RippedSheets.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.food_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.food_Ins[i].FoodName == "Whiskey Bottle")  // 알코올
                {
                    Recipe_Craft_Sterilized_RippedSheets.Add_Recipe_Ingredients(Type.food, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Bottle of Disinfectant")  // 알코올
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

        /////////// 천 ///////////
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진 천x1
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

        /////////// 천 밧줄 ///////////
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // 천x1
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

        /////////// 판자 ///////////
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // 통나무x1
                {
                    Recipe_Craft_Plank.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Handsaw")  // 톱_Tool
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

        /////////// 통나무 묶음 ///////////
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

        /////////// 통나무x4 ///////////  
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log stack")  // 통나무 묶음x1
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

        /////////// 제작된 창 ///////////
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x1
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // 마테체_Tool
                {
                    Recipe_Craft_Spear.Add_Recipe_Ingredients_Tool(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Cleaver")  // 중식도_Tool
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

        /////////// 창 ( 마테체 ) ///////////
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "SpearStick")  // 제작된 창x1
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Machete")  // 마테체x1
                {
                    Recipe_Craft_SpearMachete.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Duct Tape")  // 강력 접착 테이프x2
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

        /////////// 부목 ///////////
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진 천x1
                {
                    Recipe_Craft_Splint.Add_Recipe_Ingredients(Type.Medical, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x1
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

        /////////// 튼튼한 막대기x8 /////////// 
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x1
                {
                    Recipe_Craft_Sturdy_Stick.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Handsaw")  // 톱_Tool
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

        /////////// 금속판 ///////////  // 금속level_2       // 금속 exp 6.25
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")  // 소형금속판x4
                {
                    Recipe_Make_Metal_Sheet.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // 프로판 토치x2_Tool
                {
                    Recipe_Make_Metal_Sheet.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // 용접기마스크_Tool
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

        /////////// 소형 금속판x3 ///////////  // 금속level_2        // 금속 exp 6.25
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // 금속판x1
                {
                    Recipe_Make_Small_Metal_Sheet.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // 프로판 토치x2_Tool
                {
                    Recipe_Make_Small_Metal_Sheet.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // 용접기마스크_Tool
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

        /////////// 매트리스 ///////////    
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Twine")  // 실x2
                {
                    Recipe_Make_Mattress.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // 천x5
                {
                    Recipe_Make_Mattress.Add_Recipe_Ingredients(Type.Normal, i, 5);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.Tool_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.Tool_Ins[i].Tool_Name == "Needle")  // 바늘
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

        /////////// 나무 벽 ///////////   
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x2
                {
                    Recipe_Make_Wooden_Walls.Add_Recipe_Ingredients(Type.weapon, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x4
                {
                    Recipe_Make_Wooden_Walls.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 나무 바닥 ///////////   
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x1
                {
                    Recipe_Make_Wooden_Tiles.Add_Recipe_Ingredients(Type.weapon, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x1
                {
                    Recipe_Make_Wooden_Tiles.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 나무 문 ///////////   
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x4
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients(Type.weapon, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x4
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Aluminum")  // 알루미늄x1
                {
                    Recipe_Make_Wooden_Door.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 나무 울타리 ///////////   
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x2
                {
                    Recipe_Make_Wooden_Fence.Add_Recipe_Ingredients(Type.weapon, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x3
                {
                    Recipe_Make_Wooden_Fence.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 천 커튼 ///////////   
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Sheet")  // 천x1
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

        /////////// 바리케이트 ///////////   
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x1
                {
                    Recipe_Make_Barricade.Add_Recipe_Ingredients(Type.weapon, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x2
                {
                    Recipe_Make_Barricade.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치_Tool
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

        /////////// 금속 바리케이트 ///////////   
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // 금속판x1
                {
                    Recipe_Make_Metal_Barricade.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // 프로판 토치x2_Tool
                {
                    Recipe_Make_Metal_Barricade.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // 용접기마스크_Tool
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

        /////////// 모닥불 ///////////   
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진 천x2
                {
                    Recipe_Make_Campfire.Add_Recipe_Ingredients(Type.Medical, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Log")  // 통나무x2
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

        /////////// 오븐 ///////////      
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // 철사x2
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Glue")  // 접착제x2
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // 전자제품 부품x4
                {
                    Recipe_Make_Oven.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // 스크류드라이버_Tool
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

        /////////// 냉장고 ///////////       
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Wire")  // 철사x3
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // 금속판x2
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients(Type.Normal, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Scrap Electronics")  // 전자제품 부품x4
                {
                    Recipe_Make_Refrigerator.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Screwdriver")  // 스크류드라이버_Tool
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

        /////////// 나무상자 ///////////   //  목공level_1
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x3
                {
                    Recipe_Craft_Wooden_Crate.Add_Recipe_Ingredients(Type.weapon, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x3
                {
                    Recipe_Craft_Wooden_Crate.Add_Recipe_Ingredients(Type.Normal, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치_Tool
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

        /////////// 금속상자 ///////////  // 금속level_4
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Metal Pipe")  // 금속파이프x2
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.weapon, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // 금속판x1
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")  // 작은금속판x1
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "ScrapMetal")  // 금속부품x1
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // 프로판 토치x2_Tool
                {
                    Recipe_Craft_Metal_Crate.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // 용접기마스크_Tool
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

        /////////// 침대 ///////////    // 목공level_2
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
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Plank")  // 판자x6
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients(Type.weapon, i, 6);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Nails")  // 못x4
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Mattress")  // 매트리스x1
                {
                    Recipe_Make_Bed.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.weapons_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.weapons_Ins[i].WeaponName == "Hammer")  // 망치
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

        /////////// 숯불 바베큐 기계 ///////////    //14. Engineer Magazine Vol. 1
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Small Metal Sheet")  // 소형금속판x4
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Ripped Sheets")  // 찢어진천x3
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients(Type.Medical, i, 3);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // 프로판 토치x2_Tool
                {
                    Recipe_Make_Charcoal_Barbecue.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // 용접기마스크_Tool
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

        /////////// 프로판 바베큐 기계 ///////////   //15. Engineer Magazine Vol. 2 
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Metal Sheet")  // 금속판x4
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients(Type.Normal, i, 4);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Tank")  // 프로판탱크x1
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients(Type.Electronics, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.electronics_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.electronics_Ins[i].ElectronicsName == "Propane Torch")  // 프로판 토치x2_Tool
                {
                    Recipe_Make_Propane_Barbecue.Add_Recipe_Ingredients_Tool(Type.Electronics, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "WeldingMask")  // 용접기마스크_Tool
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

        /////////// 습포제 /////////// 
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
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "Plantain")  // 질경이x2
                {
                    Recipe_Make_Poultice.Add_Recipe_Ingredients(Type.Medical, i, 2);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.medical_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.medical_Ins[i].MedicalName == "MortarPestle")  // 약사발_Tool
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

        /////////// 탄창 충전 /////////// 
        for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Magazine")  // 총 30발 전부 충전
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "BulletBox")  // 탄약상자
                {
                    Recipe_Charge_Magazine.Add_Recipe_Ingredients(Type.Normal, i, 1);
                }
            }
            for (int i = 0; i < Item_DataBase.item_database.ETC_Ins.Count; i++)
            {
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "Magazine (Empty)")  // 빈 탄창
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

        /////////// 못 /////////// 
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
                if (Item_DataBase.item_database.ETC_Ins[i].ETC_Name == "NailsBox")  // 못상자
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
        // Start 레시피는 시작할때 true로 변경
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



        // 테스트 후 false 로 바뀌어야하는 레시피 ( 조건에 맞을때 true로 바뀌어야 함 )
        // 레벨
        Recipe_Make_Metal_Sheet.Set_Is_Crafting();
        Recipe_Make_Small_Metal_Sheet.Set_Is_Crafting();
        Recipe_Craft_Wooden_Crate.Set_Is_Crafting();
        Recipe_Craft_Metal_Crate.Set_Is_Crafting();
        Recipe_Make_Bed.Set_Is_Crafting();


        // 매거진
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
