using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Recipe_item
{
    public bool Is_Craftng;

    public int Recipe_ID;  // 잡지 안읽는 레시피는 -1

    public Type Crafting_item_type;
    public int Crafting_item_ID;
    public Crafting_type _Crafting_type;
    public List<Recipe_Ingredients> Recipe_Ingredients_list = new List<Recipe_Ingredients>();

    public Recipe_item(int _Recipe_ID, Type _Crafting_item_type, int _Crafting_item_ID)
    {
        Recipe_ID = _Recipe_ID;
        Crafting_item_type = _Crafting_item_type;
        Crafting_item_ID = _Crafting_item_ID;
        Is_Craftng = false;

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
            case Type.gardening:
                _Crafting_type = Crafting_type.Crafting_Tool;
                break;
            case Type.Container:
                _Crafting_type = Crafting_type.Crafting_General;
                break;
            case Type.Normal:
                _Crafting_type = Crafting_type.Crafting_General;
                break;
            case Type.Furniture:
                _Crafting_type = Crafting_type.Crafting_Furniture;
                break;
        }
    }

    public void Add_Recipe_Ingredients(Type _DB_type, int _DB_ID, int value)
    {
        Recipe_Ingredients recipe_Ingredients = new Recipe_Ingredients(_DB_type, _DB_ID, value);
        Recipe_Ingredients_list.Add(recipe_Ingredients);
    }

    public void Add_Recipe()
    {
        switch (Crafting_item_type)
        {
            case Type.food:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.food_Ins[Crafting_item_ID].Food_Image[0], Item_DataBase.item_database.food_Ins[Crafting_item_ID].FoodName, Item_DataBase.item_database.food_Ins[Crafting_item_ID].FoodName_Kr);
                break;
            case Type.Medical:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.medical_Ins[Crafting_item_ID].Medical_Image, Item_DataBase.item_database.medical_Ins[Crafting_item_ID].MedicalName, Item_DataBase.item_database.medical_Ins[Crafting_item_ID].MedicalName_Kr);
                break;
            case Type.weapon:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.weapons_Ins[Crafting_item_ID].ItemImage, Item_DataBase.item_database.weapons_Ins[Crafting_item_ID].WeaponName, Item_DataBase.item_database.weapons_Ins[Crafting_item_ID].WeaponName_Kr);
                break;
            case Type.Electronics:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].Electronics_Image, Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].ElectronicsName, Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].ElectronicsName_Kr);
                break;
            case Type.gardening:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.gardening_Ins[Crafting_item_ID].Gardening_Image, Item_DataBase.item_database.gardening_Ins[Crafting_item_ID].Gardening_Name, Item_DataBase.item_database.electronics_Ins[Crafting_item_ID].ElectronicsName_Kr);
                break;
            case Type.Container:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.Container_Ins[Crafting_item_ID].Container_Image, Item_DataBase.item_database.Container_Ins[Crafting_item_ID].ContainerName, Item_DataBase.item_database.Container_Ins[Crafting_item_ID].ContainerName_Kr);
                break;
            case Type.Normal:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.ETC_Ins[Crafting_item_ID].ETC_Image, Item_DataBase.item_database.ETC_Ins[Crafting_item_ID].ETC_Name, Item_DataBase.item_database.ETC_Ins[Crafting_item_ID].ETC_Name_kr);
                break;
            case Type.Furniture:
                UI_Craft.UI_Craft_main.Add_Crafting_list(Crafting_item_type, Crafting_item_ID, _Crafting_type,
                    Item_DataBase.item_database.furniture_Ins[Crafting_item_ID].Furniture_Image, Item_DataBase.item_database.furniture_Ins[Crafting_item_ID].Furniture_Name, Item_DataBase.item_database.furniture_Ins[Crafting_item_ID].Furniture_Name_kr);
                break;
        }

        int temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(_Crafting_type) - 1;
        for (int i = 0; i < Recipe_Ingredients_list.Count; i++)
        {
            switch (_Crafting_type)
            {
                case Crafting_type.Crafting_General:
                   // UI_Craft.UI_Craft_main.Crafting_General_list[temp_index].Add_Ingredients
                break;
                case Crafting_type.Crafting_Tool:

                    break;
                case Crafting_type.Crafting_Cook:

                    break;
                case Crafting_type.Crafting_Medical:

                    break;
                case Crafting_type.Crafting_Furniture:

                    break;
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

    public void Add_Recipe()
    {
        //int temp_index = -1;
        //switch (_Crafting_item_type)
        //{            
        //    case Type.food:  // Crafting_Cook
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Cook);
        //        if(temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_Cook_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Cook)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.food_Ins[Recipe_Ingredients_DB_ID].Food_Image[0],
        //                Item_DataBase.item_database.food_Ins[Recipe_Ingredients_DB_ID].FoodName, Item_DataBase.item_database.food_Ins[Recipe_Ingredients_DB_ID].FoodName_Kr, Recipe_value);
        //        }
        //        break;
        //    case Type.Medical:  // Crafting_Medical
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Medical);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_Medical_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Medical)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.medical_Ins[Recipe_Ingredients_DB_ID].Medical_Image,
        //                Item_DataBase.item_database.medical_Ins[Recipe_Ingredients_DB_ID].MedicalName, Item_DataBase.item_database.medical_Ins[Recipe_Ingredients_DB_ID].MedicalName_Kr, Recipe_value);
        //        }
        //        break;
        //    case Type.weapon:  // Crafting_Tool
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Tool);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_Tool_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Tool)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.weapons_Ins[Recipe_Ingredients_DB_ID].ItemImage,
        //                Item_DataBase.item_database.weapons_Ins[Recipe_Ingredients_DB_ID].WeaponName, Item_DataBase.item_database.weapons_Ins[Recipe_Ingredients_DB_ID].WeaponName_Kr, Recipe_value);
        //        }
        //        break;
        //    case Type.Electronics:  // Crafting_General
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.electronics_Ins[Recipe_Ingredients_DB_ID].Electronics_Image,
        //                Item_DataBase.item_database.electronics_Ins[Recipe_Ingredients_DB_ID].ElectronicsName, Item_DataBase.item_database.electronics_Ins[Recipe_Ingredients_DB_ID].ElectronicsName_Kr, Recipe_value);
        //        }
        //        break;
        //    case Type.clothing:  // Crafting_General
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].
        //            Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.clothing_Ins[Recipe_Ingredients_DB_ID].ClothingImage,
        //            Item_DataBase.item_database.clothing_Ins[Recipe_Ingredients_DB_ID].Clothing_Name, Item_DataBase.item_database.clothing_Ins[Recipe_Ingredients_DB_ID].Clothing_Name_kr, Recipe_value);
        //        }
        //        break;
        //    case Type.gardening:  // Crafting_Tool
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Tool);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_Tool_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_Tool)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.gardening_Ins[Recipe_Ingredients_DB_ID].Gardening_Image,
        //                Item_DataBase.item_database.gardening_Ins[Recipe_Ingredients_DB_ID].Gardening_Name, Item_DataBase.item_database.gardening_Ins[Recipe_Ingredients_DB_ID].Gardening_Name_kr, Recipe_value);
        //        }
        //        break;
        //    case Type.Container:  // Crafting_General
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.Container_Ins[Recipe_Ingredients_DB_ID].Container_Image,
        //                Item_DataBase.item_database.Container_Ins[Recipe_Ingredients_DB_ID].ContainerName, Item_DataBase.item_database.Container_Ins[Recipe_Ingredients_DB_ID].ContainerName_Kr, Recipe_value);
        //        }
        //        break;
        //    case Type.Normal:  // Crafting_General
        //        temp_index = UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General);
        //        if (temp_index >= 0)
        //        {
        //            UI_Craft.UI_Craft_main.Crafting_General_list[UI_Craft.UI_Craft_main.Get_Crafting_list_index(Crafting_type.Crafting_General)].
        //                Add_Ingredients(Recipe_Ingredients_DB_type, Recipe_Ingredients_DB_ID, Item_DataBase.item_database.ETC_Ins[Recipe_Ingredients_DB_ID].ETC_Image,
        //                Item_DataBase.item_database.ETC_Ins[Recipe_Ingredients_DB_ID].ETC_Name, Item_DataBase.item_database.ETC_Ins[Recipe_Ingredients_DB_ID].ETC_Name_kr, Recipe_value);
        //        }
        //        break;
        //}
    }
}

//public class Recipe_for_Magazine
//{
//    public bool Is_reading;

//    public Type Magazine_type;
//    public int Magazine_ID;
//    public Type Craftingitem_type;
//    public int Craftingitem_ID;


//    public Recipe_for_Magazine(Type _Magazine_type, int _Magazine_ID, Type _Craftingitem_type, int _Craftingitem_ID)
//    {
//        Magazine_type = _Magazine_type;
//        Magazine_ID = _Magazine_ID;
//        Craftingitem_type = _Craftingitem_type;
//        Craftingitem_ID = _Craftingitem_ID;
//        Is_reading = false;
//    }

//}

public class Player_Crafting : MonoBehaviour
{
    //12. Good Cooking Magazine Vol. 1 : 케이크 반죽, 파이 반죽, 초콜릿칩쿠키 반죽, 초콜릿쿠키 반죽, 오트밀쿠키 반죽, 쇼트브레드쿠키 반죽, 설탕쿠키 반죽 만들기
    public Recipe_item Recipe_Make_Cake_Batter;
    public Recipe_item Recipe_Make_Pie_Dough;
    //13. Good Cooking Magazine Vol. 2 :  빵, 피자, 바게트, 비스킷 만들기
    public Recipe_item Recipe_Make_Bread; // dough
    //14. Electronics Magazine Vol. 1 :  리모콘 v1, v2, v3 만들기 ( -> 리모콘 만들기 하나로 통일 )
    public Recipe_item Recipe_Make_Remote_Controller;
    //15. Electronics Magazine Vol. 2 :  타이머 만들기, 다른 물건에 타이머 달기
    public Recipe_item Recipe_Make_Timer;
    public Recipe_item Recipe_Add_Timer;
    //16. Electronics Magazine Vol. 3 :  모션센서 v1, v2, v3 만들기 ( -> 모션센서 만들기 하나로 통일 )
    public Recipe_item Recipe_Add_Motion_Sensor;
    //17. Electronics Magazine Vol. 4 :  원격 트리거 만들기, 다른 물건에 원격 트리거 달기
    public Recipe_item Recipe_Make_Remote_Trigger;
    public Recipe_item Recipe_Add_Crafted_Trigger;
    //18. Engineer Magazine Vol. 1 :  소음 발생기 만들기
    public Recipe_item Recipe_Make_Noise_Maker;
    //19. Engineer Magazine Vol. 2 :  연막탄 만들기
    public Recipe_item Recipe_Make_Smoke_Bomb;
    //20. The Farming Magazine :  살충제 스프레이, 곰팡이 스프레이 만들기
    public Recipe_item Recipe_Make_Mildew_Cure;
    public Recipe_item Recipe_Make_Flies_Cure;
    //21. Angler USA Magazine Vol. 1 :  낚시대 만들기, 낚시대 고치기
    public Recipe_item Recipe_Make_Fishing_Rod;
    public Recipe_item Recipe_Fix_Fishing_Rod;
    //22. Angler USA Magazine Vol. 2 :  낚시 그물 만들기, 고장난 낚시 그물에서 와이어 떼내기
    public Recipe_item Recipe_Make_Fishing_Net;
    public Recipe_item Recipe_Get_Wire_Back;
    //23. The Herbalist :  독이 있는 열매, 버섯 식별 가능
    public Recipe_item Recipe_Can_identifty_poisonous_berries_and_mushrooms_and_forage_medicinal_plants;
    //24. How to Use Generators :  발전기 사용법
    public Recipe_item Recipe_Teaches_the_player_how_to_connect_generators_to_buildings;
    //25. The Hunter Magazine Vol. 1 :  스네어 트랩 만들기  // skip
    public Recipe_item Recipe_Make_Snare_Trap;
    //26. The Hunter Magazine Vol. 2 :  함정상자 만들기, 스틱 트랩 만들기  // skip
    public Recipe_item Recipe_Make_Trap_Box;
    public Recipe_item Recipe_Make_Stick_Trap;
    //27. The Hunter Magazine Vol. 3 :  케이지트랩 만들기  // skip
    public Recipe_item Recipe_Make_Cage_Trap;
    //28. Laines Auto Manual - Commercial Models :  표준 차량 유형 유지관리 가능
    public Recipe_item Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types;
    //29. Laines Auto Manual - Performance Models :  대형 차량 유형 유지관리 가능
    public Recipe_item Recipe_Can_perform_maintenance_on_sport_vehicle_types;
    //30. Laines Auto Manual - Standard Models :  스포츠 차량 유형 유지관리 가능
    public Recipe_item Recipe_Can_perform_maintenance_on_standard_vehicle_types;
    //31. The Metalwork Magazine Vol. 1 :  금속벽 만들기, 금속지붕 만들기
    public Recipe_item Recipe_Make_Metal_Walls;
    public Recipe_item Recipe_Make_Metal_Roof;
    //32. The Metalwork Magazine Vol. 2 :  금속컨테이너 만들기
    public Recipe_item Recipe_Make_Metal_Containers;
    //33. The Metalwork Magazine Vol. 3 :  금속울타리 만들기
    public Recipe_item Recipe_Make_Metal_Fences;
    //34. The Metalwork Magazine Vol. 4 :  금속판 만들기, 소형금속판 만들기
    public Recipe_item Recipe_Make_Metal_Sheet;
    public Recipe_item Recipe_Make_Small_Metal_Sheet;
    //35. Guerilla Radio Vol. 1 :  임시 라디오 제작
    public Recipe_item Recipe_Craft_Makeshift_Radio;
    //36. Guerilla Radio Vol. 2 :  임시 무전기 제작
    public Recipe_item Recipe_Craft_Makeshift_Walkie_Talkie;
    //37. Guerilla Radio Vol. 3 :  임시 햄 라디오 제작
    public Recipe_item Recipe_Craft_Makeshift_Ham_Radio;


    public Recipe_item Recipe_Craft_RippedSheets;





    public List<Recipe_item> Recipe_Crafting_list = new List<Recipe_item>();
    private void Awake()
    {
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

        Recipe_Make_Pie_Dough = new Recipe_item(12, Type.food, 0);
        //Recipe_Crafting_list.Add(Recipe_Make_Pie_Dough);

        Recipe_Make_Bread = new Recipe_item(13, Type.food, 0);
        //Recipe_Crafting_list.Add(Recipe_Make_Bread);

        // Electronics
        Recipe_Make_Remote_Controller = new Recipe_item(14, Type.Electronics, 0);
        Recipe_Make_Timer = new Recipe_item(15, Type.Electronics, 0);
        Recipe_Add_Timer = new Recipe_item(15, Type.Electronics, 0);
        Recipe_Add_Motion_Sensor = new Recipe_item(16, Type.Electronics, 0);
        Recipe_Make_Remote_Trigger = new Recipe_item(17, Type.Electronics, 0);
        Recipe_Add_Crafted_Trigger = new Recipe_item(17, Type.Electronics, 0);

        Recipe_Make_Noise_Maker = new Recipe_item(18, Type.Electronics, 0);
        Recipe_Make_Smoke_Bomb = new Recipe_item(19, Type.Electronics, 0);

        Recipe_Teaches_the_player_how_to_connect_generators_to_buildings = new Recipe_item(24, Type.Electronics, 0);

        Recipe_Can_perform_maintenance_on_heavy_duty_vehicle_types = new Recipe_item(28, Type.Normal, 0);
        Recipe_Can_perform_maintenance_on_sport_vehicle_types = new Recipe_item(29, Type.Normal, 0);
        Recipe_Can_perform_maintenance_on_standard_vehicle_types = new Recipe_item(30, Type.Normal, 0);

        Recipe_Make_Metal_Walls = new Recipe_item(31, Type.Normal, 0);
        Recipe_Make_Metal_Roof = new Recipe_item(31, Type.Normal, 0);
        Recipe_Make_Metal_Containers = new Recipe_item(32, Type.Electronics, 0);
        Recipe_Make_Metal_Fences = new Recipe_item(33, Type.Normal, 0);
        Recipe_Make_Metal_Sheet = new Recipe_item(34, Type.Normal, 0);
        Recipe_Make_Small_Metal_Sheet = new Recipe_item(34, Type.Normal, 0);

        Recipe_Craft_Makeshift_Radio = new Recipe_item(35, Type.Normal, 0);
        Recipe_Craft_Makeshift_Walkie_Talkie = new Recipe_item(36, Type.Normal, 0);
        Recipe_Craft_Makeshift_Ham_Radio = new Recipe_item(37, Type.Normal, 0);

        // Farming
        Recipe_Make_Mildew_Cure = new Recipe_item(20, Type.Normal, 0);
        Recipe_Make_Flies_Cure = new Recipe_item(20, Type.Normal, 0);

        // Fishing
        Recipe_Make_Fishing_Rod = new Recipe_item(21, Type.weapon, 0);
        Recipe_Fix_Fishing_Rod = new Recipe_item(21, Type.Normal, 0);
        Recipe_Make_Fishing_Net = new Recipe_item(22, Type.weapon, 0);
        Recipe_Get_Wire_Back = new Recipe_item(22, Type.Normal, 0);

        // Foraging
        Recipe_Can_identifty_poisonous_berries_and_mushrooms_and_forage_medicinal_plants = new Recipe_item(23, Type.Normal, 0);

        Recipe_Make_Snare_Trap = new Recipe_item(25, Type.weapon, 0);
        Recipe_Make_Trap_Box = new Recipe_item(26, Type.weapon, 0);
        Recipe_Make_Stick_Trap = new Recipe_item(26, Type.weapon, 0);
        Recipe_Make_Cage_Trap = new Recipe_item(27, Type.weapon, 0);



        // Start
        Recipe_Craft_RippedSheets = new Recipe_item(-1, Type.Medical, 6);
        for (int i = 0; i < Item_DataBase.item_database.clothing_Ins.Count; i++)
        {
            if (Item_DataBase.item_database.clothing_Ins[i].Clothing_Name == "Tshirt")
            {
                Recipe_Craft_RippedSheets.Add_Recipe_Ingredients(Type.clothing, i, 1);
                break;
            }
        }
        Recipe_Crafting_list.Add(Recipe_Craft_RippedSheets);

    }


    private void Start()
    {
        // Start 레시피는 시작할때 true로 변경
        Recipe_Craft_RippedSheets.Is_Craftng = true;
    }







}
